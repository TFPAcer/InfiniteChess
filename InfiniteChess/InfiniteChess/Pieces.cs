using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace InfiniteChess
{
    public enum PieceType { PAWN, KNIGHT, ROOK, BISHOP, QUEEN, KING, MANN, HAWK, CHANCELLOR, NONE };
    public enum PieceColour { BLACK, WHITE }; //WHITE moves up the board, BLACK down

    public class Piece
    {
        public PieceType type { get; private set; }
        public Square square { get; private set; }
        public Bitmap icon { get; private set; }
        public PieceColour colour { get; private set; }
        public bool PawnData { get; set; } = false;
        public int baseValue { get; set; }
        public int addedValue { get; set; }

        public Piece(PieceType t, Square s, PieceColour c) {
            type = t; colour = c; square = s;
            icon = new Bitmap($"res/image/pieces/icon/{c.ToString()}/{t.ToString()}.png");
            if (t == PieceType.PAWN) { PawnData = true; }
            int sign = colour == PieceColour.WHITE ? 1 : -1;
            switch (type) {
                case PieceType.PAWN: { baseValue = 1000 * sign; break; }
                case PieceType.BISHOP: { baseValue = 7000 * sign; break; }
                case PieceType.ROOK: { baseValue = 15000 * sign; break; }
                case PieceType.KNIGHT: { baseValue = 4000 * sign; break; }
                case PieceType.MANN: { baseValue = 4000 * sign; break; }
                case PieceType.HAWK: { baseValue = 12000 * sign; break; }
                case PieceType.CHANCELLOR: { baseValue = 18000 * sign; break; }
                case PieceType.QUEEN: { baseValue = 25000 * sign; break; }
                case PieceType.KING: { baseValue = 200000 * sign; break; }
                case PieceType.NONE: { baseValue = 0; break; }
            }
        }
        public Piece(PieceType t, Square s, PieceColour c, bool pd, int av) {
            type = t; colour = c; square = s; PawnData = pd; addedValue = av;
            icon = new Bitmap($"res/image/pieces/icon/{c.ToString()}/{t.ToString()}.png");
            int sign = colour == PieceColour.WHITE ? 1 : -1;
            switch (type) {
                case PieceType.PAWN: { baseValue = 1000 * sign; break; }
                case PieceType.BISHOP: { baseValue = 7000 * sign; break; }
                case PieceType.ROOK: { baseValue = 15000 * sign; break; }
                case PieceType.KNIGHT: { baseValue = 4000 * sign; break; }
                case PieceType.MANN: { baseValue = 4000 * sign; break; }
                case PieceType.HAWK: { baseValue = 12000 * sign; break; }
                case PieceType.CHANCELLOR: { baseValue = 18000 * sign; break; }
                case PieceType.QUEEN: { baseValue = 25000 * sign; break; }
                case PieceType.KING: { baseValue = 200000 * sign; break; }
                case PieceType.NONE: { baseValue = 0; break; }
            }
        }
        #region movement
        public void move(Square s, out Piece pOut) {
            Piece p = Chess.pieces.Find(q => q.square == s);
            pOut = p;
            if (p != null) {
                Chess.pieces.Remove(p);
                Chess.lastMove = p;
            }
            square = s;
            Chess.updateValues();
        }

        public List<Square> calculateInitMovement(bool includeKings) {
            List<Square> moves = Square.emptyList();
            switch (type) {
                case (PieceType.PAWN): {
                        int direction = colour == PieceColour.WHITE ? square.indexY + 1 : square.indexY - 1;
                        for (int i = -1; i <= 1; i++) {
                            Square attempt = Chess.GameContainer.findSquareByIndex(square.indexX + i, direction);
                            if (Chess.checkSquareForPiece(attempt, includeKings, colour) == Math.Abs(i)) moves.Add(attempt);
                        }
                        if (PawnData && moves.Count != 0) {
                            int direction2 = colour == PieceColour.WHITE ? square.indexY + 2 : square.indexY - 2;
                            Square attempt = Chess.GameContainer.findSquareByIndex(square.indexX, direction2);
                            if (Chess.checkSquareForPiece(attempt, includeKings, colour) == 0)
                                moves.Add(attempt);
                        }
                        return moves;
                    }
                case (PieceType.MANN): { goto case PieceType.KING; }
                case (PieceType.KNIGHT): { goto case PieceType.KING; }
                case (PieceType.HAWK): { goto case PieceType.KING; }
                case (PieceType.KING): {
                        string[] attempts = File.ReadAllLines($"res/movement/{type.ToString()}.txt");
                        foreach (string att in attempts) {
                            Square s = Chess.GameContainer.findSquareByIndex(
                                square.indexX + int.Parse(att.Split(',')[0]),
                                square.indexY + int.Parse(att.Split(',')[1]));
                            if (Chess.checkSquareForPiece(s, includeKings, colour) != 2 && s != null) moves.Add(s); 
                        }
                        return moves;
                    }
                case (PieceType.ROOK): { goto case PieceType.BISHOP; }
                case (PieceType.BISHOP): {
                    int[] tracker = { 0, 0, 0, 0 };
                    int[][] direction = type == PieceType.BISHOP ?
                        new int[][] { new int[]{-1,-1}, new int[]{-1,1}, new int[]{1,-1}, new int[]{1,1} } :
                        new int[][] { new int[]{-1,0}, new int[]{1,0}, new int[]{0,-1}, new int[]{0,1} };
                    int max = Chess.findLargest(new int[] {
                        square.indexX-Chess.bounds[0], square.indexY-Chess.bounds[2],
                        Chess.bounds[1]-square.indexX, Chess.bounds[3]-square.indexY} );
                    for (int i = 1; i <= max; i++) {
                        for (int j = 0; j < 4; j++) {
                            if (tracker[j] != 2) {
                                Square attempt = Chess.GameContainer.findSquareByIndex( 
                                    square.indexX - i*direction[j][0], square.indexY - i*direction[j][1]) ?? square;
                                tracker[j] = Chess.checkSquareForPiece(attempt, includeKings, colour);
                                if (tracker[j] != 2) {
                                    moves.Add(attempt);
                                    if (tracker[j] == 1) tracker[j] = 2; 
                                }
                            }
                        }
                    }
                    return moves;
                }
                case PieceType.QUEEN: {
                        moves.AddRange(new Piece(
                            PieceType.BISHOP, square, colour).calculateInitMovement(includeKings));
                        moves.AddRange(new Piece(
                            PieceType.ROOK, square, colour).calculateInitMovement(includeKings));
                        return moves;
                    } 
                case PieceType.CHANCELLOR: { //KNIGHT + ROOK
                        moves.AddRange(new Piece(
                            PieceType.KNIGHT, square, colour).calculateInitMovement(includeKings));
                        moves.AddRange(new Piece(
                            PieceType.ROOK, square, colour).calculateInitMovement(includeKings));
                        return moves;
                    }
                default:
                    return moves;
            }
        }

        public List<Square> calculateMovement(bool includeKings) {
            List<Square> moves = calculateInitMovement(includeKings);
            List<Square> newMoves = new List<Square>();
            Square original = square;

            foreach (Square s in moves) {
                newMoves.Add(s);
                move(s, out Piece q);
                Square king = new Square();
                king = Chess.pieces.Find(p => p.type == PieceType.KING && p.colour == colour).square;
                foreach (Piece y in Chess.pieces) {
                    if (y.colour == colour) continue;
                    if (y.calculateInitMovement(true).Contains(king)) { newMoves.Remove(s); break; }
                }
                move(original, out q);
                if (Chess.lastMove != null) { Chess.pieces.Add(Chess.lastMove); Chess.lastMove = null; }
            }
            return newMoves;
        }
        #endregion
        #region util
        public void altColour() {
            colour = colour == PieceColour.WHITE ? PieceColour.BLACK : PieceColour.WHITE;
            icon = new Bitmap($"res/image/pieces/icon/{colour.ToString()}/{type.ToString()}.png");
        }
        public void changeType(PieceType t) {
            type = t;
            icon = new Bitmap($"res/image/pieces/icon/{colour.ToString()}/{type.ToString()}.png");
            PawnData = true;
        }
        public override string ToString() => $"{type},{colour},{square.ToString()}";
        #endregion
        #region init
        public static List<Piece> IntializePieces()
        {
            List<Piece> pieces = new List<Piece>();
            string[] data = File.ReadAllLines("res/config/start.txt");
            foreach (string d in data) {
                string[] ds = d.Split(',');
                PieceColour colour = ds[3] == "W" ? PieceColour.WHITE : PieceColour.BLACK;
                pieces.Add(new Piece(Chess.typeFromPrefix(ds[0]), Chess.GameContainer.findSquareByIndex(int.Parse(ds[1]), int.Parse(ds[2])), colour));
            }
            return pieces;
        }
        #endregion
    }
}
