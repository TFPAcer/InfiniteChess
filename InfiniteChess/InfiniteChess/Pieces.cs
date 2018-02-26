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
    }
}
