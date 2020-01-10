namespace Shroomsweeper
{
    partial class BestTimesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MediumBestTime = new System.Windows.Forms.Label();
            this.HardBestTime = new System.Windows.Forms.Label();
            this.EasyBestTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Easy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Medium";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hard:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Shroomsweeper.Properties.Resources.TileWithShroomWhite;
            this.pictureBox1.Location = new System.Drawing.Point(25, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Shroomsweeper.Properties.Resources.TileWithYouWhite;
            this.pictureBox2.Location = new System.Drawing.Point(364, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MediumBestTime
            // 
            this.MediumBestTime.AutoSize = true;
            this.MediumBestTime.Location = new System.Drawing.Point(253, 50);
            this.MediumBestTime.Name = "MediumBestTime";
            this.MediumBestTime.Size = new System.Drawing.Size(10, 13);
            this.MediumBestTime.TabIndex = 7;
            this.MediumBestTime.Text = "-";
            // 
            // HardBestTime
            // 
            this.HardBestTime.AutoSize = true;
            this.HardBestTime.Location = new System.Drawing.Point(253, 75);
            this.HardBestTime.Name = "HardBestTime";
            this.HardBestTime.Size = new System.Drawing.Size(10, 13);
            this.HardBestTime.TabIndex = 8;
            this.HardBestTime.Text = "-";
            // 
            // EasyBestTime
            // 
            this.EasyBestTime.AutoSize = true;
            this.EasyBestTime.Location = new System.Drawing.Point(253, 25);
            this.EasyBestTime.Name = "EasyBestTime";
            this.EasyBestTime.Size = new System.Drawing.Size(10, 13);
            this.EasyBestTime.TabIndex = 9;
            this.EasyBestTime.Text = "-";
            // 
            // BestTimesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 165);
            this.Controls.Add(this.EasyBestTime);
            this.Controls.Add(this.HardBestTime);
            this.Controls.Add(this.MediumBestTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BestTimesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Best times";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label MediumBestTime;
        private System.Windows.Forms.Label HardBestTime;
        private System.Windows.Forms.Label EasyBestTime;
    }
}