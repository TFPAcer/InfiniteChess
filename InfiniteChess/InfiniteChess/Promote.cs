using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfiniteChess
{
    public partial class Promote : Form
    {
        public PieceType choice;
        public string choicePrefix;

        public Promote()
        {
            InitializeComponent();
            InitialiseStyle();
        }

        public void InitialiseStyle() {
            BackColor = Color.FromArgb(28, 32, 40);
            foreach (Control c in Controls) {
                if (c.GetType() == typeof(Button)) {
                    Button b = c as Button;
                    b.FlatStyle = FlatStyle.Flat;
                    b.BackColor = Color.DimGray;
                    b.FlatAppearance.BorderColor = Color.Black;
                    b.FlatAppearance.BorderSize = 1;
                    b.FlatAppearance.MouseDownBackColor = Color.Gray;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
                    b.ForeColor = Color.White;
                    
                }
            }
        }

        private void promoteClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string data = b.Name.TrimStart('p');
            choicePrefix = data;
            choice = Chess.typeFromPrefix(data);
            Close();
        }
    }
}
