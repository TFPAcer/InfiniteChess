namespace InfiniteChess
{
    partial class AIDiff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIDiff));
            this.AIDiffSlider = new System.Windows.Forms.TrackBar();
            this.AIDiffLabel = new System.Windows.Forms.Label();
            this.AIDiffSliderLabel1 = new System.Windows.Forms.Label();
            this.AIDiffSliderLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AIDiffSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // AIDiffSlider
            // 
            this.AIDiffSlider.LargeChange = 20;
            this.AIDiffSlider.Location = new System.Drawing.Point(46, 69);
            this.AIDiffSlider.Maximum = 100;
            this.AIDiffSlider.Name = "AIDiffSlider";
            this.AIDiffSlider.Size = new System.Drawing.Size(245, 45);
            this.AIDiffSlider.SmallChange = 5;
            this.AIDiffSlider.TabIndex = 0;
            this.AIDiffSlider.Tag = "";
            this.AIDiffSlider.TickFrequency = 10;
            this.AIDiffSlider.Scroll += new System.EventHandler(this.AIDiffSlider_Scroll);
            // 
            // AIDiffLabel
            // 
            this.AIDiffLabel.AutoSize = true;
            this.AIDiffLabel.Location = new System.Drawing.Point(126, 38);
            this.AIDiffLabel.Name = "AIDiffLabel";
            this.AIDiffLabel.Size = new System.Drawing.Size(60, 13);
            this.AIDiffLabel.TabIndex = 1;
            this.AIDiffLabel.Text = "AI Difficulty";
            // 
            // AIDiffSliderLabel1
            // 
            this.AIDiffSliderLabel1.AutoSize = true;
            this.AIDiffSliderLabel1.Location = new System.Drawing.Point(43, 117);
            this.AIDiffSliderLabel1.Name = "AIDiffSliderLabel1";
            this.AIDiffSliderLabel1.Size = new System.Drawing.Size(30, 13);
            this.AIDiffSliderLabel1.TabIndex = 2;
            this.AIDiffSliderLabel1.Text = "Easy";
            // 
            // AIDiffSliderLabel2
            // 
            this.AIDiffSliderLabel2.AutoSize = true;
            this.AIDiffSliderLabel2.Location = new System.Drawing.Point(261, 117);
            this.AIDiffSliderLabel2.Name = "AIDiffSliderLabel2";
            this.AIDiffSliderLabel2.Size = new System.Drawing.Size(30, 13);
            this.AIDiffSliderLabel2.TabIndex = 3;
            this.AIDiffSliderLabel2.Text = "Hard";
            // 
            // AIDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 153);
            this.Controls.Add(this.AIDiffSliderLabel2);
            this.Controls.Add(this.AIDiffSliderLabel1);
            this.Controls.Add(this.AIDiffLabel);
            this.Controls.Add(this.AIDiffSlider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AIDiff";
            this.Text = "AI Settings";
            ((System.ComponentModel.ISupportInitialize)(this.AIDiffSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar AIDiffSlider;
        private System.Windows.Forms.Label AIDiffLabel;
        private System.Windows.Forms.Label AIDiffSliderLabel1;
        private System.Windows.Forms.Label AIDiffSliderLabel2;
    }
}