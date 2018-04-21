using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Drawing;

namespace InfiniteChess
{
    public partial class Chess : Form
    {
        #region game
        private void menu_game_new_Click(object sender, EventArgs e)
        {
            Init();
        }
        private void menu_game_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Infinite Chess Game|*.icg";
            save.Title = "Save Game";
            save.InitialDirectory = "res/saves";
            save.ShowDialog();
            if (save.FileName != "")
            {
                StringBuilder sb = new StringBuilder();
                foreach (Piece p in pieces) {
                    sb.Append($"{prefixFromType(p.type)},{p.square.indexX},{p.square.indexY},{p.colour},{p.PawnData},{p.addedValue};");
                }
                sb.Append("|");
                foreach (string s in history.moves) {
                    sb.Append($"{s};");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append($"|{bounds[0]};{bounds[1]};{bounds[2]};{bounds[3]};{(int)state}");
                using (StreamWriter sw = new StreamWriter(save.FileName))
                {
                    sw.WriteLine(sb);
                    sw.Close();
                }
            }
        }
        private void menu_game_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Infinite Chess Game|*.icg";
            open.Title = "Open Game";
            open.InitialDirectory = "res/saves";
            open.ShowDialog();
            string data = "";
            if (open.FileName != "") {
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    data = sr.ReadToEnd();
                    sr.Close();
                }
            }
            if (data == "") return;
            string[] data_pieces = data.Split('|')[0].Split(';');
            string[] data_history = data.Split('|')[1].Split(';');
            string[] data_state = data.Split('|')[2].Split(';');

            List<Piece> piecesLoad = new List<Piece>();
            bounds = new int[4];
            board = new List<Square>();
            origin = new int[] { 0, sf * (size[1] - 1) };
            state = (GameState)int.Parse(data_state[4]);
            for (int i = 0; i < 4; i++) {
                bounds[i] = int.Parse(data_state[i]);
            }
            InitialiseBoard();
            InitialiseButtons(true);
            foreach (string s in data_pieces) {
                if (s == "") continue;
                string[] p = s.Split(',');
                PieceType t = typeFromPrefix(p[0]);
                Square sq = GameContainer.findSquareByIndex(int.Parse(p[1]), int.Parse(p[2]));
                PieceColour c = p[3] == "WHITE" ? PieceColour.WHITE : PieceColour.BLACK;
                bool pd = bool.Parse(p[4]);
                int av = int.Parse(p[5]);
                piecesLoad.Add(new Piece(t, sq, c, pd, av));
            }
            InitialisePieces(piecesLoad);
            history.setMoves(data_history.ToList());
        }
        private void menu_game_undo_Click(object sender, EventArgs e)
        {
            undo1.PerformClick();
        }
        private void menu_game_undo2_Click(object sender, EventArgs e)
        {
            undo2.PerformClick();
        }
        private void menu_game_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void menu_game_forfeit_Click(object sender, EventArgs e)
        {
            if (history.moves.Count > 0) {
                state ^= ((GameState)9);
                history.addCheck(1);
                stateLabel.Text = $"{parseState(state)}";
            }
            else stateLabel.Text = "Cannot forfeit on first turn!";
        }
        #endregion
        #region window
        private void menu_window_ui_hist_Click(object sender, EventArgs e)
        {
            bool hidden = history.Visible;
            history.Visible = !hidden;
            menu_window_ui_hist.Checked = !hidden;
        }
        private void menu_window_ui_move_Click(object sender, EventArgs e)
        {
            bool enabled = movementIndicators;
            movementIndicators = !enabled;
            menu_window_ui_move.Checked = !enabled;
        }
        private void menu_window_res_720_Click(object sender, EventArgs e)
        {
            setResolution(false);
        }
        private void menu_window_res_1080_Click(object sender, EventArgs e)
        {
            setResolution(true);
        }
        private void setResolution(bool b) {
            is1080 = b;
            menu_window_res_720.Checked = !b;
            menu_window_res_1080.Checked = b;
            if (b) {
                SetDesktopLocation(Location.X, 60);
            }
            InitialiseStyle();
            drawBoard();
        }
        #endregion
        #region setting
        private void menu_setting_ai_Click(object sender, EventArgs e)
        {
            AIDiff d = new AIDiff();
            d.setSliderValue(AIDIfficulty);
            d.ShowDialog();
            AIDIfficulty = d.difficulty;
            d.Dispose();
        }
        private void menu_setting_opp_human_Click(object sender, EventArgs e)
        {
            setOpponent(false);
        }
        private void menu_setting_opp_ai_Click(object sender, EventArgs e)
        {
            setOpponent(true);
        }
        private void setOpponent(bool ai) {
            menu_setting_opp_human.Checked = !ai;
            menu_setting_opp_ai.Checked = ai;
            opponentAI = ai;
        }
        private void menu_setting_scroll_scroll_up_Click(object sender, EventArgs e)
        {
            sUp.PerformClick();
        }
        private void menu_setting_scroll_scroll_down_Click(object sender, EventArgs e)
        {
            sDown.PerformClick();
        }
        private void menu_setting_scroll_scroll_left_Click(object sender, EventArgs e)
        {
            sLeft.PerformClick();
        }
        private void menu_setting_scroll_scroll_right_Click(object sender, EventArgs e)
        {
            sRight.PerformClick();
        }
        private void menu_setting_scroll_mult_1_Click(object sender, EventArgs e)
        {
            setScrollMult(1);
        }
        private void menu_setting_scroll_mult_2_Click(object sender, EventArgs e)
        {
            setScrollMult(2);
        }
        private void menu_setting_scroll_mult_3_Click(object sender, EventArgs e)
        {
            setScrollMult(3);
        }
        private void menu_setting_scroll_mult_4_Click(object sender, EventArgs e)
        {
            setScrollMult(4);
        }
        private void setScrollMult(int s) {
            for (int i = 0; i < 4; i++) {
                ToolStripMenuItem t = menu_setting_scroll_mult.DropDownItems[i] as ToolStripMenuItem;
                if (i == s-1) t.Checked = true;
                else t.Checked = false;
            }
            scrollMultiplier = s;
        }
        private void menu_setting_undo_Click(object sender, EventArgs e)
        {
            bool enabled = !undo1.Enabled;
            undo1.Enabled = enabled;
            undo1.Visible = enabled;
            undo2.Enabled = enabled;
            undo2.Visible = enabled;
            menu_game_undo.Enabled = enabled;
            menu_game_undo2.Enabled = enabled;
            menu_setting_undo.Checked = !enabled;
        }
        #endregion
        #region about
        private void menu_about_about_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }
        #endregion
        #region context
        private void pieceContextMenu_Opening(object sender, CancelEventArgs e)
        {
        }
        private void pieceInfoContextItem_Click(object sender, EventArgs e)
        {
            string type = pieceContextMenu.Text;
            string text = File.ReadAllText($"res/help/text/{pieceContextMenu.Text}.txt");
            Bitmap image = new Bitmap($"res/help/image/{pieceContextMenu.Text}.png");
            PieceInfo p = new PieceInfo(typeFromPrefix(type).ToString(), text, image);
            p.ShowDialog();
        }
        #endregion
    }
}
