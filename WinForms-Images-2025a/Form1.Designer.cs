namespace WinForms_Images_2025a
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.textBoxByPercent = new System.Windows.Forms.TextBox();
            this.textBoxByWidth = new System.Windows.Forms.TextBox();
            this.textBoxByHeight = new System.Windows.Forms.TextBox();
            this.radioButtonByPercent = new System.Windows.Forms.RadioButton();
            this.radioButtonByWidth = new System.Windows.Forms.RadioButton();
            this.radioButtonByHeight = new System.Windows.Forms.RadioButton();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.checkBoxRenameFile = new System.Windows.Forms.CheckBox();
            this.buttonResizeImage = new System.Windows.Forms.Button();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxMessages = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 400);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Controls.Add(this.textBoxByPercent);
            this.groupBoxControls.Controls.Add(this.textBoxByWidth);
            this.groupBoxControls.Controls.Add(this.textBoxByHeight);
            this.groupBoxControls.Controls.Add(this.radioButtonByPercent);
            this.groupBoxControls.Controls.Add(this.radioButtonByWidth);
            this.groupBoxControls.Controls.Add(this.radioButtonByHeight);
            this.groupBoxControls.Controls.Add(this.buttonAbout);
            this.groupBoxControls.Controls.Add(this.checkBoxRenameFile);
            this.groupBoxControls.Controls.Add(this.buttonResizeImage);
            this.groupBoxControls.Controls.Add(this.buttonLoadImage);
            this.groupBoxControls.Controls.Add(this.buttonClose);
            this.groupBoxControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxControls.Location = new System.Drawing.Point(731, 12);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Size = new System.Drawing.Size(158, 266);
            this.groupBoxControls.TabIndex = 4;
            this.groupBoxControls.TabStop = false;
            this.groupBoxControls.Text = "Controls";
            // 
            // textBoxByPercent
            // 
            this.textBoxByPercent.Location = new System.Drawing.Point(103, 209);
            this.textBoxByPercent.MaxLength = 2;
            this.textBoxByPercent.Name = "textBoxByPercent";
            this.textBoxByPercent.Size = new System.Drawing.Size(35, 20);
            this.textBoxByPercent.TabIndex = 14;
            this.textBoxByPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxByPercent_KeyPress);
            // 
            // textBoxByWidth
            // 
            this.textBoxByWidth.Location = new System.Drawing.Point(103, 183);
            this.textBoxByWidth.MaxLength = 4;
            this.textBoxByWidth.Name = "textBoxByWidth";
            this.textBoxByWidth.Size = new System.Drawing.Size(35, 20);
            this.textBoxByWidth.TabIndex = 13;
            this.textBoxByWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxByWidth_KeyPress);
            // 
            // textBoxByHeight
            // 
            this.textBoxByHeight.Location = new System.Drawing.Point(103, 157);
            this.textBoxByHeight.MaxLength = 4;
            this.textBoxByHeight.Name = "textBoxByHeight";
            this.textBoxByHeight.Size = new System.Drawing.Size(35, 20);
            this.textBoxByHeight.TabIndex = 12;
            this.textBoxByHeight.Text = "1000";
            this.textBoxByHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxByHeight_KeyPress);
            // 
            // radioButtonByPercent
            // 
            this.radioButtonByPercent.AutoSize = true;
            this.radioButtonByPercent.Location = new System.Drawing.Point(17, 210);
            this.radioButtonByPercent.Name = "radioButtonByPercent";
            this.radioButtonByPercent.Size = new System.Drawing.Size(87, 17);
            this.radioButtonByPercent.TabIndex = 11;
            this.radioButtonByPercent.Text = "By Percent";
            this.radioButtonByPercent.UseVisualStyleBackColor = true;
            // 
            // radioButtonByWidth
            // 
            this.radioButtonByWidth.AutoSize = true;
            this.radioButtonByWidth.Location = new System.Drawing.Point(17, 184);
            this.radioButtonByWidth.Name = "radioButtonByWidth";
            this.radioButtonByWidth.Size = new System.Drawing.Size(76, 17);
            this.radioButtonByWidth.TabIndex = 10;
            this.radioButtonByWidth.Text = "By Width";
            this.radioButtonByWidth.UseVisualStyleBackColor = true;
            // 
            // radioButtonByHeight
            // 
            this.radioButtonByHeight.AutoSize = true;
            this.radioButtonByHeight.Checked = true;
            this.radioButtonByHeight.Location = new System.Drawing.Point(17, 158);
            this.radioButtonByHeight.Name = "radioButtonByHeight";
            this.radioButtonByHeight.Size = new System.Drawing.Size(80, 17);
            this.radioButtonByHeight.TabIndex = 9;
            this.radioButtonByHeight.TabStop = true;
            this.radioButtonByHeight.Text = "By Height";
            this.radioButtonByHeight.UseVisualStyleBackColor = true;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbout.Location = new System.Drawing.Point(17, 106);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(103, 23);
            this.buttonAbout.TabIndex = 7;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // checkBoxRenameFile
            // 
            this.checkBoxRenameFile.AutoSize = true;
            this.checkBoxRenameFile.Location = new System.Drawing.Point(17, 135);
            this.checkBoxRenameFile.Name = "checkBoxRenameFile";
            this.checkBoxRenameFile.Size = new System.Drawing.Size(96, 17);
            this.checkBoxRenameFile.TabIndex = 6;
            this.checkBoxRenameFile.Text = "Rename File";
            this.checkBoxRenameFile.UseVisualStyleBackColor = true;
            // 
            // buttonResizeImage
            // 
            this.buttonResizeImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResizeImage.Location = new System.Drawing.Point(17, 77);
            this.buttonResizeImage.Name = "buttonResizeImage";
            this.buttonResizeImage.Size = new System.Drawing.Size(103, 23);
            this.buttonResizeImage.TabIndex = 5;
            this.buttonResizeImage.Text = "Resize Images";
            this.buttonResizeImage.UseVisualStyleBackColor = true;
            this.buttonResizeImage.Click += new System.EventHandler(this.buttonResizeImage_Click);
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadImage.Location = new System.Drawing.Point(17, 48);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(103, 23);
            this.buttonLoadImage.TabIndex = 4;
            this.buttonLoadImage.Text = "Load Images";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(17, 19);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(103, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxMessages
            // 
            this.textBoxMessages.Location = new System.Drawing.Point(12, 418);
            this.textBoxMessages.Multiline = true;
            this.textBoxMessages.Name = "textBoxMessages";
            this.textBoxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMessages.Size = new System.Drawing.Size(700, 124);
            this.textBoxMessages.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 625);
            this.Controls.Add(this.textBoxMessages);
            this.Controls.Add(this.groupBoxControls);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(20, 100);
            this.Name = "Form1";
            this.Text = "Form Image Sizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxControls.ResumeLayout(false);
            this.groupBoxControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.Button buttonResizeImage;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxMessages;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.CheckBox checkBoxRenameFile;
        private System.Windows.Forms.RadioButton radioButtonByHeight;
        private System.Windows.Forms.RadioButton radioButtonByPercent;
        private System.Windows.Forms.RadioButton radioButtonByWidth;
        private System.Windows.Forms.TextBox textBoxByPercent;
        private System.Windows.Forms.TextBox textBoxByWidth;
        private System.Windows.Forms.TextBox textBoxByHeight;
    }
}

