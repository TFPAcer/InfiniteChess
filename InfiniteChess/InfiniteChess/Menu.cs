using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteChess
{
    public partial class Chess : Form
    {
        #region game
        private void menu_game_undo_Click(object sender, EventArgs e)
        {
            undo.PerformClick();
        }
        private void menu_game_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void menu_game_new_Click(object sender, EventArgs e)
        {
            Init();
        }
        private void menu_game_forfeit_Click(object sender, EventArgs e)
        {
            state ^= ((GameState)9);
            history.addCheck(1);
            stateLabel.Text = $"{parseState(state)}";
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
        #endregion
        #region setting
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
            bool enabled = !undo.Enabled;
            undo.Enabled = enabled;
            undo.Visible = enabled;
            menu_game_undo.Enabled = enabled;
            menu_setting_undo.Checked = !enabled;
        }
        #endregion
    }
}
