namespace InfiniteChess
{
    partial class Chess
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
            this.begin = new System.Windows.Forms.Button();
            this.debug2 = new System.Windows.Forms.Label();
            this.sUp = new System.Windows.Forms.Button();
            this.sDown = new System.Windows.Forms.Button();
            this.sLeft = new System.Windows.Forms.Button();
            this.sRight = new System.Windows.Forms.Button();
            this.debug3 = new System.Windows.Forms.Label();
            this.boardPanel = new InfiniteChess.GameContainer();
            this.SuspendLayout();
            // 
            // begin
            // 
            this.begin.Location = new System.Drawing.Point(734, 40);
            this.begin.Name = "begin";
            this.begin.Size = new System.Drawing.Size(75, 23);
            this.begin.TabIndex = 1;
            this.begin.Text = "debug1";
            this.begin.UseVisualStyleBackColor = true;
            this.begin.Click += new System.EventHandler(this.begin_Click);
            // 
            // debug2
            // 
            this.debug2.AutoSize = true;
            this.debug2.Location = new System.Drawing.Point(750, 66);
            this.debug2.Name = "debug2";
            this.debug2.Size = new System.Drawing.Size(37, 13);
            this.debug2.TabIndex = 2;
            this.debug2.Text = "debug";
            // 
            // sUp
            // 
            this.sUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sUp.Location = new System.Drawing.Point(626, 12);
            this.sUp.Name = "sUp";
            this.sUp.Size = new System.Drawing.Size(22, 22);
            this.sUp.TabIndex = 3;
            this.sUp.Text = "↑";
            this.sUp.UseVisualStyleBackColor = true;
            this.sUp.Click += new System.EventHandler(this.sUp_Click);
            // 
            // sDown
            // 
            this.sDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sDown.Location = new System.Drawing.Point(626, 598);
            this.sDown.Name = "sDown";
            this.sDown.Size = new System.Drawing.Size(22, 22);
            this.sDown.TabIndex = 4;
            this.sDown.Text = "↓";
            this.sDown.UseVisualStyleBackColor = true;
            this.sDown.Click += new System.EventHandler(this.sDown_Click);
            // 
            // sLeft
            // 
            this.sLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLeft.Location = new System.Drawing.Point(12, 626);
            this.sLeft.Name = "sLeft";
            this.sLeft.Size = new System.Drawing.Size(22, 22);
            this.sLeft.TabIndex = 5;
            this.sLeft.Text = "←";
            this.sLeft.UseVisualStyleBackColor = true;
            this.sLeft.Click += new System.EventHandler(this.sLeft_Click);
            // 
            // sRight
            // 
            this.sRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sRight.Location = new System.Drawing.Point(598, 626);
            this.sRight.Name = "sRight";
            this.sRight.Size = new System.Drawing.Size(22, 22);
            this.sRight.TabIndex = 6;
            this.sRight.Text = "→";
            this.sRight.UseVisualStyleBackColor = true;
            this.sRight.Click += new System.EventHandler(this.sRight_Click);
            // 
            // debug3
            // 
            this.debug3.AutoSize = true;
            this.debug3.Location = new System.Drawing.Point(750, 90);
            this.debug3.Name = "debug3";
            this.debug3.Size = new System.Drawing.Size(37, 13);
            this.debug3.TabIndex = 7;
            this.debug3.Text = "debug";
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(12, 12);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(608, 608);
            this.boardPanel.TabIndex = 0;
            // 
            // InfinteChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 681);
            this.Controls.Add(this.debug3);
            this.Controls.Add(this.sRight);
            this.Controls.Add(this.sLeft);
            this.Controls.Add(this.sDown);
            this.Controls.Add(this.sUp);
            this.Controls.Add(this.debug2);
            this.Controls.Add(this.begin);
            this.Controls.Add(this.boardPanel);
            this.Name = "InfinteChess";
            this.Text = "InfiniteChess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameContainer boardPanel;
        private System.Windows.Forms.Button begin;
        private System.Windows.Forms.Label debug2;
        private System.Windows.Forms.Button sUp;
        private System.Windows.Forms.Button sDown;
        private System.Windows.Forms.Button sLeft;
        private System.Windows.Forms.Button sRight;
        private System.Windows.Forms.Label debug3;
    }
}

