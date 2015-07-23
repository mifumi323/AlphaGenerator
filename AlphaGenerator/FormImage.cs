using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlphaGenerator
{
    public partial class FormImage : Form
    {
        public static void ShowBitmap(IWin32Window owner, Bitmap bitmap)
        {
            if (bitmap == null) return;
            FormImage f = new FormImage();
            f.pictureBox.Image = bitmap;
            f.ShowDialog(owner);
        }

        public FormImage()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = null;
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;
            pictureBox.Image.Save(saveFileDialog.FileName);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
