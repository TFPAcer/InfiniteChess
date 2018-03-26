using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System;

namespace InfiniteChess
{
    public partial class Chess : Form
    {
        public class GameContainer : Panel
        {
            public Chess c;

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
                    if (pieceMovingMoves.Contains(s)) {
                        c.history.addMove(pieceMoving, s);
                        lastMove = null;
                        bool cm = evaluateCheckMate(colour);
                        if (evaluateCheck(colour)) {
                            if (cm) {
                                state ^= (GameState.WIN | GameState.COLOUR);
                                c.history.addCheck(1);
                            }
                            else c.history.addCheck(0);
                            state ^= GameState.CHECK;
                        }
                        else if (cm) {
                            state ^= (GameState.STALE | GameState.COLOUR);
                            c.history.addCheck(2);
                        }
                        state ^= (GameState.MOVE | GameState.COLOUR);
                    }
                    else state ^= GameState.MOVE;
                    c.drawBoard();
                    pieceMoving = null;
                    pieceMovingMoves = Square.emptyList();
                }
                c.debug3.Text = $"{parseState(state)}";
            }
            #region check
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
            #endregion
            #region mouse stuff
            protected override void OnMouseClick(MouseEventArgs e)
            {
                Square cursorSquare = findSquareByCoords(e.X, e.Y);
                Piece found = pieces.Find(p => p.square == cursorSquare);
                handleTurn(found, cursorSquare);
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                c = getForm<Chess>();
                Focus();
                Square cursorSquare = findSquareByCoords(e.X, e.Y);
                c.debug2.Text = cursorSquare?.ToString() ?? "null";
            }
            #endregion
            #region util
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
                    int param = s.indexX + s.indexY;
                    //Color c = param % 2 == 0 ? Color.FromArgb(206,17,22) : Color.FromArgb(255,34,44);
                    Color c = Color.FromArgb(206, 17, 22);
                    g.DrawRectangle(new Pen(Color.FromArgb(255, c)), s.X + 1, s.Y + 1, sf - 3, sf - 3);
                    g.DrawRectangle(new Pen(Color.FromArgb(195, c)), s.X + 2, s.Y + 2, sf - 5, sf - 5);
                    g.DrawRectangle(new Pen(Color.FromArgb(145, c)), s.X + 3, s.Y + 3, sf - 7, sf - 7);
                    pieceMovingMoves.Add(s);
                }
                g.Dispose();
            }
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

                if (cursorSquare != null) {
                    if (target != null) {
                        if (e.KeyChar == 'e') pieces.Remove(target);
                        if (e.KeyChar == 'q') target.altColour();
                    }
                    else{
                        switch (e.KeyChar) {
                            case '#': {
                                    pieces.Add(new Piece(PieceType.NONE, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'w': {
                                    pieces.Add(new Piece(PieceType.PAWN, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'a': {
                                    pieces.Add(new Piece(PieceType.BISHOP, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 's': {
                                    pieces.Add(new Piece(PieceType.KNIGHT, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'd': {
                                    pieces.Add(new Piece(PieceType.MANN, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'z': {
                                    pieces.Add(new Piece(PieceType.HAWK, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'x': {
                                    pieces.Add(new Piece(PieceType.ROOK, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'c': {
                                    pieces.Add(new Piece(PieceType.CHANCELLOR, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'r': {
                                    pieces.Add(new Piece(PieceType.QUEEN, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'f': {
                                    pieces.Add(new Piece(PieceType.KING, cursorSquare, PieceColour.WHITE));
                                    break;
                                }
                            case 'i': {
                                    c.sUp.PerformClick();
                                    break;
                                }
                            case 'j': {
                                    c.sLeft.PerformClick();
                                    break;
                                }
                            case 'k': {
                                    c.sDown.PerformClick();
                                    break;
                                }
                            case 'l': {
                                    c.sRight.PerformClick();
                                    break;
                                }
                        }

                    }
                    c.drawBoard();
                }
            }
            #endregion
        }
        #region history
        public class MoveHistory : TextBox
        {
            public List<string> moves { get; private set; } = new List<string>();

            public void addMove(Piece p, Square s) {
                string[] data = p.ToString().Split(',');
                string moveText = $"{prefixFromType(p.type)}({data[2]},{data[3]})";
                p.move(s, out Piece pOut);
                if (pOut != null) {
                    data = pOut.ToString().Split(',');
                    moveText += $"x{prefixFromType(pOut.type)}({data[2]},{data[3]})";
                }
                else moveText += $"-({s.indexX},{s.indexY})";
                if (p.type == PieceType.PAWN && p.PawnData == true) {
                    p.PawnData = false;
                    moveText += "`";
                }
                moves.Add(moveText);
                updateMoves();
            }

            public void undoMove() {
                if (moves.Count() == 0) return;
                string lastMove = moves.Last();
                state ^= GameState.COLOUR;
                moves.Remove(lastMove);
                MatchCollection matchSquares = Regex.Matches(lastMove, "-?\\d+,-?\\d+");
                MatchCollection matchPieces = Regex.Matches(lastMove, "[A-Z]");
                Square to = GameContainer.findSquareByIndex(
                    int.Parse(matchSquares[1].Value.Split(',')[0]), 
                    int.Parse(matchSquares[1].Value.Split(',')[1])
                    );
                Square from = GameContainer.findSquareByIndex(
                    int.Parse(matchSquares[0].Value.Split(',')[0]),
                    int.Parse(matchSquares[0].Value.Split(',')[1])
                    );
                Piece p = pieces.Find(q => q.square == to);
                p.move(from, out Piece r);
                if (lastMove.Contains("x")) {
                    PieceType type = typeFromPrefix(matchPieces[1].Value);
                    PieceColour colour = moves.Count() % 2 == 0 ? PieceColour.BLACK : PieceColour.WHITE;
                    pieces.Add(new Piece(type, to, colour));
                }
                if (lastMove.Contains("`")) p.PawnData = true;
                if (lastMove.Contains('+')) state ^= (GameState)5;
                if (lastMove.Contains('#')) state ^= (GameState)13;
                if (lastMove.Contains('~')) state ^= (GameState)17;
                updateMoves();
            }

            public void updateMoves() {
                List<string> result = new List<string>();
                for (int i = 0; i < moves.Count(); i += 2) {
                    int lineNo = (i + 1) / 2;
                    string line = $"{lineNo+1}. {moves[i]}".PadRight(36);
                    if (moves.Count() != i+1) line += $"{moves[i+1]}";
                    result.Add(line);
                }
                Lines = result.ToArray();
            }

            public void addCheck(int state) {
                if (state < 0 || state > 2) return;
                string[] symbols = { "+", "#", "~"};
                moves[moves.Count()-1] += symbols[state];
                updateMoves();
            }
        }
    }
    #endregion
    #region square
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
    #endregion
}
