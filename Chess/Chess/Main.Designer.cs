namespace Chess
{
    partial class chessWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chessWin));
            this.cursorPosition = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.v_U = new System.Windows.Forms.Button();
            this.v_D = new System.Windows.Forms.Button();
            this.h_R = new System.Windows.Forms.Button();
            this.h_L = new System.Windows.Forms.Button();
            this.boardPanel = new Chess.GameContainer();
            this.v_U2 = new System.Windows.Forms.Button();
            this.v_D2 = new System.Windows.Forms.Button();
            this.h_R2 = new System.Windows.Forms.Button();
            this.h_L2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.draw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cursorPosition
            // 
            this.cursorPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorPosition.AutoSize = true;
            this.cursorPosition.BackColor = System.Drawing.Color.Transparent;
            this.cursorPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cursorPosition.ForeColor = System.Drawing.Color.Silver;
            this.cursorPosition.Location = new System.Drawing.Point(746, 32);
            this.cursorPosition.Name = "cursorPosition";
            this.cursorPosition.Size = new System.Drawing.Size(51, 16);
            this.cursorPosition.TabIndex = 2;
            this.cursorPosition.Text = "label1";
            this.cursorPosition.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(746, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // v_U
            // 
            this.v_U.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.v_U.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.v_U.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v_U.Location = new System.Drawing.Point(813, 12);
            this.v_U.Name = "v_U";
            this.v_U.Size = new System.Drawing.Size(22, 22);
            this.v_U.TabIndex = 4;
            this.v_U.Text = "↑";
            this.v_U.UseVisualStyleBackColor = true;
            this.v_U.Click += new System.EventHandler(this.v_U_Click);
            // 
            // v_D
            // 
            this.v_D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.v_D.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.v_D.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v_D.Location = new System.Drawing.Point(813, 624);
            this.v_D.Name = "v_D";
            this.v_D.Size = new System.Drawing.Size(22, 22);
            this.v_D.TabIndex = 5;
            this.v_D.Text = "↓";
            this.v_D.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.v_D.UseVisualStyleBackColor = true;
            this.v_D.Click += new System.EventHandler(this.v_D_Click);
            // 
            // h_R
            // 
            this.h_R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.h_R.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.h_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.h_R.Location = new System.Drawing.Point(791, 646);
            this.h_R.Name = "h_R";
            this.h_R.Size = new System.Drawing.Size(22, 22);
            this.h_R.TabIndex = 6;
            this.h_R.Text = "→";
            this.h_R.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.h_R.UseVisualStyleBackColor = true;
            this.h_R.Click += new System.EventHandler(this.h_R_Click);
            // 
            // h_L
            // 
            this.h_L.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.h_L.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.h_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.h_L.Location = new System.Drawing.Point(12, 646);
            this.h_L.Name = "h_L";
            this.h_L.Size = new System.Drawing.Size(22, 22);
            this.h_L.TabIndex = 7;
            this.h_L.Text = "←";
            this.h_L.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.h_L.UseVisualStyleBackColor = true;
            this.h_L.Click += new System.EventHandler(this.h_L_Click);
            // 
            // boardPanel
            // 
            this.boardPanel.BackColor = System.Drawing.Color.Transparent;
            this.boardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boardPanel.Location = new System.Drawing.Point(12, 12);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(608, 608);
            this.boardPanel.TabIndex = 8;
            // 
            // v_U2
            // 
            this.v_U2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.v_U2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.v_U2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v_U2.Location = new System.Drawing.Point(813, 40);
            this.v_U2.Name = "v_U2";
            this.v_U2.Size = new System.Drawing.Size(22, 22);
            this.v_U2.TabIndex = 9;
            this.v_U2.Text = "↟";
            this.v_U2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.v_U2.UseVisualStyleBackColor = true;
            this.v_U2.Click += new System.EventHandler(this.v_U_Click);
            // 
            // v_D2
            // 
            this.v_D2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.v_D2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.v_D2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v_D2.Location = new System.Drawing.Point(813, 596);
            this.v_D2.Name = "v_D2";
            this.v_D2.Size = new System.Drawing.Size(22, 22);
            this.v_D2.TabIndex = 10;
            this.v_D2.Text = "↡";
            this.v_D2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.v_D2.UseVisualStyleBackColor = true;
            this.v_D2.Click += new System.EventHandler(this.v_D_Click);
            // 
            // h_R2
            // 
            this.h_R2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.h_R2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.h_R2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.h_R2.Location = new System.Drawing.Point(763, 646);
            this.h_R2.Name = "h_R2";
            this.h_R2.Size = new System.Drawing.Size(22, 22);
            this.h_R2.TabIndex = 11;
            this.h_R2.Text = "↠";
            this.h_R2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.h_R2.UseVisualStyleBackColor = true;
            this.h_R2.Click += new System.EventHandler(this.h_R_Click);
            // 
            // h_L2
            // 
            this.h_L2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.h_L2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.h_L2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.h_L2.Location = new System.Drawing.Point(40, 646);
            this.h_L2.Name = "h_L2";
            this.h_L2.Size = new System.Drawing.Size(22, 22);
            this.h_L2.TabIndex = 12;
            this.h_L2.Text = "↞";
            this.h_L2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.h_L2.UseVisualStyleBackColor = true;
            this.h_L2.Click += new System.EventHandler(this.h_L_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(763, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // draw
            // 
            this.draw.BackColor = System.Drawing.Color.Transparent;
            this.draw.FlatAppearance.BorderSize = 0;
            this.draw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.draw.ForeColor = System.Drawing.Color.Transparent;
            this.draw.Location = new System.Drawing.Point(825, 658);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(10, 10);
            this.draw.TabIndex = 15;
            this.draw.UseVisualStyleBackColor = false;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // chessWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(844, 677);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.h_L2);
            this.Controls.Add(this.h_R2);
            this.Controls.Add(this.v_D2);
            this.Controls.Add(this.v_U2);
            this.Controls.Add(this.h_L);
            this.Controls.Add(this.h_R);
            this.Controls.Add(this.v_D);
            this.Controls.Add(this.v_U);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cursorPosition);
            this.Controls.Add(this.boardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "chessWin";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.chessWin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label cursorPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button v_U;
        private System.Windows.Forms.Button v_D;
        private System.Windows.Forms.Button h_R;
        private System.Windows.Forms.Button h_L;
        private Chess.GameContainer boardPanel;
        private System.Windows.Forms.Button v_U2;
        private System.Windows.Forms.Button v_D2;
        private System.Windows.Forms.Button h_R2;
        private System.Windows.Forms.Button h_L2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button draw;
    }
}

