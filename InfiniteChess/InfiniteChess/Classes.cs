using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using System.Timers;
using System.ComponentModel;

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
                    pieceMoving = null;
                    pieceMovingMoves = Square.emptyList();
                    c.drawBoard();
                    if (opponentAI && state.HasFlag((GameState)1)) 
                        c.AIThread.RunWorkerAsync();
                }
                c.stateLabel.Text = $"{parseState(state)}";
            }

            #region AI
            public AIMove handleAITurn(BackgroundWorker bw) {
                List<Piece> aipieces = pieces.FindAll(p => p.colour == PieceColour.BLACK);
                List<AIMove> moves = new List<AIMove>();
                foreach (Piece p in aipieces) {
                    List<Square> pieceMoves = p.calculateMovement(false);
                    Parallel.ForEach(pieceMoves, s => {
                        moves.Add(new AIMove(p, s));
                    });
                }
                int best = 9999999;
                List<AIMove> bestMoves = new List<AIMove>();
                foreach (AIMove m in moves) {
                    int current = 0;
                    Square original = m.p.square;
                    m.p.move(m.s, out Piece q);
                    Parallel.ForEach(pieces, y => {
                        int i = y.baseValue + y.addedValue;
                        Interlocked.Add(ref current, i);
                        });
                    m.p.move(original, out Piece _q);
                    if (q != null) { pieces.Add(q); }
                    if (current < best) {
                        best = current;
                        bestMoves.Clear();
                        bestMoves.Add(m);
                    }
                    if (current == best) {
                        bestMoves.Add(m);
                    }
                }
                Debug.WriteLine(best);
                if (new Random().NextDouble() > (0.25*(AIDIfficulty/100) + 0.82)) bestMoves = moves;
                return bestMoves[(new Random()).Next(bestMoves.Count - 1)];
            }

            public void AIThread_DoWork(object sender, DoWorkEventArgs e)
            {
                state ^= GameState.MOVE;
                BackgroundWorker bw = sender as BackgroundWorker;
                e.Result = handleAITurn(bw);
            }
            public void AIThread_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                var colour = state.HasFlag(GameState.COLOUR) ? PieceColour.WHITE : PieceColour.BLACK;
                AIMove result = e.Result as AIMove;
                c.history.addMove(result.p, result.s);
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
                c.drawBoard();
                c.stateLabel.Text = $"{parseState(state)}";
            }
            #endregion
            #region check
            public bool evaluateCheck(PieceColour c) {
                if (state.HasFlag(GameState.CHECK)) { state ^= GameState.CHECK; }
                Square king = pieces.Find(p => p.type == PieceType.KING && p.colour == c).square;
                for (int i = 0; i < pieces.Count(); i++) {
                    Piece p = pieces[i];
                    if (p.colour == c) continue;
                    short[] ps = new short[] { p.square.indexX, p.square.indexY };
                    short[] ks = new short[] { king.indexX, king.indexY };
                    switch (p.type) {
                        case (PieceType.ROOK): {
                                if (ps[0] != ks[0] & ps[1] != ks[1]) continue;
                                break;
                            }
                        case (PieceType.BISHOP): {
                                if (ps[0] - ps[1] != ks[0] - ks[1]) continue;
                                break;
                            }
                        case (PieceType.QUEEN): {
                                if (ps[0] != ks[0] & ps[1] != ks[1] & ps[0] - ks[0] != ps[1] - ks[1])
                                    continue;
                                break;
                            }
                        case (PieceType.CHANCELLOR): {
                                if (ps[0] != ks[0] & ps[1] != ks[1] &
                                    (Math.Abs(ps[0] - ks[0]) > 3 |
                                    Math.Abs(ps[1] - ks[1]) > 3)) continue;
                                break;
                            }
                        case (PieceType.HAWK): {
                                if (Math.Abs(ps[0] - ks[0]) > 3 |
                                    Math.Abs(ps[1] - ks[1]) > 3) continue;
                                break;
                            }
                        case (PieceType.PAWN): {
                                if (Math.Abs(ps[0] - ks[0]) > 2 |
                                    Math.Abs(ps[1] - ks[1]) > 2) continue;
                                break;
                            }
                        case (PieceType.MANN): {
                                if (Math.Abs(ps[0] - ks[0]) > 1 |
                                    Math.Abs(ps[1] - ks[1]) > 1) continue;
                                break;
                            }
                        case (PieceType.KNIGHT): {
                                if (Math.Abs(ps[0] - ks[0]) > 2 |
                                    Math.Abs(ps[1] - ks[1]) > 2) continue;
                                break;
                            }
                        case (PieceType.KING): {
                                if (Math.Abs(ps[0] - ks[0]) > 1 |
                                    Math.Abs(ps[1] - ks[1]) > 1) continue;
                                break;
                            }
                    }
                    if (p.calculateMovement(true).Contains(king)) return true;
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
                Focus();
                if (e.Button == MouseButtons.Left) {
                    if (opponentAI & state.HasFlag((GameState)3)) return;
                    handleTurn(found, cursorSquare);
                }
                if (e.Button == MouseButtons.Right) {
                    if (found == null) return;
                    c.pieceContextMenu.Show(Cursor.Position);
                    c.pieceContextMenu.Text = prefixFromType(found.type);
                }
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                c = getForm<Chess>();
                Square cursorSquare = findSquareByCoords(e.X, e.Y);
                if (cursorSquare == null) return;
                string s =
                    $"Cursor is over ({cursorSquare?.indexX.ToString()}, {cursorSquare?.indexY.ToString()})";
                Piece p = pieces.Find(q => q.square == cursorSquare) ?? null;
                if (p != null) {
                    s += 
                        $"\ncontaining {p.colour.ToString().ToLower()} {p.type.ToString().ToLower()}";
                }
                c.cursorLabel.Text = s;
                
                //c.debug2.Text = bounds[]
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
                    pieceMovingMoves.Add(s);
                    if (!movementIndicators) continue;
                    int param = s.indexX + s.indexY;
                    //Color c = param % 2 == 0 ? Color.FromArgb(206,17,22) : Color.FromArgb(255,34,44);
                    Color c = Color.FromArgb(206, 17, 22);
                    for (int j = 1; j < 18; j++) {
                        g.DrawRectangle(new Pen(Color.FromArgb(180 - (4*j), c)), s.X + j + 1, s.Y + j + 1, sf - 3 - (2*j), sf - 3 - (2*j));
                    }
                    //g.DrawRectangle(new Pen(Color.FromArgb(255, c)), s.X + 1, s.Y + 1, sf - 3, sf - 3);
                    //g.DrawRectangle(new Pen(Color.FromArgb(195, c)), s.X + 2, s.Y + 2, sf - 5, sf - 5);
                    //g.DrawRectangle(new Pen(Color.FromArgb(145, c)), s.X + 3, s.Y + 3, sf - 7, sf - 7);

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
                    moveText += "\x0091";
                }
                if (p.type == PieceType.PAWN) {
                    if (p.square.indexY == 11 && p.colour == PieceColour.WHITE
                        || p.square.indexY == 4 && p.colour == PieceColour.BLACK) {
                        if (opponentAI & state.HasFlag((GameState)1)) {
                            p.changeType(PieceType.QUEEN);
                            moveText += "Q";
                        }
                        else {
                            Promote pForm = new Promote();
                            pForm.ShowDialog();
                            p.changeType(pForm.choice);
                            moveText += pForm.choicePrefix;
                            pForm.Dispose();
                        }
                    }
                }
                moves.Add(moveText);
                updateMoves();
            }

            public void undoMove(int num) {
                for (int i = 0; i < num; i++) {
                    if (moves.Count() == 0) break;
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
                    try {
                        p.move(from, out Piece r);
                    }
                    catch { Debug.WriteLine("p was null"); break; }
                    if (matchPieces.Count >= 2) {
                        if (lastMove.Contains("x")) {
                            PieceType type = typeFromPrefix(matchPieces[1].Value);
                            PieceColour colour = moves.Count() % 2 == 0 ? PieceColour.BLACK : PieceColour.WHITE;
                            pieces.Add(new Piece(type, to, colour));
                        }
                        if (Regex.IsMatch(lastMove.Substring(lastMove.Length - 2), "[A-Z]")) {
                            p.changeType(PieceType.PAWN);
                            p.PawnData = false;
                        }
                    }
                    if (lastMove.Contains("\x0091")) p.PawnData = true;
                    if (lastMove.Contains('+')) state ^= (GameState)4;
                    if (lastMove.Contains('#')) state ^= (GameState)13;
                    if (lastMove.Contains('~')) state ^= (GameState)17;
                    if (state.HasFlag((GameState)2)) { state ^= (GameState)2; }
                    updateValues();
                    pieceMoving = null;
                    pieceMovingMoves = Square.emptyList();
                }
                updateMoves();
            }

            public void updateMoves() {
                List<string> result = new List<string>();
                for (int i = 0; i < moves.Count(); i += 2) {
                    int lineNo = (i + 1) / 2;
                    string line = $"{lineNo + 1}. {moves[i]}".PadRight(36);
                    if (moves.Count() != i + 1) line += $"{moves[i + 1]}";
                    result.Add(line);
                }
                Lines = result.ToArray();
                SelectionStart = TextLength;
                ScrollToCaret();
            }

            public void addCheck(int state) {
                if (state < 0 || state > 2) return;
                string[] symbols = { "+", "#", "~" };
                moves[moves.Count() - 1] += symbols[state];
                updateMoves();
            }

            public void setMoves(List<string> m) {
                moves = m;
                updateMoves();
            }

            public List<Square> getLastMoveSquares() {
                if (moves.Count == 0) return Square.emptyList();
                MatchCollection matchSquares = Regex.Matches(moves.Last(), "-?\\d+,-?\\d+");
                Square to = GameContainer.findSquareByIndex(
                    int.Parse(matchSquares[1].Value.Split(',')[0]),
                    int.Parse(matchSquares[1].Value.Split(',')[1])
                    );
                Square from = GameContainer.findSquareByIndex(
                    int.Parse(matchSquares[0].Value.Split(',')[0]),
                    int.Parse(matchSquares[0].Value.Split(',')[1])
                    );
                return to + from;
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
    #region AIMove
    public class AIMove
    {
        public Square s;
        public Piece p;
        public AIMove(Piece piece, Square square) {
            p = piece; s = square;
        }
        public override string ToString() => $"{p.ToString()} -> ({s.indexX}, {s.indexY})";
    }
    #endregion
}
