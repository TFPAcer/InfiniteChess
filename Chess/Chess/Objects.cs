using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; } //actual coordinates
        public short indexX { get; set; }
        public short indexY { get; set; } //square reference
        public static List<Square> emptyList() { return new List<Square> { }; }

        public override string ToString() {
            return indexX.ToString() + ", " + indexY.ToString() + ", " + X.ToString() + ", " + Y.ToString();
        }
    }

    public class GameContainer : Panel
    {
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Label l = (Label)Parent.Controls.Find("cursorPosition", false)[0];
            Square cursorSquare = findSquareByCoords(e.X, e.Y);
            l.Text = cursorSquare?.ToString() ?? "null";
            //l.Text = chessWin.O.ToString();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Label l = (Label)Parent.Controls.Find("label2", false)[0];
            if (chessWin.state == chessWin.GameState.PLAY_BLACK || chessWin.state == chessWin.GameState.PLAY_WHITE) {
                Square cursorSquare = findSquareByCoords(e.X, e.Y);
                int pieceClicked = -1;
                foreach (Piece p in chessWin.pieces) { if (p.square == cursorSquare) { pieceClicked = chessWin.pieces.IndexOf(p); } }
                if (pieceClicked != -1) {
                    if ((chessWin.pieces[pieceClicked].colour == PieceColour.BLACK && chessWin.state == chessWin.GameState.PLAY_BLACK) ||
                        (chessWin.pieces[pieceClicked].colour == PieceColour.WHITE && chessWin.state == chessWin.GameState.PLAY_WHITE)) {
                        chessWin.pieceMoving = pieceClicked;
                        drawAvailableMovement((object)e, chessWin.pieces[pieceClicked]);
                        switch (chessWin.state) {
                            case chessWin.GameState.PLAY_BLACK: chessWin.state = chessWin.GameState.MOVING_BLACK; break;
                            default:
                                chessWin.state = chessWin.GameState.MOVING_WHITE;
                                break;
                        }
                    }
                }
            }
            else if (chessWin.state == chessWin.GameState.MOVING_BLACK || chessWin.state == chessWin.GameState.MOVING_WHITE) {
                if (chessWin.pieces[chessWin.pieceMoving].colour == PieceColour.BLACK) chessWin.state = chessWin.GameState.PLAY_WHITE;
                else chessWin.state = chessWin.GameState.PLAY_BLACK;
                //l.Text = chessWin.pieceMoving.colour.ToString();
                Square attempt = findSquareByCoords(e.X, e.Y);
                if (chessWin.pieces[chessWin.pieceMoving].calculateMovement().Contains(attempt)) {
                    chessWin.pieces[chessWin.pieceMoving].move(attempt);
                    if (chessWin.pieces[chessWin.pieceMoving].colour == PieceColour.BLACK) chessWin.state = chessWin.GameState.PLAY_WHITE;
                    else chessWin.state = chessWin.GameState.PLAY_BLACK;
                }
                else {
                    if (chessWin.pieces[chessWin.pieceMoving].colour == PieceColour.BLACK) chessWin.state = chessWin.GameState.PLAY_BLACK;
                    else chessWin.state = chessWin.GameState.PLAY_WHITE;
                }
                chessWin.pieceMoving = -1;
                Button b1 = (Button)Parent.Controls.Find("draw", false)[0]; b1.PerformClick();
            }
            l.Text = chessWin.state.ToString();
        }

        public void drawAvailableMovement(object sender, Piece p)
        {
            Graphics g = CreateGraphics();
            foreach (Square s in p.calculateMovement()) {
                Color c = chessWin.movementColour;
                g.DrawRectangle(new Pen(Color.FromArgb(106, c)), s.X + 3, s.Y + 3, chessWin.sf2 - 7, chessWin.sf2 - 7);
                g.DrawRectangle(new Pen(Color.FromArgb(180, c)), s.X + 2, s.Y + 2, chessWin.sf2 - 5, chessWin.sf2 - 5);
                g.DrawRectangle(new Pen(c), s.X + 1, s.Y + 1, chessWin.sf2 - 3, chessWin.sf2 - 3); }
            g.Dispose();
        }

        public static Square findSquareByCoords(int x, int y)
        {
            foreach (Square s in chessWin.board)
            {
                if (x >= s.X && x < s.X + chessWin.sf2 && y >= s.Y && y < s.Y + chessWin.sf2)
                {
                    return s;
                }
            }
            return null;
        }
        public static Square findSquareByIndex(int indexX, int indexY)
        {
            foreach (Square s in chessWin.board)
            {
                if (indexX == s.indexX && indexY == s.indexY) return s;
            }
            return null;
        }
    }
}
