using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


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

        public Piece(PieceType t, Square s, PieceColour c) {
            type = t; colour = c; square = s;
            icon = new Bitmap($"res/image/{c.ToString()}/{t.ToString()}.png");
        }

        public List<Square> calculateMovement() {
            List<Square> moves = Square.emptyList();
            switch (type) {
                case (PieceType.PAWN): {
                        var direction = colour == PieceColour.WHITE ? square.indexY + 1 : square.indexY - 1;
                        Square attempt = GameContainer.findSquareByIndex(square.indexX, direction);
                        moves.Add(attempt);
                        foreach (Piece p in Chess.pieces) { if (p.square == attempt) moves.Remove(attempt); }
                        return moves;
                    }
                case (PieceType.MANN):
                case (PieceType.KNIGHT):
                case (PieceType.HAWK):
                default:
                    return moves;
            }
        }

        public static List<Piece> IntializePieces()
        {
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < 2; i++) {
                var w = i == 0 ? PieceColour.WHITE : PieceColour.BLACK;
                pieces.AddRange(new List<Piece> {
                new Piece(PieceType.PAWN, GameContainer.findSquareByIndex(3, 4 + 2*i), w),
                new Piece(PieceType.KNIGHT, GameContainer.findSquareByIndex(4, 4 + 2*i), w),
                new Piece(PieceType.ROOK, GameContainer.findSquareByIndex(5, 4 + 2*i), w),
                new Piece(PieceType.BISHOP, GameContainer.findSquareByIndex(6, 4 + 2*i), w),
                new Piece(PieceType.QUEEN, GameContainer.findSquareByIndex(7, 4 + 2*i), w),
                new Piece(PieceType.KING, GameContainer.findSquareByIndex(8, 4 + 2*i), w),
                new Piece(PieceType.HAWK, GameContainer.findSquareByIndex(9, 4 + 2*i), w),
                new Piece(PieceType.CHANCELLOR, GameContainer.findSquareByIndex(10, 4 + 2*i), w),
                new Piece(PieceType.MANN, GameContainer.findSquareByIndex(11, 4 + 2*i), w),
                new Piece(PieceType.NONE, GameContainer.findSquareByIndex(12, 4 + 2*i), w) });
            }
            return pieces;
        }
    }

}
