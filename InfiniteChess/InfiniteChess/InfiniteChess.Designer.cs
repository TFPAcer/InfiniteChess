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
            this.stateLabel = new System.Windows.Forms.Label();
            this.boardPanel = new InfiniteChess.Chess.GameContainer();
            this.history = new InfiniteChess.Chess.MoveHistory();
            this.undo1 = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu_game = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_game_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_game_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_game_undo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_game_undo2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_game_forfeit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_game_sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_game_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_ui = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_ui_hist = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_ui_capt = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_ui_move = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_window_res = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_res_720 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_window_res_1080 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_ai = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_opp = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_opp_human = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_opp_ai = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_setting_scroll = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_scroll = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_scroll_up = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_scroll_down = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_scroll_left = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_scroll_right = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_mult = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_mult_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_mult_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_mult_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_setting_scroll_mult_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_setting_undo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help_chess = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help_ichess = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_help_app = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_about = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_about_about = new System.Windows.Forms.ToolStripMenuItem();
            this.AIThread = new System.ComponentModel.BackgroundWorker();
            this.undo2 = new System.Windows.Forms.Button();
            this.valueLabel = new System.Windows.Forms.Label();
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
            this.debug2.ForeColor = System.Drawing.Color.Black;
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
            // stateLabel
            // 
            this.stateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stateLabel.AutoSize = true;
            this.stateLabel.BackColor = System.Drawing.SystemColors.Control;
            this.stateLabel.Font = new System.Drawing.Font("Perpetua", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.ForeColor = System.Drawing.Color.Black;
            this.stateLabel.Location = new System.Drawing.Point(806, 2);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(0, 20);
            this.stateLabel.TabIndex = 7;
            this.stateLabel.Click += new System.EventHandler(this.debug3_Click);
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
            // undo1
            // 
            this.undo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.undo1.BackColor = System.Drawing.Color.Silver;
            this.undo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undo1.Location = new System.Drawing.Point(941, 342);
            this.undo1.Name = "undo1";
            this.undo1.Size = new System.Drawing.Size(75, 23);
            this.undo1.TabIndex = 9;
            this.undo1.Text = "Undo Ply";
            this.undo1.UseVisualStyleBackColor = false;
            this.undo1.Click += new System.EventHandler(this.undo_Click);
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
            this.menu_game_undo2,
            this.menu_game_forfeit,
            this.menu_game_sep2,
            this.menu_game_exit});
            this.menu_game.Image = ((System.Drawing.Image)(resources.GetObject("menu_game.Image")));
            this.menu_game.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_game.Name = "menu_game";
            this.menu_game.Size = new System.Drawing.Size(66, 20);
            this.menu_game.Text = "Game";
            // 
            // menu_game_new
            // 
            this.menu_game_new.Image = ((System.Drawing.Image)(resources.GetObject("menu_game_new.Image")));
            this.menu_game_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_game_new.Name = "menu_game_new";
            this.menu_game_new.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menu_game_new.Size = new System.Drawing.Size(195, 22);
            this.menu_game_new.Text = "New Game";
            this.menu_game_new.Click += new System.EventHandler(this.menu_game_new_Click);
            // 
            // menu_game_sep1
            // 
            this.menu_game_sep1.Name = "menu_game_sep1";
            this.menu_game_sep1.Size = new System.Drawing.Size(192, 6);
            // 
            // menu_game_undo
            // 
            this.menu_game_undo.Image = ((System.Drawing.Image)(resources.GetObject("menu_game_undo.Image")));
            this.menu_game_undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_game_undo.Name = "menu_game_undo";
            this.menu_game_undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.menu_game_undo.Size = new System.Drawing.Size(195, 22);
            this.menu_game_undo.Text = "Undo Move";
            this.menu_game_undo.Click += new System.EventHandler(this.menu_game_undo_Click);
            // 
            // menu_game_undo2
            // 
            this.menu_game_undo2.Image = ((System.Drawing.Image)(resources.GetObject("menu_game_undo2.Image")));
            this.menu_game_undo2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_game_undo2.Name = "menu_game_undo2";
            this.menu_game_undo2.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.menu_game_undo2.Size = new System.Drawing.Size(195, 22);
            this.menu_game_undo2.Text = "Undo Ply";
            this.menu_game_undo2.Click += new System.EventHandler(this.menu_game_undo2_Click);
            // 
            // menu_game_forfeit
            // 
            this.menu_game_forfeit.Image = ((System.Drawing.Image)(resources.GetObject("menu_game_forfeit.Image")));
            this.menu_game_forfeit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_game_forfeit.Name = "menu_game_forfeit";
            this.menu_game_forfeit.Size = new System.Drawing.Size(195, 22);
            this.menu_game_forfeit.Text = "Forfeit Game";
            this.menu_game_forfeit.Click += new System.EventHandler(this.menu_game_forfeit_Click);
            // 
            // menu_game_sep2
            // 
            this.menu_game_sep2.Name = "menu_game_sep2";
            this.menu_game_sep2.Size = new System.Drawing.Size(192, 6);
            // 
            // menu_game_exit
            // 
            this.menu_game_exit.Image = ((System.Drawing.Image)(resources.GetObject("menu_game_exit.Image")));
            this.menu_game_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_game_exit.Name = "menu_game_exit";
            this.menu_game_exit.Size = new System.Drawing.Size(195, 22);
            this.menu_game_exit.Text = "Exit";
            this.menu_game_exit.Click += new System.EventHandler(this.menu_game_exit_Click);
            // 
            // menu_window
            // 
            this.menu_window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_window_ui,
            this.menu_window_sep1,
            this.menu_window_res});
            this.menu_window.Image = ((System.Drawing.Image)(resources.GetObject("menu_window.Image")));
            this.menu_window.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_window.Name = "menu_window";
            this.menu_window.Size = new System.Drawing.Size(79, 20);
            this.menu_window.Text = "Window";
            // 
            // menu_window_ui
            // 
            this.menu_window_ui.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_window_ui_hist,
            this.menu_window_ui_capt,
            this.menu_window_ui_move});
            this.menu_window_ui.Image = ((System.Drawing.Image)(resources.GetObject("menu_window_ui.Image")));
            this.menu_window_ui.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_window_ui.Name = "menu_window_ui";
            this.menu_window_ui.Size = new System.Drawing.Size(174, 22);
            this.menu_window_ui.Text = "UI Features";
            // 
            // menu_window_ui_hist
            // 
            this.menu_window_ui_hist.Checked = true;
            this.menu_window_ui_hist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu_window_ui_hist.Image = ((System.Drawing.Image)(resources.GetObject("menu_window_ui_hist.Image")));
            this.menu_window_ui_hist.Name = "menu_window_ui_hist";
            this.menu_window_ui_hist.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.menu_window_ui_hist.Size = new System.Drawing.Size(264, 22);
            this.menu_window_ui_hist.Text = "Move History";
            this.menu_window_ui_hist.Click += new System.EventHandler(this.menu_window_ui_hist_Click);
            // 
            // menu_window_ui_capt
            // 
            this.menu_window_ui_capt.Checked = true;
            this.menu_window_ui_capt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu_window_ui_capt.Enabled = false;
            this.menu_window_ui_capt.Image = ((System.Drawing.Image)(resources.GetObject("menu_window_ui_capt.Image")));
            this.menu_window_ui_capt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_window_ui_capt.Name = "menu_window_ui_capt";
            this.menu_window_ui_capt.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.menu_window_ui_capt.Size = new System.Drawing.Size(264, 22);
            this.menu_window_ui_capt.Text = "Capture Indicators";
            // 
            // menu_window_ui_move
            // 
            this.menu_window_ui_move.Checked = true;
            this.menu_window_ui_move.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu_window_ui_move.Image = ((System.Drawing.Image)(resources.GetObject("menu_window_ui_move.Image")));
            this.menu_window_ui_move.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_window_ui_move.Name = "menu_window_ui_move";
            this.menu_window_ui_move.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.menu_window_ui_move.Size = new System.Drawing.Size(264, 22);
            this.menu_window_ui_move.Text = "Movement Indicators";
            this.menu_window_ui_move.Click += new System.EventHandler(this.menu_window_ui_move_Click);
            // 
            // menu_window_sep1
            // 
            this.menu_window_sep1.Name = "menu_window_sep1";
            this.menu_window_sep1.Size = new System.Drawing.Size(171, 6);
            // 
            // menu_window_res
            // 
            this.menu_window_res.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_window_res_720,
            this.menu_window_res_1080});
            this.menu_window_res.Image = ((System.Drawing.Image)(resources.GetObject("menu_window_res.Image")));
            this.menu_window_res.Name = "menu_window_res";
            this.menu_window_res.Size = new System.Drawing.Size(174, 22);
            this.menu_window_res.Text = "Change Resolution";
            // 
            // menu_window_res_720
            // 
            this.menu_window_res_720.Checked = true;
            this.menu_window_res_720.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu_window_res_720.Name = "menu_window_res_720";
            this.menu_window_res_720.Size = new System.Drawing.Size(105, 22);
            this.menu_window_res_720.Text = "720p";
            // 
            // menu_window_res_1080
            // 
            this.menu_window_res_1080.Enabled = false;
            this.menu_window_res_1080.Name = "menu_window_res_1080";
            this.menu_window_res_1080.Size = new System.Drawing.Size(105, 22);
            this.menu_window_res_1080.Text = "1080p";
            // 
            // menu_settings
            // 
            this.menu_settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_setting_ai,
            this.menu_setting_opp,
            this.menu_setting_sep1,
            this.menu_setting_scroll,
            this.toolStripSeparator1,
            this.menu_setting_undo});
            this.menu_settings.Image = ((System.Drawing.Image)(resources.GetObject("menu_settings.Image")));
            this.menu_settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_settings.Name = "menu_settings";
            this.menu_settings.Size = new System.Drawing.Size(77, 20);
            this.menu_settings.Text = "Settings";
            // 
            // menu_setting_ai
            // 
            this.menu_setting_ai.Image = ((System.Drawing.Image)(resources.GetObject("menu_setting_ai.Image")));
            this.menu_setting_ai.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_setting_ai.Name = "menu_setting_ai";
            this.menu_setting_ai.Size = new System.Drawing.Size(183, 22);
            this.menu_setting_ai.Text = "AI Difficulty...";
            this.menu_setting_ai.Click += new System.EventHandler(this.menu_setting_ai_Click);
            // 
            // menu_setting_opp
            // 
            this.menu_setting_opp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_setting_opp_human,
            this.menu_setting_opp_ai});
            this.menu_setting_opp.Image = ((System.Drawing.Image)(resources.GetObject("menu_setting_opp.Image")));
            this.menu_setting_opp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_setting_opp.Name = "menu_setting_opp";
            this.menu_setting_opp.Size = new System.Drawing.Size(183, 22);
            this.menu_setting_opp.Text = "Opponent..";
            // 
            // menu_setting_opp_human
            // 
            this.menu_setting_opp_human.Checked = true;
            this.menu_setting_opp_human.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu_setting_opp_human.Image = ((System.Drawing.Image)(resources.GetObject("menu_setting_opp_human.Image")));
            this.menu_setting_opp_human.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_setting_opp_human.Name = "menu_setting_opp_human";
            this.menu_setting_opp_human.Size = new System.Drawing.Size(114, 22);
            this.menu_setting_opp_human.Text = "Human";
            this.menu_setting_opp_human.Click += new System.EventHandler(this.menu_setting_opp_human_Click);
            // 
            // menu_setting_opp_ai
            // 
            this.menu_setting_opp_ai.Image = ((System.Drawing.Image)(resources.GetObject("menu_setting_opp_ai.Image")));
            this.menu_setting_opp_ai.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_setting_opp_ai.Name = "menu_setting_opp_ai";
            this.menu_setting_opp_ai.Size = new System.Drawing.Size(114, 22);
            this.menu_setting_opp_ai.Text = "AI";
            this.menu_setting_opp_ai.Click += new System.EventHandler(this.menu_setting_opp_ai_Click);
            // 
            // menu_setting_sep1
            // 
            this.menu_setting_sep1.Name = "menu_setting_sep1";
            this.menu_setting_sep1.Size = new System.Drawing.Size(180, 6);
            // 
            // menu_setting_scroll
            // 
            this.menu_setting_scroll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_setting_scroll_scroll,
            this.menu_setting_scroll_mult});
            this.menu_setting_scroll.Image = ((System.Drawing.Image)(resources.GetObject("menu_setting_scroll.Image")));
            this.menu_setting_scroll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_setting_scroll.Name = "menu_setting_scroll";
            this.menu_setting_scroll.Size = new System.Drawing.Size(183, 22);
            this.menu_setting_scroll.Text = "Scrolling";
            // 
            // menu_setting_scroll_scroll
            // 
            this.menu_setting_scroll_scroll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_setting_scroll_scroll_up,
            this.menu_setting_scroll_scroll_down,
            this.menu_setting_scroll_scroll_left,
            this.menu_setting_scroll_scroll_right});
            this.menu_setting_scroll_scroll.Name = "menu_setting_scroll_scroll";
            this.menu_setting_scroll_scroll.Size = new System.Drawing.Size(125, 22);
            this.menu_setting_scroll_scroll.Text = "Scroll";
            // 
            // menu_setting_scroll_scroll_up
            // 
            this.menu_setting_scroll_scroll_up.Name = "menu_setting_scroll_scroll_up";
            this.menu_setting_scroll_scroll_up.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.menu_setting_scroll_scroll_up.Size = new System.Drawing.Size(170, 22);
            this.menu_setting_scroll_scroll_up.Text = "Up";
            this.menu_setting_scroll_scroll_up.Click += new System.EventHandler(this.menu_setting_scroll_scroll_up_Click);
            // 
            // menu_setting_scroll_scroll_down
            // 
            this.menu_setting_scroll_scroll_down.Name = "menu_setting_scroll_scroll_down";
            this.menu_setting_scroll_scroll_down.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.menu_setting_scroll_scroll_down.Size = new System.Drawing.Size(170, 22);
            this.menu_setting_scroll_scroll_down.Text = "Down";
            this.menu_setting_scroll_scroll_down.Click += new System.EventHandler(this.menu_setting_scroll_scroll_down_Click);
            // 
            // menu_setting_scroll_scroll_left
            // 
            this.menu_setting_scroll_scroll_left.Name = "menu_setting_scroll_scroll_left";
            this.menu_setting_scroll_scroll_left.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.menu_setting_scroll_scroll_left.Size = new System.Drawing.Size(170, 22);
            this.menu_setting_scroll_scroll_left.Text = "Left";
            this.menu_setting_scroll_scroll_left.Click += new System.EventHandler(this.menu_setting_scroll_scroll_left_Click);
            // 
            // menu_setting_scroll_scroll_right
            // 
            this.menu_setting_scroll_scroll_right.Name = "menu_setting_scroll_scroll_right";
            this.menu_setting_scroll_scroll_right.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.menu_setting_scroll_scroll_right.Size = new System.Drawing.Size(170, 22);
            this.menu_setting_scroll_scroll_right.Text = "Right";
            this.menu_setting_scroll_scroll_right.Click += new System.EventHandler(this.menu_setting_scroll_scroll_right_Click);
            // 
            // menu_setting_scroll_mult
            // 
            this.menu_setting_scroll_mult.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_setting_scroll_mult_1,
            this.menu_setting_scroll_mult_2,
            this.menu_setting_scroll_mult_3,
            this.menu_setting_scroll_mult_4});
            this.menu_setting_scroll_mult.Name = "menu_setting_scroll_mult";
            this.menu_setting_scroll_mult.Size = new System.Drawing.Size(125, 22);
            this.menu_setting_scroll_mult.Text = "Multiplier";
            // 
            // menu_setting_scroll_mult_1
            // 
            this.menu_setting_scroll_mult_1.Checked = true;
            this.menu_setting_scroll_mult_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu_setting_scroll_mult_1.Name = "menu_setting_scroll_mult_1";
            this.menu_setting_scroll_mult_1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menu_setting_scroll_mult_1.Size = new System.Drawing.Size(104, 22);
            this.menu_setting_scroll_mult_1.Text = "1x";
            this.menu_setting_scroll_mult_1.Click += new System.EventHandler(this.menu_setting_scroll_mult_1_Click);
            // 
            // menu_setting_scroll_mult_2
            // 
            this.menu_setting_scroll_mult_2.Name = "menu_setting_scroll_mult_2";
            this.menu_setting_scroll_mult_2.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menu_setting_scroll_mult_2.Size = new System.Drawing.Size(104, 22);
            this.menu_setting_scroll_mult_2.Text = "2x";
            this.menu_setting_scroll_mult_2.Click += new System.EventHandler(this.menu_setting_scroll_mult_2_Click);
            // 
            // menu_setting_scroll_mult_3
            // 
            this.menu_setting_scroll_mult_3.Name = "menu_setting_scroll_mult_3";
            this.menu_setting_scroll_mult_3.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menu_setting_scroll_mult_3.Size = new System.Drawing.Size(104, 22);
            this.menu_setting_scroll_mult_3.Text = "3x";
            this.menu_setting_scroll_mult_3.Click += new System.EventHandler(this.menu_setting_scroll_mult_3_Click);
            // 
            // menu_setting_scroll_mult_4
            // 
            this.menu_setting_scroll_mult_4.Name = "menu_setting_scroll_mult_4";
            this.menu_setting_scroll_mult_4.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menu_setting_scroll_mult_4.Size = new System.Drawing.Size(104, 22);
            this.menu_setting_scroll_mult_4.Tag = "";
            this.menu_setting_scroll_mult_4.Text = "4x";
            this.menu_setting_scroll_mult_4.Click += new System.EventHandler(this.menu_setting_scroll_mult_4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // menu_setting_undo
            // 
            this.menu_setting_undo.Image = ((System.Drawing.Image)(resources.GetObject("menu_setting_undo.Image")));
            this.menu_setting_undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_setting_undo.Name = "menu_setting_undo";
            this.menu_setting_undo.Size = new System.Drawing.Size(183, 22);
            this.menu_setting_undo.Text = "Disable Undo Button";
            this.menu_setting_undo.Click += new System.EventHandler(this.menu_setting_undo_Click);
            // 
            // menu_help
            // 
            this.menu_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_help_chess,
            this.menu_help_ichess,
            this.menu_help_sep1,
            this.menu_help_app});
            this.menu_help.Image = ((System.Drawing.Image)(resources.GetObject("menu_help.Image")));
            this.menu_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_help.Name = "menu_help";
            this.menu_help.Size = new System.Drawing.Size(60, 20);
            this.menu_help.Text = "Help";
            // 
            // menu_help_chess
            // 
            this.menu_help_chess.Enabled = false;
            this.menu_help_chess.Image = ((System.Drawing.Image)(resources.GetObject("menu_help_chess.Image")));
            this.menu_help_chess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_help_chess.Name = "menu_help_chess";
            this.menu_help_chess.Size = new System.Drawing.Size(211, 22);
            this.menu_help_chess.Text = "Chess Help...";
            // 
            // menu_help_ichess
            // 
            this.menu_help_ichess.Enabled = false;
            this.menu_help_ichess.Image = ((System.Drawing.Image)(resources.GetObject("menu_help_ichess.Image")));
            this.menu_help_ichess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_help_ichess.Name = "menu_help_ichess";
            this.menu_help_ichess.Size = new System.Drawing.Size(211, 22);
            this.menu_help_ichess.Text = "Infinite Chess Help...";
            // 
            // menu_help_sep1
            // 
            this.menu_help_sep1.Name = "menu_help_sep1";
            this.menu_help_sep1.Size = new System.Drawing.Size(208, 6);
            // 
            // menu_help_app
            // 
            this.menu_help_app.Enabled = false;
            this.menu_help_app.Image = ((System.Drawing.Image)(resources.GetObject("menu_help_app.Image")));
            this.menu_help_app.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_help_app.Name = "menu_help_app";
            this.menu_help_app.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.menu_help_app.Size = new System.Drawing.Size(211, 22);
            this.menu_help_app.Text = "Application Help...";
            // 
            // menu_about
            // 
            this.menu_about.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_about_about});
            this.menu_about.Image = ((System.Drawing.Image)(resources.GetObject("menu_about.Image")));
            this.menu_about.Name = "menu_about";
            this.menu_about.Size = new System.Drawing.Size(68, 20);
            this.menu_about.Text = "About";
            // 
            // menu_about_about
            // 
            this.menu_about_about.Enabled = false;
            this.menu_about_about.Image = ((System.Drawing.Image)(resources.GetObject("menu_about_about.Image")));
            this.menu_about_about.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_about_about.Name = "menu_about_about";
            this.menu_about_about.Size = new System.Drawing.Size(184, 22);
            this.menu_about_about.Text = "About InfinteChess...";
            // 
            // AIThread
            // 
            this.AIThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AIThread_DoWork);
            this.AIThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AIThread_RunWorkCompleted);
            // 
            // undo2
            // 
            this.undo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.undo2.BackColor = System.Drawing.Color.Silver;
            this.undo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undo2.Location = new System.Drawing.Point(810, 342);
            this.undo2.Name = "undo2";
            this.undo2.Size = new System.Drawing.Size(75, 23);
            this.undo2.TabIndex = 12;
            this.undo2.Text = "Undo Move";
            this.undo2.UseVisualStyleBackColor = false;
            this.undo2.Click += new System.EventHandler(this.undo2_Click);
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.ForeColor = System.Drawing.Color.Black;
            this.valueLabel.Location = new System.Drawing.Point(684, 90);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(37, 13);
            this.valueLabel.TabIndex = 13;
            this.valueLabel.Text = "debug";
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1028, 681);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.undo2);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.undo1);
            this.Controls.Add(this.history);
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
        private System.Windows.Forms.Label stateLabel;
        private MoveHistory history;
        private System.Windows.Forms.Button undo1;
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
        private System.Windows.Forms.ToolStripMenuItem menu_setting_opp_human;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_opp_ai;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_scroll;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_scroll_up;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_scroll_down;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_scroll_left;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_scroll_right;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_mult;
        private System.Windows.Forms.ToolStripMenuItem menu_about_about;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_undo;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_mult_1;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_mult_2;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_mult_3;
        private System.Windows.Forms.ToolStripMenuItem menu_setting_scroll_mult_4;
        private System.ComponentModel.BackgroundWorker AIThread;
        private System.Windows.Forms.Button undo2;
        private System.Windows.Forms.ToolStripMenuItem menu_game_undo2;
        private System.Windows.Forms.Label valueLabel;
    }
}

