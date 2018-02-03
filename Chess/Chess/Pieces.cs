using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace Chess
{
    public enum PieceType { PAWN, KNIGHT, ROOK, BISHOP, QUEEN, KING, MANN, HAWK, CHANCELLOR, NONE };
    public enum PieceColour { BLACK, WHITE }; //WHITE moves up the board, BLACK down

    public class Piece
    {
        public PieceType type { get; private set; }
        public Square square { get; private set; }
        public Bitmap icon { get; private set; }
        public PieceColour colour { get; private set; } //true = WHITE, false = BLACK

        public Piece(PieceType t, Square s, PieceColour c) {
            type = t; colour = c; square = s; icon = new Bitmap("res/image/" + c.ToString().ToLower() + "/" + t.ToString() + ".png"); }

        public void move(Square s) { square = s; }

        public List<Square> calculateMovement() {
            if (type == PieceType.NONE) { return Square.emptyList(); }
            if (type == PieceType.KNIGHT || type == PieceType.KING || type == PieceType.MANN || type == PieceType.HAWK) {
                List<Square> v = Square.emptyList();
                string[] a = File.ReadAllLines("res/movement/" + type.ToString() + ".txt");
                foreach (string j in a) {
                    Square q = GameContainer.findSquareByIndex(square.indexX + Int32.Parse(j.Split(',')[0]), square.indexY + Int32.Parse(j.Split(',')[1]));
                    bool va = true; foreach (Piece p in chessWin.pieces) { if (p.square == q) { va = false; } }
                    if (va) { v.Add(q); } } return v; }
            else {
                switch (type) {
                    case PieceType.PAWN: {
                            List<Square> v = Square.emptyList();
                            var y = colour == PieceColour.WHITE ? square.indexY + 1 : square.indexY - 1;
                            Square q = GameContainer.findSquareByIndex(square.indexX, y);
                            foreach (Piece p in chessWin.pieces) { if (p.square == q) { return v; }
                                if (p.square == GameContainer.findSquareByIndex(q.indexX + 1, y) || p.square == GameContainer.findSquareByIndex(q.indexX - 1, y))
                                { v.Add(p.square); } } v.Add(q); return v;
                        }
                    case PieceType.BISHOP: {
                            List<Square> v = Square.emptyList();
                            int j = chessWin.findLargest(new int[] {square.indexX-chessWin.bounds[0],square.indexY-chessWin.bounds[2],chessWin.bounds[1]-square.indexX, chessWin.bounds[3]-square.indexY});
                            bool[] t = {true,true,true,true};
                            for (int i = 1; i <= j; i++) {
                                if (t[0]) {
                                    Square q = GameContainer.findSquareByIndex(square.indexX - i, square.indexY - i) ?? square;
                                    foreach (Piece p in chessWin.pieces) { if (p.square == q) { t[0] = false; } }
                                    if (t[0]) v.Add(q); }
                                if (t[1]) {
                                    Square q = GameContainer.findSquareByIndex(square.indexX - i, square.indexY + i) ?? square;
                                    foreach (Piece p in chessWin.pieces) { if (p.square == q) { t[1] = false; } }
                                    if (t[1]) v.Add(q); }
                                if (t[2]) {
                                    Square q = GameContainer.findSquareByIndex(square.indexX + i, square.indexY + i) ?? square;
                                    foreach (Piece p in chessWin.pieces) { if (p.square == q) { t[2] = false; } }
                                    if (t[2]) v.Add(q); }
                                if (t[3]) {
                                    Square q = GameContainer.findSquareByIndex(square.indexX + i, square.indexY - i) ?? square;
                                    foreach (Piece p in chessWin.pieces) { if (p.square == q) { t[3] = false; } }
                                    if (t[3]) v.Add(q); }
                                
                                if (!t[0]&&!t[1]&&!t[2]&&!t[3]) { break; } 
                            }
                            return v;
                        }
                    case PieceType.ROOK: {
                            List<Square> v = Square.emptyList();
                            int j = chessWin.findLargest(new int[] {square.indexX-chessWin.bounds[0],square.indexY-chessWin.bounds[2],chessWin.bounds[1]-square.indexX, chessWin.bounds[3]-square.indexY});
                            bool[] t = {true,true,true,true};
                            for (int i = 1; i <= j; i++) {
                                if (t[0]) {
                                    Square q = GameContainer.findSquareByIndex(square.indexX, square.indexY - i) ?? square;
                                    foreach (Piece p in chessWin.pieces) { if (p.square == q) { t[0] = false; } }
                                    if (t[0]) v.Add(q); }
                                if (t[1]) {
                                    Square q = GameContainer.findSquareByIndex(square.indexX, square.indexY + i) ?? square;
                                    foreach (Piece p in chessWin.pieces) { if (p.square == q) { t[1] = false; } }
                                    if (t[1]) v.Add(q); }
                                if (t[2]) {
                                    Square q = GameContainer.findSquareByIndex(square.indexX + i, square.indexY) ?? square;
                                    foreach (Piece p in chessWin.pieces) { if (p.square == q) { t[2] = false; } }
                                    if (t[2]) v.Add(q); }
                                if (t[3]) {
                                    Square q = GameContainer.findSquareByIndex(square.indexX - i, square.indexY) ?? square;
                                    foreach (Piece p in chessWin.pieces) { if (p.square == q) { t[3] = false; } }
                                    if (t[3]) v.Add(q); }
                                
                                if (!t[0]&&!t[1]&&!t[2]&&!t[3]) { break; } 
                            }
                            return v;
                        }
                    case PieceType.QUEEN: {
                            List<Square> v = new Piece(PieceType.BISHOP, square, PieceColour.WHITE).calculateMovement();
                            v.AddRange(new Piece(PieceType.ROOK, square, PieceColour.WHITE).calculateMovement());
                            return v;
                        } 
                    case PieceType.CHANCELLOR: { //KNIGHT + ROOK
                            List<Square> v = new Piece(PieceType.KNIGHT, square, PieceColour.WHITE).calculateMovement();
                            v.AddRange(new Piece(PieceType.ROOK, square, PieceColour.WHITE).calculateMovement());
                            return v;
                        }
                    case PieceType.NONE: { return chessWin.board; } } }
            return Square.emptyList();
        }

        public static List<Piece> IntializePieces() {
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < 2; i++)
            {
                var w = i==0?PieceColour.WHITE:PieceColour.BLACK;
                pieces.Add(new Piece(PieceType.PAWN, GameContainer.findSquareByIndex(3, 4+2*i), w));
                pieces.Add(new Piece(PieceType.KNIGHT, GameContainer.findSquareByIndex(4, 4+i), w));
                pieces.Add(new Piece(PieceType.ROOK, GameContainer.findSquareByIndex(5, 4+i), w));
                pieces.Add(new Piece(PieceType.BISHOP, GameContainer.findSquareByIndex(6, 4+i), w));
                pieces.Add(new Piece(PieceType.QUEEN, GameContainer.findSquareByIndex(7, 4+i), w));
                pieces.Add(new Piece(PieceType.KING, GameContainer.findSquareByIndex(8, 4+i), w));
                pieces.Add(new Piece(PieceType.HAWK, GameContainer.findSquareByIndex(9, 4 + i), w));
                pieces.Add(new Piece(PieceType.CHANCELLOR, GameContainer.findSquareByIndex(10, 4 + i), w));
                pieces.Add(new Piece(PieceType.MANN, GameContainer.findSquareByIndex(11, 4 + i), w));
                pieces.Add(new Piece(PieceType.NONE, GameContainer.findSquareByIndex(12, 4+i), w));
            }
            pieces.Add(new Piece(PieceType.KNIGHT, GameContainer.findSquareByIndex(7, 10), PieceColour.BLACK));
            return pieces;
        }
    }
}