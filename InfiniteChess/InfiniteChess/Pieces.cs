using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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

        public void move(Square s) => square = s;

        public List<Square> calculateMovement() {
            List<Square> moves = Square.emptyList();
            switch (type) {
                case (PieceType.PAWN): {
                        int direction = colour == PieceColour.WHITE ? square.indexY + 1 : square.indexY - 1;
                        for (int i = -1; i <= 1; i++) {
                            Square attempt = Chess.GameContainer.findSquareByIndex(square.indexX + i, direction);
                            if (Chess.checkSquareForPiece(attempt) == Math.Abs(i)) moves.Add(attempt);
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
                            if (Chess.checkSquareForPiece(s) != 2 && s != null) moves.Add(s); 
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
                                tracker[j] = Chess.checkSquareForPiece(attempt);
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
                            PieceType.BISHOP, square, PieceColour.WHITE).calculateMovement());
                        moves.AddRange(new Piece(
                            PieceType.ROOK, square, PieceColour.WHITE).calculateMovement());
                        return moves;
                    } 
                case PieceType.CHANCELLOR: { //KNIGHT + ROOK
                        moves.AddRange(new Piece(
                            PieceType.KNIGHT, square, PieceColour.WHITE).calculateMovement());
                        moves.AddRange(new Piece(
                            PieceType.ROOK, square, PieceColour.WHITE).calculateMovement());
                        return moves;
                    }
                default:
                    return moves;
            }
        }

        public void altColour(){
            colour = colour == PieceColour.WHITE ? PieceColour.BLACK : PieceColour.WHITE;
            icon = new Bitmap($"res/image/{colour.ToString()}/{type.ToString()}.png");
        }

        public static List<Piece> IntializePieces()
        {
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < 2; i++) {
                var w = i == 0 ? PieceColour.WHITE : PieceColour.BLACK;
                //pieces.AddRange(new List<Piece> {
                //new Piece(PieceType.PAWN, GameContainer.findSquareByIndex(3, 4 + 2*i), w),
                //new Piece(PieceType.KNIGHT, GameContainer.findSquareByIndex(4, 4 + 2*i), w),
                //new Piece(PieceType.ROOK, GameContainer.findSquareByIndex(5, 4 + 2*i), w),
                //new Piece(PieceType.BISHOP, GameContainer.findSquareByIndex(6, 4 + 2*i), w),
                //new Piece(PieceType.QUEEN, GameContainer.findSquareByIndex(7, 4 + 2*i), w),
                //new Piece(PieceType.KING, GameContainer.findSquareByIndex(8, 4 + 2*i), w),
                //new Piece(PieceType.HAWK, GameContainer.findSquareByIndex(9, 4 + 2*i), w),
                //new Piece(PieceType.CHANCELLOR, GameContainer.findSquareByIndex(10, 4 + 2*i), w),
                //new Piece(PieceType.MANN, GameContainer.findSquareByIndex(11, 4 + 2*i), w),
                //new Piece(PieceType.NONE, GameContainer.findSquareByIndex(12, 4 + 2*i), w) });
            }
            return pieces;
        }

        public override string ToString() => $"{type}: \n{colour}, \n{square.ToString()}";
    }

}
