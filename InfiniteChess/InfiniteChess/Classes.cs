using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace InfiniteChess
{
    class GameContainer : Panel
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Chess.Del drawDelegate = drawMoves;

            Label l = (Label)Parent.Controls.Find("debug3", false)[0];
            Square cursorSquare = findSquareByCoords(e.X, e.Y);
            foreach (Piece p in Chess.pieces) {
                if (p.square == cursorSquare) {
                    Chess.handleTurn(drawDelegate, p);
                    l.Text = p.ToString();
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e) //debug function
        {
            Label l = (Label)Parent.Controls.Find("debug3", false)[0];
            Button b = (Button)Parent.Controls.Find("begin", false)[0];

            Point a = Parent.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            Square cursorSquare = findSquareByCoords(a.X - Location.X, a.Y - Location.Y);
            Piece target = null;
            foreach (Piece p in Chess.pieces) { if (p.square == cursorSquare) { target = p; } }

            if (cursorSquare != null) {
                if (target != null) {
                    if (e.KeyChar == '\b') Chess.pieces.Remove(target);
                    if (e.KeyChar == 'c') target.altColour();
                }
                else {
                    switch (e.KeyChar) {
                        case '0': {
                                Chess.pieces.Add(new Piece(PieceType.NONE, cursorSquare, PieceColour.WHITE));
                                break; }
                        case '1': {
                                Chess.pieces.Add(new Piece(PieceType.PAWN, cursorSquare, PieceColour.WHITE));
                                break; }
                        case '2': {
                                Chess.pieces.Add(new Piece(PieceType.BISHOP, cursorSquare, PieceColour.WHITE));
                                break; }
                        case '3': {
                                Chess.pieces.Add(new Piece(PieceType.KNIGHT, cursorSquare, PieceColour.WHITE));
                                break; }
                        case '4': {
                                Chess.pieces.Add(new Piece(PieceType.MANN, cursorSquare, PieceColour.WHITE));
                                break; }
                        case '5': {
                                Chess.pieces.Add(new Piece(PieceType.HAWK, cursorSquare, PieceColour.WHITE));
                                break; }
                        case '6': {
                                Chess.pieces.Add(new Piece(PieceType.ROOK, cursorSquare, PieceColour.WHITE));
                                break; }
                        case '7': {
                                Chess.pieces.Add(new Piece(PieceType.CHANCELLOR, cursorSquare, PieceColour.WHITE));
                                break; }
                        case '8': {
                                Chess.pieces.Add(new Piece(PieceType.QUEEN, cursorSquare, PieceColour.WHITE));
                                break; }
                        case '9': {
                                Chess.pieces.Add(new Piece(PieceType.KING, cursorSquare, PieceColour.WHITE));
                                break; }
                    }

                }
                b.PerformClick();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Focus();
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
            //Color[] c = new Color[] { Color.Aqua, Color.Cornsilk, Color.Red, Color.Violet, Color.SeaGreen, Color.PeachPuff, Color.Navy };
            //System.Random r = new System.Random();
            //foreach (Square s in p.calculateMovement()) {
            //    g.DrawRectangle(new Pen(Color.FromArgb(255, c[r.Next(7)])), s.X + 1, s.Y + 1, Chess.sf - 3, Chess.sf - 3);
            //    g.DrawRectangle(new Pen(Color.FromArgb(195, c[r.Next(7)])), s.X + 2, s.Y + 2, Chess.sf - 5, Chess.sf - 5);
            //    g.DrawRectangle(new Pen(Color.FromArgb(145, c[r.Next(7)])), s.X + 3, s.Y + 3, Chess.sf - 7, Chess.sf - 7);
            //}
            foreach (Square s in p.calculateMovement()) {
                g.DrawRectangle(new Pen(Color.FromArgb(255, 206, 17, 22)), s.X + 1, s.Y + 1, Chess.sf - 3, Chess.sf - 3);
                g.DrawRectangle(new Pen(Color.FromArgb(195, 206, 17, 22)), s.X + 2, s.Y + 2, Chess.sf - 5, Chess.sf - 5);
                g.DrawRectangle(new Pen(Color.FromArgb(145, 206, 17, 22)), s.X + 3, s.Y + 3, Chess.sf - 7, Chess.sf - 7);
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
        public override string ToString() => indexX.ToString() + ", " + indexY.ToString() + ", " + X.ToString() + ", " + Y.ToString();
        public static List<Square> operator +(Square s1, Square s2) => new List<Square> {s1, s2};
    }
}
