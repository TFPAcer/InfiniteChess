using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace InfiniteChess
{
    class GameContainer : Panel
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            g.DrawImage(new Bitmap(new Bitmap("res/image/board.png"), new Size(512,512)), 0, 0);
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
