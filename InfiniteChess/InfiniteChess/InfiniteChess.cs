using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace InfiniteChess
{
    [Flags] public enum GameState { COLOUR = 0x01, MOVE = 0x02, CHECK = 0x04, WIN = 0x08, STALE = 0x10 }

    public partial class Chess : Form
    {
        //global variables
        public static List<Square> board = new List<Square>(); //stores all squares of the board
        public static int[] origin = { 0, 570 }; //coordinates of [0,0]
        public static int[] bounds = { -1, 17, -1, 17 }; //boundaries of the generated board
        public static int[] size = { 16, 16 }; //size of the visible board
        public static int sf = 38;

        public static List<Piece> pieces = new List<Piece>();
        public static Piece pieceMoving = null;
        public static List<Square> pieceMovingMoves = Square.emptyList();
        public static Piece lastMove = null;
        public static GameState state = 0x0;

        #region init
        public Chess()
        {
            InitializeComponent();
            InitialiseBoard();
            pieces.AddRange(Piece.IntializePieces());
            //bounds[1] = (size[0] - 1)+1; bounds[3] = (size[1] - 1)+1; //initialises the boundaries
        }

        //create the logical board
        public void InitialiseBoard() {
            for (int i = bounds[0]; i < bounds[1]+1; i++) { //columns 
                for (int j = bounds[2]; j < bounds[3]+1; j++) { //rows
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
        #region util
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
            if (state.HasFlag(GameState.MOVE)) { boardPanel.drawMoves(pieceMoving); }
        }
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
        public static int checkSquareForPiece(Square s, bool includeKings, PieceColour c) {
            foreach (Piece p in pieces) {
                if (p.square == s) {
                    if (p.type == PieceType.KING && !includeKings) return 2;
                    if (c != p.colour)
                        return 1;
                    else return 2;
                }
            }
            return 0;
        }
        private void begin_Click(object sender, EventArgs e)
        {
            drawBoard();
        }
        private void debug3_Click(object sender, EventArgs e)
        {

        }

        private void undo_Click(object sender, EventArgs e)
        {
            history.undoMove();
            drawBoard();
        }
        public static string prefixFromType(PieceType t) {
            switch (t) {
                case PieceType.BISHOP: return "B";
                case PieceType.CHANCELLOR: return "C";
                case PieceType.HAWK: return "H";
                case PieceType.KING: return "K";
                case PieceType.KNIGHT: return "N";
                case PieceType.MANN: return "M";
                case PieceType.NONE: return "Z";
                case PieceType.PAWN: return "P";
                case PieceType.QUEEN: return "Q";
                case PieceType.ROOK: return "R";
            }
            return "#";
        }
        public static PieceType typeFromPrefix(string c) {
            switch (c) {
                case "B": return PieceType.BISHOP;
                case "C": return PieceType.CHANCELLOR;
                case "H": return PieceType.HAWK;
                case "K": return PieceType.KING;
                case "N": return PieceType.KNIGHT;
                case "M": return PieceType.MANN;
                case "Z": return PieceType.NONE;
                case "P": return PieceType.PAWN;
                case "Q": return PieceType.QUEEN;
                case "R": return PieceType.ROOK;
            }
            return PieceType.NONE;
        }
        public static string parseState(GameState g) {
            string info = "'s turn";
            string colour = g.HasFlag((GameState)1) ? "Black" : "White";
            if (g.HasFlag((GameState)4)) { info = " in check"; }
            if (g.HasFlag((GameState)8)) { info = " has won"; }
            if (g.HasFlag((GameState)16)) { colour = ""; info = "Stalemate"; }
            return colour + info;
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
            drawBoard();
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
            drawBoard();
        }

        private void sRight_Click(object sender, EventArgs e)
        {
            Square edge = GameContainer.findSquareByCoords((size[0] - 1) * sf + 1, (size[1] - 1) * sf + 1);
            updateSquares(-1, true, sender);
            Debug.WriteLine("e" + edge.indexX);
            Debug.WriteLine("b" + bounds[1]);
            if (edge.indexX == bounds[1]) {
                bounds[1]++;
                for (int j = bounds[2]; j <= bounds[3]; j++) {
                    board.Add(new Square { X = origin[0] + bounds[1] * sf,
                                           Y = origin[1] - sf * j,
                                           indexX = (short)bounds[1],
                                           indexY = (short)j });
                }
            }
            drawBoard();
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
            drawBoard();
        }
        #endregion
    }
}
