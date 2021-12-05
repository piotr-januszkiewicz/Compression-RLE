
namespace Ja_proj_cs
{
    partial class kompresja
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.BeforeCompression = new System.Windows.Forms.PictureBox();
            this.AfterCompression = new System.Windows.Forms.PictureBox();
            this.CompressButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.Threads = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SizeOfUploadedElement = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Size = new System.Windows.Forms.Label();
            this.Size1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.Tom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.thred = new System.Windows.Forms.Label();
            this.ratio = new System.Windows.Forms.Label();
            this.cr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeCompression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterCompression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Threads)).BeginInit();
            this.SuspendLayout();
            // 
            // BeforeCompression
            // 
            this.BeforeCompression.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BeforeCompression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BeforeCompression.Location = new System.Drawing.Point(117, 56);
            this.BeforeCompression.Name = "BeforeCompression";
            this.BeforeCompression.Size = new System.Drawing.Size(216, 168);
            this.BeforeCompression.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BeforeCompression.TabIndex = 0;
            this.BeforeCompression.TabStop = false;
            this.BeforeCompression.Click += new System.EventHandler(this.BeforeCompression_Click);
            // 
            // AfterCompression
            // 
            this.AfterCompression.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AfterCompression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AfterCompression.Location = new System.Drawing.Point(453, 56);
            this.AfterCompression.Name = "AfterCompression";
            this.AfterCompression.Size = new System.Drawing.Size(216, 168);
            this.AfterCompression.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AfterCompression.TabIndex = 1;
            this.AfterCompression.TabStop = false;
            this.AfterCompression.Click += new System.EventHandler(this.AfterCompression_Click);
            // 
            // CompressButton
            // 
            this.CompressButton.Enabled = false;
            this.CompressButton.Location = new System.Drawing.Point(243, 270);
            this.CompressButton.Name = "CompressButton";
            this.CompressButton.Size = new System.Drawing.Size(75, 23);
            this.CompressButton.TabIndex = 2;
            this.CompressButton.Text = "Compress";
            this.CompressButton.UseVisualStyleBackColor = true;
            this.CompressButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(145, 270);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(75, 23);
            this.UploadButton.TabIndex = 3;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // Threads
            // 
            this.Threads.AllowDrop = true;
            this.Threads.LargeChange = 1;
            this.Threads.Location = new System.Drawing.Point(171, 393);
            this.Threads.Maximum = 64;
            this.Threads.Minimum = 1;
            this.Threads.Name = "Threads";
            this.Threads.Size = new System.Drawing.Size(447, 45);
            this.Threads.TabIndex = 1;
            this.Threads.Value = 1;
            this.Threads.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(357, 252);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Use assembler";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // SizeOfUploadedElement
            // 
            this.SizeOfUploadedElement.AutoSize = true;
            this.SizeOfUploadedElement.Location = new System.Drawing.Point(190, 239);
            this.SizeOfUploadedElement.Name = "SizeOfUploadedElement";
            this.SizeOfUploadedElement.Size = new System.Drawing.Size(30, 13);
            this.SizeOfUploadedElement.TabIndex = 8;
            this.SizeOfUploadedElement.Text = "Size:";
            this.SizeOfUploadedElement.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Size:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // Size
            // 
            this.Size.AutoSize = true;
            this.Size.Location = new System.Drawing.Point(254, 239);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(13, 13);
            this.Size.TabIndex = 10;
            this.Size.Text = "0";
            this.Size.Click += new System.EventHandler(this.Size_Click);
            // 
            // Size1
            // 
            this.Size1.AutoSize = true;
            this.Size1.Location = new System.Drawing.Point(605, 239);
            this.Size1.Name = "Size1";
            this.Size1.Size = new System.Drawing.Size(13, 13);
            this.Size1.TabIndex = 11;
            this.Size1.Text = "0";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(495, 270);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(36, 13);
            this.time.TabIndex = 12;
            this.time.Text = "Time: ";
            // 
            // Tom
            // 
            this.Tom.AutoSize = true;
            this.Tom.Location = new System.Drawing.Point(605, 270);
            this.Tom.Name = "Tom";
            this.Tom.Size = new System.Drawing.Size(13, 13);
            this.Tom.TabIndex = 13;
            this.Tom.Text = "0";
            this.Tom.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Threads: ";
            // 
            // thred
            // 
            this.thred.AutoSize = true;
            this.thred.Location = new System.Drawing.Point(387, 376);
            this.thred.Name = "thred";
            this.thred.Size = new System.Drawing.Size(13, 13);
            this.thred.TabIndex = 15;
            this.thred.Text = "1";
            // 
            // ratio
            // 
            this.ratio.AutoSize = true;
            this.ratio.Location = new System.Drawing.Point(495, 299);
            this.ratio.Name = "ratio";
            this.ratio.Size = new System.Drawing.Size(107, 13);
            this.ratio.TabIndex = 16;
            this.ratio.Text = "Compression ratio(%):";
            this.ratio.Click += new System.EventHandler(this.ratio_Click);
            // 
            // cr
            // 
            this.cr.AutoSize = true;
            this.cr.Location = new System.Drawing.Point(605, 299);
            this.cr.Name = "cr";
            this.cr.Size = new System.Drawing.Size(13, 13);
            this.cr.TabIndex = 17;
            this.cr.Text = "0";
            this.cr.Click += new System.EventHandler(this.label4_Click);
            // 
            // kompresja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 479);
            this.Controls.Add(this.cr);
            this.Controls.Add(this.ratio);
            this.Controls.Add(this.thred);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tom);
            this.Controls.Add(this.time);
            this.Controls.Add(this.Size1);
            this.Controls.Add(this.Size);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SizeOfUploadedElement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Threads);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.CompressButton);
            this.Controls.Add(this.AfterCompression);
            this.Controls.Add(this.BeforeCompression);
            this.Name = "kompresja";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.kompresja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BeforeCompression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterCompression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Threads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BeforeCompression;
        private System.Windows.Forms.PictureBox AfterCompression;
        private System.Windows.Forms.Button CompressButton;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.TrackBar Threads;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SizeOfUploadedElement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Size;
        private System.Windows.Forms.Label Size1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label Tom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label thred;
        private System.Windows.Forms.Label ratio;
        private System.Windows.Forms.Label cr;
    }
}

