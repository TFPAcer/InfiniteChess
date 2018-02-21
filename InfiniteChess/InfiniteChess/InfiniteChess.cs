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
        public static int[] origin = { 0, 570 }; //coordinates of [0,0]
        public static int[] bounds = { 0, 0, 0, 0 }; //boundaries of the generated board
        public static int[] size = { 16, 16 }; //size of the visible board

        public InfinteChess()
        {
            InitializeComponent();
            bounds[1] = (size[0] - 1); bounds[3] = (size[1] - 1); //initialises the boundaries
        }

        //create the logical board
        public void InitialiseBoard() {
            Graphics g = boardPanel.CreateGraphics();
            g.DrawImage(new Bitmap(new Bitmap("res/image/board.png"), new Size(608, 608)), 0, 0);
            for (int i = 0; i < 16; i++) { //columns 
                for (int j = 0; j < 16; j++) { //rows
                    board.Add(new Square { X = origin[0] + 38 * i, Y = origin[1] - 38 * j, indexX = (short)i, indexY = (short)j });
                    //g.DrawRectangle( new Pen(Color.Green), origin[0] + 38 * i, origin[1] - 38 * j, 38, 38);
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
