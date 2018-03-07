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
    public partial class Chess : Form
    {
        //global variables
        public delegate void Del(Piece p);

        public static List<Square> board = new List<Square>(); //stores all squares of the board
        public static int[] origin = { 0, 570 }; //coordinates of [0,0]
        public static int[] bounds = { 0, 0, 0, 0 }; //boundaries of the generated board
        public static int[] size = { 16, 16 }; //size of the visible board
        public static int sf = 38;

        public static List<Piece> pieces = new List<Piece>();

        [Flags] public enum State {
            Colour = 0x01, Move = 0x02, Check = 0x04, Win = 0x08, Stale = 0x0F
        }

        #region init
        public Chess()
        {
            InitializeComponent();
            InitialiseBoard();
            pieces.AddRange(Piece.IntializePieces());
            bounds[1] = (size[0] - 1); bounds[3] = (size[1] - 1); //initialises the boundaries
        }

        //create the logical board
        public void InitialiseBoard() {
            for (int i = 0; i < size[0]; i++) { //columns 
                for (int j = 0; j < size[1]; j++) { //rows
                    board.Add(new Square {
                        X = origin[0] + sf * i,
                        Y = origin[1] - sf * j,
                        indexX = (short)i,
                        indexY = (short)j });
                }
            }
            drawBoard();

        }
        #endregion


        public void drawBoard() {
            Graphics g = boardPanel.CreateGraphics();
            //for (int i = 0; i < size[0]; i++) {
            //    for (int j = 0; j < size[1]; j++) {
            //        g.DrawRectangle(new Pen(Color.Green), origin[0] + sf * i, origin[1] - sf * j, sf, sf); } }
            g.DrawImage(new Bitmap(new Bitmap("res/image/board.png"), new Size(sf*size[0], sf*size[1])), 0, 0);
            foreach (Piece p in pieces) {
                Bitmap b = new Bitmap(p.icon, new Size(sf-6, sf-6));
                g.DrawImage(b, p.square.X+3, p.square.Y+3);
            }
            g.Dispose();
        }

        public static void handleTurn(Del) {

        }

        private void begin_Click(object sender, EventArgs e)
        {
            drawBoard();
        }
        #region util
        public void updateSquares(int amount, bool isX, object sender)
        {
            origin[isX ? 0 : 1] += sf * amount;
            if (isX) { foreach (Square s in board) { s.X += sf * amount; } }
            else { foreach (Square s in board) { s.Y += sf * amount; } }
        }

        public static int findLargest(int[] i) {
            int j = int.MinValue;
            foreach (int k in i) { if (k > j) j = k; }
            return j;
        }
        public static bool checkSquareForPiece(Square s) {
            foreach (Piece p in pieces) {
                if (p.square == s) return true;
            }
            return false;
        }
        #endregion
        #region scrolling
        private void sUp_Click(object sender, EventArgs e)
        {
            Square edge = GameContainer.findSquareByCoords(0, 0);
            updateSquares(1, false, sender);
            if (edge.indexY == bounds[3]) {
                bounds[3]++;
                for (int j = bounds[0]; j <= bounds[1]; j++) {
                    board.Add(new Square { X = origin[0] + sf * j,
                                           Y = origin[1] - bounds[3] * sf,
                                           indexX = (short)j,
                                           indexY = (short)bounds[3] });
                }
            }
        }

        private void sDown_Click(object sender, EventArgs e)
        {
            Square edge = GameContainer.findSquareByCoords((size[0] - 1) * sf + 1, (size[1] - 1) * sf + 1);
            updateSquares(-1, false, sender);
            if (edge.indexY == bounds[2]) {
                bounds[2]--;
                for (int j = bounds[0]; j <= bounds[1]; j++) {
                    board.Add(new Square { X = origin[0] + sf * j,
                                           Y = origin[1] - bounds[2] * sf,
                                           indexX = (short)j,
                                           indexY = (short)bounds[2] });
                }
            }
        }

        private void sRight_Click(object sender, EventArgs e)
        {
            Square edge = GameContainer.findSquareByCoords((size[0] - 1) * sf + 1, (size[1] - 1) * sf + 1);
            updateSquares(-1, true, sender);
            if (edge.indexX == bounds[1]) {
                bounds[1]++;
                for (int j = bounds[2]; j <= bounds[3]; j++) {
                    board.Add(new Square { X = origin[0] + bounds[1] * sf,
                                           Y = origin[1] - sf * j,
                                           indexX = (short)bounds[1],
                                           indexY = (short)j });
                }
            }
        }

        private void sLeft_Click(object sender, EventArgs e)
        {
            Square edge = GameContainer.findSquareByCoords(0, 0);
            updateSquares(1, true, sender);
            if (edge.indexX == bounds[0]) {
                bounds[0]--;
                for (int j = bounds[2]; j <= bounds[3]; j++) {
                    board.Add(new Square { X = origin[0] + bounds[0] * sf,
                                           Y = origin[1] - sf * j,
                                           indexX = (short)bounds[0],
                                           indexY = (short)j });
                }
            }
        }
        #endregion
    }
}
