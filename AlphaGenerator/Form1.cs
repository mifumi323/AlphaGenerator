using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaGenerator
{
    public partial class Form1 : Form
    {
        class Controler
        {
            public Controler(Form1 owner, Button openButton, PictureBox pictureBox, Label infoLabel, Button colorButton, Color color)
            {
                this.owner = owner;
                this.openButton = openButton;
                this.pictureBox = pictureBox;
                this.infoLabel = infoLabel;
                this.colorButton = colorButton;

                this.openFileDialog = owner.openFileDialog;
                this.colorDialog = owner.colorDialog;

                this.Color = color;
                this.FileName = null;

                openButton.Click += new EventHandler(openButton_Click);
                colorButton.Click += new EventHandler(colorButton_Click);
                pictureBox.AllowDrop = true;
                pictureBox.DragEnter += new DragEventHandler(pictureBox_DragEnter);
                pictureBox.DragDrop += new DragEventHandler(pictureBox_DragDrop);
            }

            private void openButton_Click(object sender, EventArgs e)
            {
                openFileDialog.FileName = FileName;
                if (openFileDialog.ShowDialog(owner) != DialogResult.OK) return;

                FileName = openFileDialog.FileName;
            }

            private void colorButton_Click(object sender, EventArgs e)
            {
                colorDialog.Color = color;
                if (colorDialog.ShowDialog(owner) != DialogResult.OK) return;

                Color = colorDialog.Color;
            }

            private void pictureBox_DragEnter(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
            }

            private void pictureBox_DragDrop(object sender, DragEventArgs e)
            {
                if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (files.Length > 0) FileName = files[0];
            }

            public Form1 owner;
            public Button openButton;
            public PictureBox pictureBox;
            public Label infoLabel;
            public Button colorButton;
            public OpenFileDialog openFileDialog;
            public ColorDialog colorDialog;

            private Color color;
            public Color Color
            {
                get { return color; }
                set
                {
                    color = value;
                    colorButton.Text = string.Format("背景色(R:{0}, G:{1}, B:{2})", color.R, color.G, color.B);
                    colorButton.BackColor = color;
                    colorButton.ForeColor = (color.R + color.G + color.B >= 128 * 3) ? Color.Black : Color.White;
                    owner.CheckImage();
                }
            }

            private string fileName;
            public string FileName
            {
                get { return fileName; }
                set
                {
                    fileName = value;
                    if (string.IsNullOrWhiteSpace(fileName))
                    {
                        Bitmap = null;
                    }
                    else
                    {
                        try
                        {
                            Bitmap = new Bitmap(fileName);
                        }
                        catch (Exception)
                        {
                            Bitmap = null;
                        }
                    }
                }
            }

            private Bitmap bitmap;
            public Bitmap Bitmap
            {
                get { return bitmap; }
                set
                {
                    bitmap = value;
                    pictureBox.Image = bitmap;
                    if (bitmap == null)
                    {
                        infoLabel.Text = "画像なし";
                    }
                    else
                    {
                        infoLabel.Text = string.Format("{0}({1}x{2})", Path.GetFileName(FileName), bitmap.Width, bitmap.Height);
                    }
                    owner.CheckImage();
                }
            }
        }

        Controler[] controler = new Controler[2];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controler[0] = new Controler(this, openButton1, pictureBox1, infoLabel1, colorButton1, Color.Black);
            controler[1] = new Controler(this, openButton2, pictureBox2, infoLabel2, colorButton2, Color.White);
        }

        public void CheckImage()
        {
            generateButton.Enabled = CanGenerate();
        }

        private bool CanGenerate()
        {
            for (int i = 0; i < 2; i++)
            {
                if (controler[i] == null) return false;
                if (controler[i].Bitmap == null) return false;
            }
            if (controler[0].Bitmap.Size != controler[1].Bitmap.Size) return false;
            if (controler[0].Color == controler[1].Color) return false;
            if (int.MaxValue / controler[0].Bitmap.Width < controler[0].Bitmap.Height) return false;
            return true;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (!CanGenerate()) return;
            int w = controler[0].Bitmap.Width;
            int h = controler[0].Bitmap.Height;
            var rect = new Rectangle(new Point(0, 0), controler[0].Bitmap.Size);
            int length = w * h;
            Int32[][] colormap = new Int32[][] { new Int32[length], new Int32[length] };

            // 各ピクセルにアクセスできるようにする
            for (int i = 0; i < 2; i++)
            {
                var bitmapData = controler[i].Bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                Marshal.Copy(bitmapData.Scan0, colormap[i], 0, length);
                controler[i].Bitmap.UnlockBits(bitmapData);
            }

            // α値、元の色の計算
            {
                var rangePartitioner = Partitioner.Create(0, length);
                int b0r = controler[0].Color.R;
                int b0g = controler[0].Color.G;
                int b0b = controler[0].Color.B;
                int b1r = controler[1].Color.R;
                int b1g = controler[1].Color.G;
                int b1b = controler[1].Color.B;
                int bdr = b0r - b1r;
                int bdg = b0g - b1g;
                int bdb = b0b - b1b;
                int bd = (bdr != 0 ? 1 : 0) + (bdg != 0 ? 1 : 0) + (bdb != 0 ? 1 : 0);
                Parallel.ForEach(rangePartitioner, (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        // 色成分を分解
                        int c0r = (colormap[0][i] >> 16) & 0xff;
                        int c0g = (colormap[0][i] >> 8) & 0xff;
                        int c0b = colormap[0][i] & 0xff;
                        int c1r = (colormap[1][i] >> 16) & 0xff;
                        int c1g = (colormap[1][i] >> 8) & 0xff;
                        int c1b = colormap[1][i] & 0xff;

                        // α値を算出
                        int alpha = 0;
                        if (bdr != 0) alpha += 255 * (bdr - c0r + c1r) / bdr;
                        if (bdg != 0) alpha += 255 * (bdg - c0g + c1g) / bdg;
                        if (bdb != 0) alpha += 255 * (bdb - c0b + c1b) / bdb;
                        alpha /= bd;

                        // αチャンネル付きの色を生成
                        if (alpha <= 0)
                        {
                            colormap[0][i] = 0;
                        }
                        else if (alpha >= 0xff)
                        {
                            colormap[0][i] |= unchecked((int)0xff000000);
                        }
                        else
                        {
                            c0r = (c0r * 0xff - b0r * (0xff - alpha)) / alpha;
                            if (c0r < 0) c0r = 0; else if (c0r > 0xff) c0r = 0xff;
                            c0g = (c0g * 0xff - b0g * (0xff - alpha)) / alpha;
                            if (c0g < 0) c0g = 0; else if (c0g > 0xff) c0g = 0xff;
                            c0b = (c0b * 0xff - b0b * (0xff - alpha)) / alpha;
                            if (c0b < 0) c0b = 0; else if (c0b > 0xff) c0b = 0xff;
                            colormap[0][i] = (alpha << 24) | (c0r << 16) | (c0g << 8) | c0b;
                        }
                    }
                });
            }

            // 表示
            {
                var bitmap = new Bitmap(w, h, PixelFormat.Format32bppArgb);
                var bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                Marshal.Copy(colormap[0], 0, bitmapData.Scan0, length);
                bitmap.UnlockBits(bitmapData);
                FormImage.ShowBitmap(this, bitmap);
            }
        }
    }
}
