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
            debug3.Text = $"{bounds[0]},{bounds[1]},{bounds[2]},{bounds[3]}";
        }

        private void begin_Click(object sender, EventArgs e)
        {
            InitialiseBoard();
        }

        public void updateSquares(int amount, bool isX, object sender)
        {
            origin[isX ? 0 : 1] += 38 * amount;
            if (isX) { foreach (Square s in board) { s.X += 38 * amount; } }
            else { foreach (Square s in board) { s.Y += 38 * amount; } }
        }

        private void sUp_Click(object sender, EventArgs e)
        {
            Square edge = GameContainer.findSquareByCoords(0, 0);
            updateSquares(1, false, sender);
            if (edge.indexY == bounds[3]) {
                bounds[3]++;
                for (int j = bounds[0]; j <= bounds[1]; j++) {
                    board.Add(new Square { X = origin[0] + 38 * j,
                                           Y = origin[1] - bounds[3] * 38,
                                           indexX = (short)j,
                                           indexY = (short)bounds[3] });
                }
            }
            debug3.Text = $"{bounds[0]},{bounds[1]},{bounds[2]},{bounds[3]}";
        }

        private void sDown_Click(object sender, EventArgs e)
        {
            Square edge = GameContainer.findSquareByCoords((size[0] - 1) * 38 + 1, (size[1] - 1) * 38 + 1);
            updateSquares(-1, false, sender);
            if (edge.indexY == bounds[2]) {
                bounds[2]--;
                for (int j = bounds[0]; j <= bounds[1]; j++) {
                    board.Add(new Square { X = origin[0] + 38 * j,
                                           Y = origin[1] - bounds[2] * 38,
                                           indexX = (short)j,
                                           indexY = (short)bounds[2] });
                }
            }
            debug3.Text = $"{bounds[0]},{bounds[1]},{bounds[2]},{bounds[3]}";
        }

        private void sRight_Click(object sender, EventArgs e)
        {
            Square edge = GameContainer.findSquareByCoords((size[0] - 1) * 38 + 1, (size[1] - 1) * 38 + 1);
            updateSquares(-1, true, sender);
            if (edge.indexX == bounds[1]) {
                bounds[1]++;
                for (int j = bounds[2]; j <= bounds[3]; j++) {
                    board.Add(new Square { X = origin[0] + bounds[1] * 38,
                                           Y = origin[1] - 38 * j,
                                           indexX = (short)bounds[1],
                                           indexY = (short)j });
                }
            }
            debug3.Text = $"{bounds[0]},{bounds[1]},{bounds[2]},{bounds[3]}";
        }

        private void sLeft_Click(object sender, EventArgs e)
        {
            Square edge = GameContainer.findSquareByCoords(0, 0);
            updateSquares(1, true, sender);
            if (edge.indexX == bounds[0]) {
                bounds[0]--;
                for (int j = bounds[2]; j <= bounds[3]; j++) {
                    board.Add(new Square { X = origin[0] + bounds[0] * 38,
                                           Y = origin[1] - 38 * j,
                                           indexX = (short)bounds[0],
                                           indexY = (short)j });
                }
            }
            debug3.Text = $"{bounds[0]},{bounds[1]},{bounds[2]},{bounds[3]}";
        }
    }
}
