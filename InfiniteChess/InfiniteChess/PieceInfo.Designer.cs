namespace InfiniteChess
{
    partial class PieceInfo
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
            this.pieceInfoImage = new System.Windows.Forms.PictureBox();
            this.pieceInfoTitle = new System.Windows.Forms.Label();
            this.pieceInfoText = new System.Windows.Forms.TextBox();
            this.pieceInfoClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pieceInfoImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pieceInfoImage
            // 
            this.pieceInfoImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pieceInfoImage.Location = new System.Drawing.Point(12, 12);
            this.pieceInfoImage.Name = "pieceInfoImage";
            this.pieceInfoImage.Size = new System.Drawing.Size(254, 224);
            this.pieceInfoImage.TabIndex = 0;
            this.pieceInfoImage.TabStop = false;
            // 
            // pieceInfoTitle
            // 
            this.pieceInfoTitle.AutoSize = true;
            this.pieceInfoTitle.Location = new System.Drawing.Point(377, 12);
            this.pieceInfoTitle.Name = "pieceInfoTitle";
            this.pieceInfoTitle.Size = new System.Drawing.Size(35, 13);
            this.pieceInfoTitle.TabIndex = 1;
            this.pieceInfoTitle.Text = "label1";
            this.pieceInfoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pieceInfoText
            // 
            this.pieceInfoText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pieceInfoText.Cursor = System.Windows.Forms.Cursors.Default;
            this.pieceInfoText.Location = new System.Drawing.Point(272, 40);
            this.pieceInfoText.Multiline = true;
            this.pieceInfoText.Name = "pieceInfoText";
            this.pieceInfoText.ReadOnly = true;
            this.pieceInfoText.Size = new System.Drawing.Size(299, 170);
            this.pieceInfoText.TabIndex = 2;
            // 
            // pieceInfoClose
            // 
            this.pieceInfoClose.Location = new System.Drawing.Point(380, 217);
            this.pieceInfoClose.Name = "pieceInfoClose";
            this.pieceInfoClose.Size = new System.Drawing.Size(75, 23);
            this.pieceInfoClose.TabIndex = 3;
            this.pieceInfoClose.Text = "OK";
            this.pieceInfoClose.UseVisualStyleBackColor = true;
            this.pieceInfoClose.Click += new System.EventHandler(this.pieceInfoClose_Click);
            // 
            // PieceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 252);
            this.Controls.Add(this.pieceInfoClose);
            this.Controls.Add(this.pieceInfoText);
            this.Controls.Add(this.pieceInfoTitle);
            this.Controls.Add(this.pieceInfoImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PieceInfo";
            this.Text = "Piece Information";
            ((System.ComponentModel.ISupportInitialize)(this.pieceInfoImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pieceInfoImage;
        private System.Windows.Forms.Label pieceInfoTitle;
        private System.Windows.Forms.TextBox pieceInfoText;
        private System.Windows.Forms.Button pieceInfoClose;
    }
}