using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Linq;

namespace InfiniteChess
{
    public partial class Chess : Form
    { 
        public class GameContainer : Panel
        {
            public Chess c;
            protected override void OnMouseClick(MouseEventArgs e) {
                Square cursorSquare = findSquareByCoords(e.X, e.Y);
                Piece found = pieces.Find(p => p.square == cursorSquare);
                handleTurn(found, cursorSquare);
            }

            public void handleTurn(Piece p, Square s) {
                if (!state.HasFlag(GameState.MOVE)) {
                    if (p!= null && state.HasFlag(GameState.COLOUR) != p.colour.HasFlag(PieceColour.WHITE)) {
                        pieceMoving = p;
                        drawMoves(p);
                        state ^= GameState.MOVE;
                    }
                }
                else {
                    if (pieceMoving.calculateMovement(false).Contains(s)) {
                        pieceMoving.move(s);
                        state ^= (GameState.MOVE | GameState.COLOUR);
                        evaluateCheck();
                    }
                    else state ^= GameState.MOVE;
                    c.drawBoard();
                    pieceMoving = null;
                    //c.debug3.Text = ((int)state).ToString();
                }
            }

            public void evaluateCheck() {
                c.debug3.Text = "";
                var colour = state.HasFlag(GameState.COLOUR) ? PieceColour.BLACK : PieceColour.WHITE;
                Square king = pieces.Find(p => p.type == PieceType.KING && p.colour == colour).square;

                foreach (Piece p in pieces) {
                    //foreach (Square s in p.calculateMovement(true))
                    //{ c.debug3.Text += p.ToString() + ": " + s.ToString() + "\n"; }
                    //c.debug3.Text += p.calculateMovement(true).Find(s => s == king).ToString();

                    var a = from s in p.calculateMovement(true) where 
                            s.ToString() == king.ToString()
                            select s;
                    foreach (var b in a) { c.debug3.Text += b.ToString() + "\n"; }


                    if (a.Count() != 0) {
                        state ^= GameState.CHECK; break;
                    }
                }
            }

            protected override void OnMouseMove(MouseEventArgs e) {
                c = getForm<Chess>();
                Focus();
                Square cursorSquare = findSquareByCoords(e.X, e.Y);
                c.debug2.Text = cursorSquare?.ToString() ?? "null";
            }

            public void drawMoves(Piece p) {
                if (p == null) return;
                Graphics g = CreateGraphics();
                //Color[] c = new Color[] { Color.Aqua, Color.Cornsilk, Color.Red, Color.Violet, Color.SeaGreen, Color.PeachPuff, Color.Navy };
                //System.Random r = new System.Random();
                //foreach (Square s in p.calculateMovement()) {
                //    g.DrawRectangle(new Pen(Color.FromArgb(255, c[r.Next(7)])), s.X + 1, s.Y + 1, Chess.sf - 3, Chess.sf - 3);
                //    g.DrawRectangle(new Pen(Color.FromArgb(195, c[r.Next(7)])), s.X + 2, s.Y + 2, Chess.sf - 5, Chess.sf - 5);
                //    g.DrawRectangle(new Pen(Color.FromArgb(145, c[r.Next(7)])), s.X + 3, s.Y + 3, Chess.sf - 7, Chess.sf - 7);
                //}
                foreach (Square s in p.calculateMovement(true)) {
                    g.DrawRectangle(new Pen(Color.FromArgb(255, 206, 17, 22)), s.X + 1, s.Y + 1, sf - 3, sf - 3);
                    g.DrawRectangle(new Pen(Color.FromArgb(195, 206, 17, 22)), s.X + 2, s.Y + 2, sf - 5, sf - 5);
                    g.DrawRectangle(new Pen(Color.FromArgb(145, 206, 17, 22)), s.X + 3, s.Y + 3, sf - 7, sf - 7);
                }
                g.Dispose();
            }
            #region util
            private static bool pieceSearchParameter(Square s, Piece p) {
                return p.square == s;
            }
            public static TForm getForm<TForm>() where TForm : Form {
                return (TForm)Application.OpenForms[0];
            }

            public static Square findSquareByCoords(int x, int y) {
                foreach (Square s in board) {
                    if (x >= s.X && x < s.X + sf && y >= s.Y && y < s.Y + sf) return s;
                }
                return null;
            }

            public static Square findSquareByIndex(int indexX, int indexY) {
                foreach (Square s in board) {
                    if (indexX == s.indexX && indexY == s.indexY) return s;
                }
                return null;
            }
            #endregion
            #region debug
            protected override void OnKeyPress(KeyPressEventArgs e) //debug function
            {
                Point a = Parent.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                Square cursorSquare = findSquareByCoords(a.X - Location.X, a.Y - Location.Y);
                Piece target = null;
                foreach (Piece p in pieces) { if (p.square == cursorSquare) { target = p; } }

                if (cursorSquare != null)
                {
                    if (target != null)
                    {
                        if (e.KeyChar == '\b') pieces.Remove(target);
                        if (e.KeyChar == 'c') target.altColour();
                    }
                    else
                    {
                        switch (e.KeyChar)
                        {
                            case '0':
                                {
                                    pieces.Add(new Piece(PieceType.NONE, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case '1':
                                {
                                    pieces.Add(new Piece(PieceType.PAWN, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case '2':
                                {
                                    pieces.Add(new Piece(PieceType.BISHOP, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case '3':
                                {
                                    pieces.Add(new Piece(PieceType.KNIGHT, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case '4':
                                {
                                    pieces.Add(new Piece(PieceType.MANN, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case '5':
                                {
                                    pieces.Add(new Piece(PieceType.HAWK, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case '6':
                                {
                                    pieces.Add(new Piece(PieceType.ROOK, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case '7':
                                {
                                    pieces.Add(new Piece(PieceType.CHANCELLOR, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case '8':
                                {
                                    pieces.Add(new Piece(PieceType.QUEEN, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case '9':
                                {
                                    pieces.Add(new Piece(PieceType.KING, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                        }

                    }
                    c.drawBoard();
                }
            }
            #endregion
        }
    }

    public class Square : IEquatable<Square>
    {
        public int X { get; set; }
        public int Y { get; set; } //actual coordinates
        public short indexX { get; set; }
        public short indexY { get; set; } //square reference
        public static List<Square> emptyList() => new List<Square> { }; 
        public override string ToString() => indexX.ToString() + ", " + indexY.ToString() + ", " + X.ToString() + ", " + Y.ToString();
        public static List<Square> operator +(Square s1, Square s2) => new List<Square> { s1, s2 };
        public bool Equals(Square s) => ToString() == s.ToString();
        public override bool Equals(object obj) {
            if (obj == null) return false;
            Square s = obj as Square;
            if (s == null) return false;
            else return Equals(s);
        }
        public override int GetHashCode() => ToString().GetHashCode();
    }
}
