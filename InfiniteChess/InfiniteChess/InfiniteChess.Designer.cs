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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chess));
            this.begin = new System.Windows.Forms.Button();
            this.debug2 = new System.Windows.Forms.Label();
            this.sUp = new System.Windows.Forms.Button();
            this.sDown = new System.Windows.Forms.Button();
            this.sLeft = new System.Windows.Forms.Button();
            this.sRight = new System.Windows.Forms.Button();
            this.debug3 = new System.Windows.Forms.Label();
            this.boardPanel = new InfiniteChess.Chess.GameContainer();
            this.history = new InfiniteChess.Chess.MoveHistory();
            this.undo = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu_game = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_game_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_game_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_game_undo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_game_sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_game_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_about = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_game_forfeit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_res = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_res_720 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_ai = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_opp = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help_chess = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help_ichess = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help_app = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_res_1080 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_ui = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_ui_hist = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_ui_capt = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_ui_move = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_setting_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_help_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // begin
            // 
            this.begin.Location = new System.Drawing.Point(668, 41);
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
            this.debug2.ForeColor = System.Drawing.Color.White;
            this.debug2.Location = new System.Drawing.Point(684, 67);
            this.debug2.Name = "debug2";
            this.debug2.Size = new System.Drawing.Size(37, 13);
            this.debug2.TabIndex = 2;
            this.debug2.Text = "debug";
            // 
            // sUp
            // 
            this.sUp.BackColor = System.Drawing.Color.Silver;
            this.sUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.sUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sUp.Location = new System.Drawing.Point(626, 33);
            this.sUp.Name = "sUp";
            this.sUp.Size = new System.Drawing.Size(22, 22);
            this.sUp.TabIndex = 3;
            this.sUp.Text = "↑";
            this.sUp.UseVisualStyleBackColor = false;
            this.sUp.Click += new System.EventHandler(this.sUp_Click);
            // 
            // sDown
            // 
            this.sDown.BackColor = System.Drawing.Color.Silver;
            this.sDown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.sDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sDown.Location = new System.Drawing.Point(626, 619);
            this.sDown.Name = "sDown";
            this.sDown.Size = new System.Drawing.Size(22, 22);
            this.sDown.TabIndex = 4;
            this.sDown.Text = "↓";
            this.sDown.UseVisualStyleBackColor = false;
            this.sDown.Click += new System.EventHandler(this.sDown_Click);
            // 
            // sLeft
            // 
            this.sLeft.BackColor = System.Drawing.Color.Silver;
            this.sLeft.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.sLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLeft.Location = new System.Drawing.Point(12, 647);
            this.sLeft.Name = "sLeft";
            this.sLeft.Size = new System.Drawing.Size(22, 22);
            this.sLeft.TabIndex = 5;
            this.sLeft.Text = "←";
            this.sLeft.UseVisualStyleBackColor = false;
            this.sLeft.Click += new System.EventHandler(this.sLeft_Click);
            // 
            // sRight
            // 
            this.sRight.BackColor = System.Drawing.Color.Silver;
            this.sRight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.sRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sRight.Location = new System.Drawing.Point(598, 647);
            this.sRight.Name = "sRight";
            this.sRight.Size = new System.Drawing.Size(22, 22);
            this.sRight.TabIndex = 6;
            this.sRight.Text = "→";
            this.sRight.UseVisualStyleBackColor = false;
            this.sRight.Click += new System.EventHandler(this.sRight_Click);
            // 
            // debug3
            // 
            this.debug3.AutoSize = true;
            this.debug3.ForeColor = System.Drawing.Color.White;
            this.debug3.Location = new System.Drawing.Point(684, 91);
            this.debug3.Name = "debug3";
            this.debug3.Size = new System.Drawing.Size(63, 13);
            this.debug3.TabIndex = 7;
            this.debug3.Text = "White\'s turn";
            this.debug3.Click += new System.EventHandler(this.debug3_Click);
            // 
            // boardPanel
            // 
            this.boardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boardPanel.Location = new System.Drawing.Point(12, 33);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(608, 608);
            this.boardPanel.TabIndex = 0;
            // 
            // history
            // 
            this.history.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.history.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.history.Cursor = System.Windows.Forms.Cursors.Default;
            this.history.Font = new System.Drawing.Font("Perpetua", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.history.Location = new System.Drawing.Point(668, 371);
            this.history.MaxLength = 65535;
            this.history.Multiline = true;
            this.history.Name = "history";
            this.history.ReadOnly = true;
            this.history.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.history.ShortcutsEnabled = false;
            this.history.Size = new System.Drawing.Size(348, 223);
            this.history.TabIndex = 8;
            this.history.WordWrap = false;
            // 
            // undo
            // 
            this.undo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.undo.BackColor = System.Drawing.Color.Silver;
            this.undo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undo.Location = new System.Drawing.Point(941, 342);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(75, 23);
            this.undo.TabIndex = 9;
            this.undo.Text = "Undo";
            this.undo.UseVisualStyleBackColor = false;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_game,
            this.menu_window,
            this.menu_settings,
            this.menu_help,
            this.menu_about});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1028, 24);
            this.menu.TabIndex = 11;
            // 
            // menu_game
            // 
            this.menu_game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_game_new,
            this.menu_game_sep1,
            this.menu_game_undo,
            this.menu_game_forfeit,
            this.menu_game_sep2,
            this.menu_game_exit});
            this.menu_game.Name = "menu_game";
            this.menu_game.Size = new System.Drawing.Size(50, 20);
            this.menu_game.Text = "Game";
            // 
            // menu_game_sep1
            // 
            this.menu_game_sep1.Name = "menu_game_sep1";
            this.menu_game_sep1.Size = new System.Drawing.Size(139, 6);
            // 
            // menu_game_new
            // 
            this.menu_game_new.Name = "menu_game_new";
            this.menu_game_new.Size = new System.Drawing.Size(142, 22);
            this.menu_game_new.Text = "New Game";
            // 
            // menu_game_undo
            // 
            this.menu_game_undo.Name = "menu_game_undo";
            this.menu_game_undo.Size = new System.Drawing.Size(142, 22);
            this.menu_game_undo.Text = "Undo Move";
            // 
            // menu_game_sep2
            // 
            this.menu_game_sep2.Name = "menu_game_sep2";
            this.menu_game_sep2.Size = new System.Drawing.Size(139, 6);
            // 
            // menu_game_exit
            // 
            this.menu_game_exit.Name = "menu_game_exit";
            this.menu_game_exit.Size = new System.Drawing.Size(142, 22);
            this.menu_game_exit.Text = "Exit";
            // 
            // menu_window
            // 
            this.menu_window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_window_res,
            this.menu_window_sep1,
            this.menu_window_ui});
            this.menu_window.Name = "menu_window";
            this.menu_window.Size = new System.Drawing.Size(63, 20);
            this.menu_window.Text = "Window";
            // 
            // menu_settings
            // 
            this.menu_settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_setting_ai,
            this.menu_setting_opp,
            this.menu_setting_sep1,
            this.menu_setting_scroll});
            this.menu_settings.Name = "menu_settings";
            this.menu_settings.Size = new System.Drawing.Size(61, 20);
            this.menu_settings.Text = "Settings";
            // 
            // menu_help
            // 
            this.menu_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_help_chess,
            this.menu_help_ichess,
            this.menu_help_sep1,
            this.menu_help_app});
            this.menu_help.Name = "menu_help";
            this.menu_help.Size = new System.Drawing.Size(44, 20);
            this.menu_help.Text = "Help";
            // 
            // menu_about
            // 
            this.menu_about.Name = "menu_about";
            this.menu_about.Size = new System.Drawing.Size(58, 20);
            this.menu_about.Text = "About..";
            // 
            // menu_game_forfeit
            // 
            this.menu_game_forfeit.Name = "menu_game_forfeit";
            this.menu_game_forfeit.Size = new System.Drawing.Size(142, 22);
            this.menu_game_forfeit.Text = "Forfeit Game";
            // 
            // menu_window_res
            // 
            this.menu_window_res.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_window_res_720,
            this.menu_window_res_1080});
            this.menu_window_res.Name = "menu_window_res";
            this.menu_window_res.Size = new System.Drawing.Size(174, 22);
            this.menu_window_res.Text = "Change Resolution";
            // 
            // menu_window_res_720
            // 
            this.menu_window_res_720.Name = "menu_window_res_720";
            this.menu_window_res_720.Size = new System.Drawing.Size(105, 22);
            this.menu_window_res_720.Text = "720p";
            // 
            // menu_setting_ai
            // 
            this.menu_setting_ai.Name = "menu_setting_ai";
            this.menu_setting_ai.Size = new System.Drawing.Size(142, 22);
            this.menu_setting_ai.Text = "AI Difficulty..";
            // 
            // menu_setting_opp
            // 
            this.menu_setting_opp.Name = "menu_setting_opp";
            this.menu_setting_opp.Size = new System.Drawing.Size(142, 22);
            this.menu_setting_opp.Text = "Opponent..";
            // 
            // menu_setting_scroll
            // 
            this.menu_setting_scroll.Name = "menu_setting_scroll";
            this.menu_setting_scroll.Size = new System.Drawing.Size(142, 22);
            this.menu_setting_scroll.Text = "Scrolling..";
            // 
            // menu_help_chess
            // 
            this.menu_help_chess.Name = "menu_help_chess";
            this.menu_help_chess.Size = new System.Drawing.Size(179, 22);
            this.menu_help_chess.Text = "Chess Help..";
            // 
            // menu_help_ichess
            // 
            this.menu_help_ichess.Name = "menu_help_ichess";
            this.menu_help_ichess.Size = new System.Drawing.Size(179, 22);
            this.menu_help_ichess.Text = "Infinite Chess Help..";
            // 
            // menu_help_app
            // 
            this.menu_help_app.Name = "menu_help_app";
            this.menu_help_app.Size = new System.Drawing.Size(179, 22);
            this.menu_help_app.Text = "Application Help";
            // 
            // menu_window_res_1080
            // 
            this.menu_window_res_1080.Name = "menu_window_res_1080";
            this.menu_window_res_1080.Size = new System.Drawing.Size(105, 22);
            this.menu_window_res_1080.Text = "1080p";
            // 
            // menu_window_ui
            // 
            this.menu_window_ui.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_window_ui_hist,
            this.menu_window_ui_capt,
            this.menu_window_ui_move});
            this.menu_window_ui.Name = "menu_window_ui";
            this.menu_window_ui.Size = new System.Drawing.Size(174, 22);
            this.menu_window_ui.Text = "UI Features";
            // 
            // menu_window_ui_hist
            // 
            this.menu_window_ui_hist.Name = "menu_window_ui_hist";
            this.menu_window_ui_hist.Size = new System.Drawing.Size(187, 22);
            this.menu_window_ui_hist.Text = "Move History";
            // 
            // menu_window_ui_capt
            // 
            this.menu_window_ui_capt.Name = "menu_window_ui_capt";
            this.menu_window_ui_capt.Size = new System.Drawing.Size(187, 22);
            this.menu_window_ui_capt.Text = "Capture Indicators";
            // 
            // menu_window_ui_move
            // 
            this.menu_window_ui_move.Name = "menu_window_ui_move";
            this.menu_window_ui_move.Size = new System.Drawing.Size(187, 22);
            this.menu_window_ui_move.Text = "Movement Indicators";
            // 
            // menu_window_sep1
            // 
            this.menu_window_sep1.Name = "menu_window_sep1";
            this.menu_window_sep1.Size = new System.Drawing.Size(171, 6);
            // 
            // menu_setting_sep1
            // 
            this.menu_setting_sep1.Name = "menu_setting_sep1";
            this.menu_setting_sep1.Size = new System.Drawing.Size(6, 6);
            // 
            // menu_help_sep1
            // 
            this.menu_help_sep1.Name = "menu_help_sep1";
            this.menu_help_sep1.Size = new System.Drawing.Size(6, 6);
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1028, 681);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.undo);
            this.Controls.Add(this.history);
            this.Controls.Add(this.debug3);
            this.Controls.Add(this.sRight);
            this.Controls.Add(this.sLeft);
            this.Controls.Add(this.sDown);
            this.Controls.Add(this.sUp);
            this.Controls.Add(this.debug2);
            this.Controls.Add(this.begin);
            this.Controls.Add(this.boardPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Chess";
            this.Text = "InfiniteChess";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GameContainer boardPanel;
        private System.Windows.Forms.Button begin;
        private System.Windows.Forms.Label debug2;
        private System.Windows.Forms.Button sUp;
        private System.Windows.Forms.Button sDown;
        private System.Windows.Forms.Button sLeft;
        private System.Windows.Forms.Button sRight;
        private System.Windows.Forms.Label debug3;
        private MoveHistory history;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menu_game;
        private System.Windows.Forms.ToolStripMenuItem menu_window;
        private System.Windows.Forms.ToolStripMenuItem menu_settings;
        private System.Windows.Forms.ToolStripMenuItem menu_help;
        private System.Windows.Forms.ToolStripMenuItem menu_about;
        private System.Windows.Forms.ToolStripSeparator menu_game_sep1;
        private System.Windows.Forms.ToolStripMenuItem menu_game_new;
        private System.Windows.Forms.ToolStripMenuItem menu_game_undo;
        private System.Windows.Forms.ToolStripSeparator menu_game_sep2;
        private System.Windows.Forms.ToolStripMenuItem menu_game_exit;
        private System.Windows.Forms.ToolStripMenuItem menu_game_forfeit;
        private System.Windows.Forms.ToolStripMenuItem menu_window_res;
        private System.Windows.Forms.ToolStripMenuItem menu_window_res_720;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_ai;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_opp;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll;
        private System.Windows.Forms.ToolStripMenuItem menu_help_chess;
        private System.Windows.Forms.ToolStripMenuItem menu_help_ichess;
        private System.Windows.Forms.ToolStripMenuItem menu_help_app;
        private System.Windows.Forms.ToolStripMenuItem menu_window_res_1080;
        private System.Windows.Forms.ToolStripMenuItem menu_window_ui;
        private System.Windows.Forms.ToolStripMenuItem menu_window_ui_hist;
        private System.Windows.Forms.ToolStripMenuItem menu_window_ui_capt;
        private System.Windows.Forms.ToolStripMenuItem menu_window_ui_move;
        private System.Windows.Forms.ToolStripSeparator menu_window_sep1;
        private System.Windows.Forms.ToolStripSeparator menu_setting_sep1;
        private System.Windows.Forms.ToolStripSeparator menu_help_sep1;
    }
}

