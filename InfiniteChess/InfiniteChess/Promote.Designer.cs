namespace InfiniteChess
{
    partial class Promote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Promote));
            this.pN = new System.Windows.Forms.Button();
            this.pB = new System.Windows.Forms.Button();
            this.pR = new System.Windows.Forms.Button();
            this.pC = new System.Windows.Forms.Button();
            this.pM = new System.Windows.Forms.Button();
            this.pQ = new System.Windows.Forms.Button();
            this.pH = new System.Windows.Forms.Button();
            this.pP = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pN
            // 
            this.pN.Location = new System.Drawing.Point(33, 63);
            this.pN.Name = "pN";
            this.pN.Size = new System.Drawing.Size(75, 69);
            this.pN.TabIndex = 0;
            this.pN.Text = "Knight";
            this.pN.UseVisualStyleBackColor = true;
            this.pN.Click += new System.EventHandler(this.promoteClick);
            // 
            // pB
            // 
            this.pB.Location = new System.Drawing.Point(257, 63);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(75, 69);
            this.pB.TabIndex = 1;
            this.pB.Text = "Bishop";
            this.pB.UseVisualStyleBackColor = true;
            this.pB.Click += new System.EventHandler(this.promoteClick);
            // 
            // pR
            // 
            this.pR.Location = new System.Drawing.Point(146, 63);
            this.pR.Name = "pR";
            this.pR.Size = new System.Drawing.Size(75, 69);
            this.pR.TabIndex = 2;
            this.pR.Text = "Rook";
            this.pR.UseVisualStyleBackColor = true;
            this.pR.Click += new System.EventHandler(this.promoteClick);
            // 
            // pC
            // 
            this.pC.Location = new System.Drawing.Point(146, 163);
            this.pC.Name = "pC";
            this.pC.Size = new System.Drawing.Size(75, 69);
            this.pC.TabIndex = 3;
            this.pC.Text = "Chancellor";
            this.pC.UseVisualStyleBackColor = true;
            this.pC.Click += new System.EventHandler(this.promoteClick);
            // 
            // pM
            // 
            this.pM.Location = new System.Drawing.Point(366, 63);
            this.pM.Name = "pM";
            this.pM.Size = new System.Drawing.Size(75, 69);
            this.pM.TabIndex = 4;
            this.pM.Text = "Mann";
            this.pM.UseVisualStyleBackColor = true;
            this.pM.Click += new System.EventHandler(this.promoteClick);
            // 
            // pQ
            // 
            this.pQ.Location = new System.Drawing.Point(257, 163);
            this.pQ.Name = "pQ";
            this.pQ.Size = new System.Drawing.Size(75, 69);
            this.pQ.TabIndex = 5;
            this.pQ.Text = "Queen";
            this.pQ.UseVisualStyleBackColor = true;
            this.pQ.Click += new System.EventHandler(this.promoteClick);
            // 
            // pH
            // 
            this.pH.Location = new System.Drawing.Point(33, 163);
            this.pH.Name = "pH";
            this.pH.Size = new System.Drawing.Size(75, 69);
            this.pH.TabIndex = 6;
            this.pH.Text = "Hawk";
            this.pH.UseVisualStyleBackColor = true;
            this.pH.Click += new System.EventHandler(this.promoteClick);
            // 
            // pP
            // 
            this.pP.Location = new System.Drawing.Point(366, 163);
            this.pP.Name = "pP";
            this.pP.Size = new System.Drawing.Size(75, 69);
            this.pP.TabIndex = 7;
            this.pP.Text = "None";
            this.pP.UseVisualStyleBackColor = true;
            this.pP.Click += new System.EventHandler(this.promoteClick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(111, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(232, 14);
            this.label.TabIndex = 8;
            this.label.Text = "Which piece should the pawn promote to?";
            // 
            // Promote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(465, 267);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pP);
            this.Controls.Add(this.pH);
            this.Controls.Add(this.pQ);
            this.Controls.Add(this.pM);
            this.Controls.Add(this.pC);
            this.Controls.Add(this.pR);
            this.Controls.Add(this.pB);
            this.Controls.Add(this.pN);
            this.Font = new System.Drawing.Font("Perpetua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Promote";
            this.Text = "Pawn Promotion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pN;
        private System.Windows.Forms.Button pB;
        private System.Windows.Forms.Button pR;
        private System.Windows.Forms.Button pC;
        private System.Windows.Forms.Button pM;
        private System.Windows.Forms.Button pQ;
        private System.Windows.Forms.Button pH;
        private System.Windows.Forms.Button pP;
        private System.Windows.Forms.Label label;
    }
}