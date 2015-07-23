namespace AlphaGenerator
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.openButton1 = new System.Windows.Forms.Button();
            this.openButton2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.colorButton1 = new System.Windows.Forms.Button();
            this.colorButton2 = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.openButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.openButton2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.infoLabel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.infoLabel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.colorButton1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.colorButton2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.generateButton, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 273);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // openButton1
            // 
            this.openButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openButton1.Location = new System.Drawing.Point(3, 3);
            this.openButton1.Name = "openButton1";
            this.openButton1.Size = new System.Drawing.Size(240, 23);
            this.openButton1.TabIndex = 4;
            this.openButton1.Text = "読み込み";
            this.openButton1.UseVisualStyleBackColor = true;
            // 
            // openButton2
            // 
            this.openButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openButton2.Location = new System.Drawing.Point(249, 3);
            this.openButton2.Name = "openButton2";
            this.openButton2.Size = new System.Drawing.Size(240, 23);
            this.openButton2.TabIndex = 5;
            this.openButton2.Text = "読み込み";
            this.openButton2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(249, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(240, 168);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // infoLabel1
            // 
            this.infoLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Location = new System.Drawing.Point(105, 203);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(35, 12);
            this.infoLabel1.TabIndex = 2;
            this.infoLabel1.Text = "label1";
            // 
            // infoLabel2
            // 
            this.infoLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.Location = new System.Drawing.Point(351, 203);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(35, 12);
            this.infoLabel2.TabIndex = 3;
            this.infoLabel2.Text = "label2";
            // 
            // colorButton1
            // 
            this.colorButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton1.Location = new System.Drawing.Point(3, 218);
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(240, 23);
            this.colorButton1.TabIndex = 6;
            this.colorButton1.Text = "button1";
            this.colorButton1.UseVisualStyleBackColor = true;
            // 
            // colorButton2
            // 
            this.colorButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton2.Location = new System.Drawing.Point(249, 218);
            this.colorButton2.Name = "colorButton2";
            this.colorButton2.Size = new System.Drawing.Size(240, 23);
            this.colorButton2.TabIndex = 7;
            this.colorButton2.Text = "button2";
            this.colorButton2.UseVisualStyleBackColor = true;
            // 
            // generateButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.generateButton, 2);
            this.generateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateButton.Location = new System.Drawing.Point(3, 247);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(486, 23);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "αチャンネル付き画像生成";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "画像ファイル|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff|すべてのファイル|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 273);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "AlphaGenerator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button openButton1;
        private System.Windows.Forms.Button openButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.Button colorButton1;
        private System.Windows.Forms.Button colorButton2;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

