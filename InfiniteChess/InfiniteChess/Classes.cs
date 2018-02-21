using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace InfiniteChess
{
    class GameContainer : Panel
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Label l = (Label)Parent.Controls.Find("debug2", false)[0];
            Square cursorSquare = findSquareByCoords(e.X, e.Y);
            l.Text = cursorSquare?.ToString() ?? "null";
        }

        public static Square findSquareByCoords(int x, int y) {
            //iterate through each square
            foreach (Square s in InfinteChess.board) {
                //determine if the passed in coordinates are in the boundaries of the square
                if (x >= s.X && x < s.X + 38 && y >= s.Y && y < s.Y + 38) return s;
            }
            return null;
        }

        public static Square findSquareByIndex(int indexX, int indexY) {
            foreach (Square s in InfinteChess.board) {
                if (indexX == s.indexX && indexY == s.indexY) return s; }
            return null;
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
