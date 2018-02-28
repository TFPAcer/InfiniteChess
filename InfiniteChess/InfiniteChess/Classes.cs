using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace InfiniteChess
{
    class GameContainer : Panel
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Square cursorSquare = findSquareByCoords(e.X, e.Y);
            foreach (Piece p in Chess.pieces) {
                if (p.square == cursorSquare) drawMoves(p);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Label l = (Label)Parent.Controls.Find("debug2", false)[0];
            Square cursorSquare = findSquareByCoords(e.X, e.Y);
            l.Text = cursorSquare?.ToString() ?? "null";
        }

        public static Square findSquareByCoords(int x, int y) {
            //iterate through each square
            foreach (Square s in Chess.board) {
                //determine if the passed in coordinates are in the boundaries of the square
                if (x >= s.X && x < s.X + Chess.sf && y >= s.Y && y < s.Y + Chess.sf) return s;
            }
            return null;
        }

        public static Square findSquareByIndex(int indexX, int indexY) {
            foreach (Square s in Chess.board) {
                if (indexX == s.indexX && indexY == s.indexY) return s; }
            return null;
        }

        public void drawMoves(Piece p) {
            Graphics g = CreateGraphics();
            foreach (Square s in p.calculateMovement()) {
                g.DrawRectangle(new Pen(Color.FromArgb(255, 255, 0 ,0)), s.X, s.Y, Chess.sf-1, Chess.sf-1);
                g.DrawRectangle(new Pen(Color.FromArgb(255, 255, 0, 0)), s.X+1, s.Y+1, Chess.sf-3, Chess.sf-3);
                g.DrawRectangle(new Pen(Color.FromArgb(255, 255, 0, 0)), s.X+2, s.Y+2, Chess.sf-5, Chess.sf-5);
            }
            g.Dispose();
        }

    }

    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; } //actual coordinates
        public short indexX { get; set; }
        public short indexY { get; set; } //square reference
        public static List<Square> emptyList() { return new List<Square> { }; }
        public override string ToString()
        {
            return indexX.ToString() + ", " + indexY.ToString() + ", " + X.ToString() + ", " + Y.ToString();
        }
    }
}
