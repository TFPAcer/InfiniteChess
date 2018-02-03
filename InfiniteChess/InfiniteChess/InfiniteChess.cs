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
    public partial class InfinteChess : Form
    {
        //global variables
        public static List<Square> board = new List<Square>(); //stores all squares of the board

        public InfinteChess()
        {
            InitializeComponent();
        }

        private void InfiniteChess_Load(object sender, EventArgs e)
        {
            
        }

        //create the logical board
        public void InitialiseBoard() {
            Graphics g = boardPanel.CreateGraphics();
            for (int i = 0; i < 16; i++) { //columns 
                for (int j = 0; j < 16; j++) { //rows
                    board.Add(new Square { X = 38 * i, Y = 38 * j, indexX = (short)i, indexY = (short)j });
                    g.DrawRectangle( new Pen(Color.Green), 38*i, 38*j, 38, 38);
                }
            }
            g.Dispose();
        }

        private void begin_Click(object sender, EventArgs e)
        {
            InitialiseBoard();
        }
    }
}
