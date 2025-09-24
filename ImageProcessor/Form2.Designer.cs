namespace ImageProcessor
{
    partial class Form2
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
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.pbOut = new System.Windows.Forms.PictureBox();
            this.pbSrc = new System.Windows.Forms.PictureBox();
            this.pbFore = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbImgSrc = new System.Windows.Forms.RadioButton();
            this.rbCamSrc = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFore)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6.Location = new System.Drawing.Point(17, 253);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(132, 29);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Subtraction";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1143, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(755, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Background";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Location = new System.Drawing.Point(18, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 304);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(17, 38);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(133, 29);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Basic Copy";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.DisableSubtractionInterface);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(17, 81);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(121, 29);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Greyscale";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.DisableSubtractionInterface);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(17, 124);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(164, 29);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Color Inversion";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.DisableSubtractionInterface);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(17, 167);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(121, 29);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Histogram";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Click += new System.EventHandler(this.DisableSubtractionInterface);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton5.Location = new System.Drawing.Point(17, 210);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(84, 29);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "Sepia";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.Click += new System.EventHandler(this.DisableSubtractionInterface);
            // 
            // pbOut
            // 
            this.pbOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOut.Location = new System.Drawing.Point(995, 44);
            this.pbOut.Name = "pbOut";
            this.pbOut.Size = new System.Drawing.Size(360, 360);
            this.pbOut.TabIndex = 18;
            this.pbOut.TabStop = false;
            // 
            // pbSrc
            // 
            this.pbSrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSrc.Location = new System.Drawing.Point(629, 44);
            this.pbSrc.Name = "pbSrc";
            this.pbSrc.Size = new System.Drawing.Size(360, 360);
            this.pbSrc.TabIndex = 17;
            this.pbSrc.TabStop = false;
            // 
            // pbFore
            // 
            this.pbFore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFore.Location = new System.Drawing.Point(263, 44);
            this.pbFore.Name = "pbFore";
            this.pbFore.Size = new System.Drawing.Size(360, 360);
            this.pbFore.TabIndex = 26;
            this.pbFore.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(391, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Foreground";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbImgSrc);
            this.groupBox2.Controls.Add(this.rbCamSrc);
            this.groupBox2.Location = new System.Drawing.Point(629, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 53);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source";
            // 
            // rbImgSrc
            // 
            this.rbImgSrc.AutoSize = true;
            this.rbImgSrc.Checked = true;
            this.rbImgSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbImgSrc.Location = new System.Drawing.Point(12, 19);
            this.rbImgSrc.Name = "rbImgSrc";
            this.rbImgSrc.Size = new System.Drawing.Size(107, 24);
            this.rbImgSrc.TabIndex = 8;
            this.rbImgSrc.TabStop = true;
            this.rbImgSrc.Text = "Image File";
            this.rbImgSrc.UseVisualStyleBackColor = true;
            this.rbImgSrc.Click += new System.EventHandler(this.ImgSrcBtn_Checked);
            // 
            // rbCamSrc
            // 
            this.rbCamSrc.AutoSize = true;
            this.rbCamSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCamSrc.Location = new System.Drawing.Point(145, 18);
            this.rbCamSrc.Name = "rbCamSrc";
            this.rbCamSrc.Size = new System.Drawing.Size(89, 24);
            this.rbCamSrc.TabIndex = 9;
            this.rbCamSrc.Text = "Camera";
            this.rbCamSrc.UseVisualStyleBackColor = true;
            this.rbCamSrc.Click += new System.EventHandler(this.CamSrcBtn_Checked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(881, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 34);
            this.button1.TabIndex = 28;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChangeSourceImage);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(346, 423);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 34);
            this.button3.TabIndex = 31;
            this.button3.Text = "Change File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ChangeForegroundImage);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1184, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 34);
            this.button2.TabIndex = 33;
            this.button2.Text = "Export Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ExportProcessedImage);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1026, 424);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 34);
            this.button4.TabIndex = 32;
            this.button4.Text = "Process Image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ProcessSubtraction);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1372, 481);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbFore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbOut);
            this.Controls.Add(this.pbSrc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Processing Activity";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFore)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.PictureBox pbOut;
        private System.Windows.Forms.PictureBox pbSrc;
        private System.Windows.Forms.PictureBox pbFore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbImgSrc;
        private System.Windows.Forms.RadioButton rbCamSrc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}