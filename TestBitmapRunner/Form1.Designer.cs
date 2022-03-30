namespace TestBitmapRunner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblStats = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rainMinHTrackBar = new System.Windows.Forms.TrackBar();
            this.rainMaxHTrackBar = new System.Windows.Forms.TrackBar();
            this.rainOctaveTrackBar = new System.Windows.Forms.TrackBar();
            this.rainFreqTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.heatMinHTrackBar = new System.Windows.Forms.TrackBar();
            this.heatMaxHTrackBar = new System.Windows.Forms.TrackBar();
            this.heatOctivesTrackBar = new System.Windows.Forms.TrackBar();
            this.heatFreqTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rainMinHTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rainMaxHTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rainOctaveTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rainFreqTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heatMinHTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatMaxHTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatOctivesTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatFreqTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Biome_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 568);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(542, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(512, 512);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(1060, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(512, 512);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(1578, 21);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(512, 512);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(269, 578);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(79, 30);
            this.lblStats.TabIndex = 12;
            this.lblStats.Text = "lblStats";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rainMinHTrackBar);
            this.groupBox2.Controls.Add(this.rainMaxHTrackBar);
            this.groupBox2.Controls.Add(this.rainOctaveTrackBar);
            this.groupBox2.Controls.Add(this.rainFreqTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(1589, 547);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 370);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Humidity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "minHeight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "maxHeight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "octaves";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "frequency";
            // 
            // rainMinHTrackBar
            // 
            this.rainMinHTrackBar.Location = new System.Drawing.Point(230, 175);
            this.rainMinHTrackBar.Maximum = 255;
            this.rainMinHTrackBar.Name = "rainMinHTrackBar";
            this.rainMinHTrackBar.Size = new System.Drawing.Size(182, 80);
            this.rainMinHTrackBar.TabIndex = 3;
            // 
            // rainMaxHTrackBar
            // 
            this.rainMaxHTrackBar.Location = new System.Drawing.Point(230, 132);
            this.rainMaxHTrackBar.Maximum = 255;
            this.rainMaxHTrackBar.Name = "rainMaxHTrackBar";
            this.rainMaxHTrackBar.Size = new System.Drawing.Size(182, 80);
            this.rainMaxHTrackBar.TabIndex = 2;
            // 
            // rainOctaveTrackBar
            // 
            this.rainOctaveTrackBar.LargeChange = 1;
            this.rainOctaveTrackBar.Location = new System.Drawing.Point(230, 89);
            this.rainOctaveTrackBar.Minimum = 1;
            this.rainOctaveTrackBar.Name = "rainOctaveTrackBar";
            this.rainOctaveTrackBar.Size = new System.Drawing.Size(182, 80);
            this.rainOctaveTrackBar.TabIndex = 1;
            this.rainOctaveTrackBar.Value = 1;
            // 
            // rainFreqTrackBar
            // 
            this.rainFreqTrackBar.LargeChange = 1;
            this.rainFreqTrackBar.Location = new System.Drawing.Point(230, 46);
            this.rainFreqTrackBar.Name = "rainFreqTrackBar";
            this.rainFreqTrackBar.Size = new System.Drawing.Size(182, 80);
            this.rainFreqTrackBar.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.heatMinHTrackBar);
            this.groupBox1.Controls.Add(this.heatMaxHTrackBar);
            this.groupBox1.Controls.Add(this.heatOctivesTrackBar);
            this.groupBox1.Controls.Add(this.heatFreqTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(1062, 547);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 370);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Heat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "minHeight";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 30);
            this.label6.TabIndex = 6;
            this.label6.Text = "maxHeight";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "octaves";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 30);
            this.label8.TabIndex = 4;
            this.label8.Text = "frequency";
            // 
            // heatMinHTrackBar
            // 
            this.heatMinHTrackBar.Location = new System.Drawing.Point(230, 175);
            this.heatMinHTrackBar.Maximum = 255;
            this.heatMinHTrackBar.Name = "heatMinHTrackBar";
            this.heatMinHTrackBar.Size = new System.Drawing.Size(182, 80);
            this.heatMinHTrackBar.TabIndex = 3;
            // 
            // heatMaxHTrackBar
            // 
            this.heatMaxHTrackBar.Location = new System.Drawing.Point(230, 132);
            this.heatMaxHTrackBar.Maximum = 255;
            this.heatMaxHTrackBar.Name = "heatMaxHTrackBar";
            this.heatMaxHTrackBar.Size = new System.Drawing.Size(182, 80);
            this.heatMaxHTrackBar.TabIndex = 2;
            // 
            // heatOctivesTrackBar
            // 
            this.heatOctivesTrackBar.LargeChange = 1;
            this.heatOctivesTrackBar.Location = new System.Drawing.Point(230, 89);
            this.heatOctivesTrackBar.Minimum = 1;
            this.heatOctivesTrackBar.Name = "heatOctivesTrackBar";
            this.heatOctivesTrackBar.Size = new System.Drawing.Size(182, 80);
            this.heatOctivesTrackBar.TabIndex = 1;
            this.heatOctivesTrackBar.Value = 1;
            // 
            // heatFreqTrackBar
            // 
            this.heatFreqTrackBar.LargeChange = 1;
            this.heatFreqTrackBar.Location = new System.Drawing.Point(230, 46);
            this.heatFreqTrackBar.Name = "heatFreqTrackBar";
            this.heatFreqTrackBar.Size = new System.Drawing.Size(182, 80);
            this.heatFreqTrackBar.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2147, 929);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rainMinHTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rainMaxHTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rainOctaveTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rainFreqTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heatMinHTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatMaxHTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatOctivesTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatFreqTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label lblStats;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TrackBar rainMinHTrackBar;
        private TrackBar rainMaxHTrackBar;
        private TrackBar rainOctaveTrackBar;
        private TrackBar rainFreqTrackBar;
        private GroupBox groupBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TrackBar heatMinHTrackBar;
        private TrackBar heatMaxHTrackBar;
        private TrackBar heatOctivesTrackBar;
        private TrackBar heatFreqTrackBar;
    }
}