using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Linq;
using System.Diagnostics;

namespace InfiniteChess
{
    public partial class Chess : Form
    {
        public class GameContainer : Panel
        {
            public Chess c;
            protected override void OnMouseClick(MouseEventArgs e)
            {
                Square cursorSquare = findSquareByCoords(e.X, e.Y);
                Piece found = pieces.Find(p => p.square == cursorSquare);
                handleTurn(found, cursorSquare);
            }

            public void handleTurn(Piece p, Square s) {
                if (!state.HasFlag(GameState.MOVE)) {
                    if (p != null && state.HasFlag(GameState.COLOUR) != p.colour.HasFlag(PieceColour.WHITE)) {
                        pieceMoving = p;
                        drawMoves(p);
                        state ^= GameState.MOVE;
                    }
                }
                else {
                    //colour of the other player
                    var colour = state.HasFlag(GameState.COLOUR) ? PieceColour.WHITE : PieceColour.BLACK;
                    if (pieceMoving.calculateMovement(false).Contains(s)) {
                        pieceMoving.move(s);
                        lastMove = null;
                        if (evaluateCheck(colour)) {
                            if (evaluateCheckMate(colour)) { state ^= (GameState.WIN | GameState.COLOUR); }
                            state ^= GameState.CHECK;
                        }
                        state ^= (GameState.MOVE | GameState.COLOUR);
                    }
                    else state ^= GameState.MOVE;
                    c.drawBoard();
                    pieceMoving = null;
                }
                c.debug3.Text = ((int)state).ToString();
            }

            public bool evaluateCheck(PieceColour c) {
                if (state.HasFlag(GameState.CHECK)) { state ^= GameState.CHECK; }
                Square king = pieces.Find(p => p.type == PieceType.KING && p.colour == c).square;
                List<Piece> newPieces = new List<Piece>(pieces);
                for (int i = 0; i < pieces.Count(); i++)
                { //change to for loop
                    if (pieces[i].colour == c) continue;
                    if (pieces[i].calculateMovement(true).Contains(king)) return true;
                }
                return false;
            }

            public bool evaluateCheckMate(PieceColour c)
            {
                Piece king = pieces.Find(p => p.type == PieceType.KING && p.colour == c);
                if (king.calculateMovement(false).Count() != 0) return false;
                List<Piece> playerPieces = pieces.FindAll(p => p.colour == c);
                for (int i = 0; i < playerPieces.Count(); i++) {
                    if (playerPieces[i].calculateMovement(false).Count() != 0) return false;
                }
                return true;
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                c = getForm<Chess>();
                Focus();
                Square cursorSquare = findSquareByCoords(e.X, e.Y);
                c.debug2.Text = cursorSquare?.ToString() ?? "null";
            }

            public void drawMoves(Piece p)
            {
                if (p == null) return;
                Graphics g = CreateGraphics();
                //Random r = new Random();
                //foreach (Square s in p.calculateMovement(false)) {
                //    g.DrawRectangle(new Pen(Color.FromArgb(255, r.Next(255),r.Next(255),r.Next(255))), s.X + 1, s.Y + 1, Chess.sf - 3, Chess.sf - 3);
                //    g.DrawRectangle(new Pen(Color.FromArgb(195, r.Next(255),r.Next(255),r.Next(255))), s.X + 2, s.Y + 2, Chess.sf - 5, Chess.sf - 5);
                //    g.DrawRectangle(new Pen(Color.FromArgb(145, r.Next(255),r.Next(255),r.Next(255))), s.X + 3, s.Y + 3, Chess.sf - 7, Chess.sf - 7);
                //}
                foreach (Square s in p.calculateMovement(false))
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(255, 206, 17, 22)), s.X + 1, s.Y + 1, sf - 3, sf - 3);
                    g.DrawRectangle(new Pen(Color.FromArgb(195, 206, 17, 22)), s.X + 2, s.Y + 2, sf - 5, sf - 5);
                    g.DrawRectangle(new Pen(Color.FromArgb(145, 206, 17, 22)), s.X + 3, s.Y + 3, sf - 7, sf - 7);
                }
                g.Dispose();
            }
            #region util
            public static TForm getForm<TForm>() where TForm : Form
            {
                return (TForm)Application.OpenForms[0];
            }

            public static Square findSquareByCoords(int x, int y)
            {
                var result = from s in board where x >= s.X && x < s.X + sf && y >= s.Y && y < s.Y + sf select s;
                return result.Count() > 0 ? result.ToArray()[0] : null;
            }

            public static Square findSquareByIndex(int indexX, int indexY)
            {
                var result = from s in board where indexX == s.indexX && indexY == s.indexY select s;
                return result.Count() > 0 ? result.ToArray()[0] : null;
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
                        if (e.KeyChar == 'e') pieces.Remove(target);
                        if (e.KeyChar == 'q') target.altColour();
                    }
                    else
                    {
                        switch (e.KeyChar)
                        {
                            case '#':
                                {
                                    pieces.Add(new Piece(PieceType.NONE, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'w':
                                {
                                    pieces.Add(new Piece(PieceType.PAWN, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'a':
                                {
                                    pieces.Add(new Piece(PieceType.BISHOP, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 's':
                                {
                                    pieces.Add(new Piece(PieceType.KNIGHT, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'd':
                                {
                                    pieces.Add(new Piece(PieceType.MANN, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'z':
                                {
                                    pieces.Add(new Piece(PieceType.HAWK, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'x':
                                {
                                    pieces.Add(new Piece(PieceType.ROOK, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'c':
                                {
                                    pieces.Add(new Piece(PieceType.CHANCELLOR, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'r':
                                {
                                    pieces.Add(new Piece(PieceType.QUEEN, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'f':
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

        public class MoveHistory : TextBox
        {
            public List<string> moves { get; private set; }

            public void addMove(Piece p, Square s) {
                p.move(s, out Piece pOut);
                string[] data = p.ToString().Split(',');
                string moveText = $"{data[0].Substring(0,1)}({data[2]},{data[3]})-";
                if (pOut != null) {
                    data = pOut.ToString().Split(',');
                    moveText += $"{data[0].Substring(0,1)}({data[2]},{data[3]})";
                }
                else {
                    moveText += $"({s.indexX},{s.indexY})";
                }
                moves.Add(moveText);
                Lines = moves.ToArray();
            }

            public void undoMove() {
                string a = moves.Last();
                moves.Remove(a);
                Lines = moves.ToArray();
            }
        }
    }

    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; } //actual coordinates
        public short indexX { get; set; }
        public short indexY { get; set; } //square reference
        public static List<Square> emptyList() => new List<Square> { }; 
        public override string ToString() => $"{indexX.ToString()},{indexY.ToString()},{X.ToString()},{Y.ToString()}";
        public static List<Square> operator +(Square s1, Square s2) => new List<Square> { s1, s2 };
    }
}
