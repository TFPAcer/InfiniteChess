using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfiniteChess
{
    public partial class AIDiff : Form
    {
        public int difficulty = 0;

        public AIDiff()
        {
            InitializeComponent();
            InitialiseStyle();
        }

        public void InitialiseStyle() {
            Color highlight = Color.FromKnownColor(KnownColor.Control);
            BackColor = Color.FromKnownColor(KnownColor.Control);
            foreach (Control c in Controls) {
                if (c.GetType() == typeof(Button)) {
                    Button b = c as Button;
                    b.FlatStyle = FlatStyle.Flat;
                    b.BackColor = highlight;
                    b.FlatAppearance.BorderColor = Color.Black;
                    b.FlatAppearance.BorderSize = 1;
                    b.FlatAppearance.MouseDownBackColor = Color.LightGray;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
                    b.ForeColor = Color.Black;   
                }
                c.Font = new Font("Perpetua", 9, FontStyle.Bold);
            }
        }

        public void setSliderValue(int d) {
            AIDiffSlider.Value = d;
        }

        private void AIDiffSlider_Scroll(object sender, EventArgs e) {
            difficulty = AIDiffSlider.Value;
        }
    }
}
