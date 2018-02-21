using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Timers;

namespace Chess
{
    public partial class chessWin : Form
    {
        //720p: sf 36, sf2 38, size 16x16, 
        //1080p: sf 50, sf2 38, size 24x24,
        public static List<Square> board = new List<Square>(); //stores all squares of the board
        public int smallScroll = 1; public int bigScroll = 9;
        public static Color movementColour = Color.Red;
        public static int[] size = { 16, 16 }; //x,y
        public static int[] bounds = { 0, 0, 0, 0 }; //lower x, upper x, lower y, upper y
        public static int sf = 36; //scale factor of the window and controls
        public static int sf2 = 38; //scale factor of the board
        public static List<Piece> pieces = new List<Piece>();
        public static int[] O = { 0, (size[1]-1)*sf2 }; //coordinate of 0, 0
        public enum GameState { INIT, PLAY_WHITE, PLAY_BLACK, MOVING_BLACK, MOVING_WHITE, WIN_BLACK, WIN_WHITE, STALE};
        public static GameState state = GameState.INIT;
        public static int pieceMoving = -1;
        public SolidBrush[] brush = new SolidBrush[] { new SolidBrush(Color.White), new SolidBrush(Color.Black), new SolidBrush(Color.Silver), new SolidBrush(Color.Green), new SolidBrush(Color.Brown) };
        public SoundPlayer music = new SoundPlayer("res/audio/music1.wav");

        public chessWin() {
            this.Size = new Size(24 * sf, 20 * sf);
            InitializeComponent();
            boardPanel.Size = new Size(size[0] * sf2, size[1] * sf2);
            InitialiseBoard();
            InitialiseLabels();
            pieces.AddRange(Piece.IntializePieces());
            state = GameState.PLAY_WHITE;
            //music.PlayLooping();
            drawGrid();
        }

        public void InitialiseLabels() {


        }

        public void InitialiseBoard() {
            this.Size = new Size(24 * sf, 20 * sf);
            //Graphics g = boardPanel.CreateGraphics();
            bounds[1] = (size[0] - 1); bounds[3] = (size[1] - 1);
            for (int i = 0; i < size[0]; i++) { for (int j = 0; j < size[1]; j++) {
                    //g.FillRectangle(brush[3], i, j, sf2, sf2);
                    board.Add(new Square { X = O[0] + sf2 * i, Y = O[1] - sf2 * j, indexX = (short)i, indexY = (short)j});
            } }
            //g.Dispose();
        }
        
        public void drawGrid() {
            Graphics g = boardPanel.CreateGraphics();
            //g.Clear(Color.FromArgb(64,64,64));
            g.DrawImage(new Bitmap(new Bitmap("res/image/board.png"), new Size(size[0] * sf2, size[1] * sf2)), 0, 0);
            drawPieces(g);
            //for (int i = 0; i < size[0]; i++)
            //{
            //    for (int j = 0; j < size[1]; j++)
            //    {
            //        g.DrawRectangle(new Pen(brush[2]), i * sf2, j * sf2, sf2, sf2);
            //    }
            //}
            g.Dispose();
        }

        public void drawPieces(Graphics g) {
            int s = (int)Math.Floor(0.842 * sf2);
            foreach (Piece p in pieces) {
                Bitmap b = new Bitmap(p.icon, new Size(s, s));
                b.MakeTransparent(Color.White);
                g.DrawImage(b,p.square.X+3,p.square.Y+(float)Math.Ceiling(sf2*0.08));
            }
        }

        public void updateBoardPositions(int amount, bool isX, object sender) {
            O[isX ? 0 : 1] += sf2 * amount;
            if (isX) { foreach (Square s in board) { s.X += sf2 * amount; } }
            else { foreach (Square s in board) { s.Y += sf2 * amount; } }
        }

        private void v_U_Click(object sender, EventArgs e)
        {
            int a = sender.Equals(v_U2) ? bigScroll : smallScroll;
            for (int i = 0; i <= a; i++) {
                Square edge = GameContainer.findSquareByCoords(0, 0); updateBoardPositions(1, false, sender);
                if (edge.indexY == bounds[3]) {
                    bounds[3]++; for (int j = bounds[0]; j <= bounds[1]; j++) {
                        board.Add(new Square { X = O[0] + sf2 * j, Y = O[1] - bounds[3] * sf2, indexX = (short)j, indexY = (short)bounds[3] });
                    } } } drawGrid();
            if (state == GameState.MOVING_BLACK || state == GameState.MOVING_WHITE) { boardPanel.drawAvailableMovement(sender, pieces[pieceMoving]); }
        }

        private void v_D_Click(object sender, EventArgs e)
        {
            int a = sender.Equals(v_D2) ? bigScroll : smallScroll;
            for (int i = 0; i <= a; i++) {
                Square edge = GameContainer.findSquareByCoords((size[0] - 1) * sf2 + 1, (size[1] - 1) * sf2 + 1); updateBoardPositions(-1, false, sender);
                if (edge.indexY == bounds[2]) {
                    bounds[2]--; for (int j = bounds[0]; j <= bounds[1]; j++) {
                        board.Add(new Square { X = O[0] + sf2 * j, Y = O[1] - (bounds[2] * sf2), indexX = (short)j, indexY = (short)bounds[2] });
                    } } } drawGrid();
            if (state == GameState.MOVING_BLACK || state == GameState.MOVING_WHITE) { boardPanel.drawAvailableMovement(sender, pieces[pieceMoving]); }
        }

        private void h_R_Click(object sender, EventArgs e)
        {
            int a = sender.Equals(h_R2) ? bigScroll : smallScroll;
            for (int i = 0; i <= a; i++) {
                Square edge = GameContainer.findSquareByCoords((size[0] - 1) * sf2 + 1, (size[1] - 1) * sf2 + 1); updateBoardPositions(-1, true, sender);
                if (edge.indexX == bounds[1]) {
                    bounds[1]++; for (int j = bounds[2]; j <= bounds[3]; j++) {
                        board.Add(new Square { Y = O[1] - sf2 * j, X = O[0] + bounds[1] * sf2, indexY = (short)j, indexX = (short)bounds[1] });
                    } } } drawGrid();
            if (state == GameState.MOVING_BLACK || state == GameState.MOVING_WHITE) { boardPanel.drawAvailableMovement(sender, pieces[pieceMoving]); }
        }

        private void h_L_Click(object sender, EventArgs e)
        {
            int a = sender.Equals(h_L2) ? bigScroll : smallScroll;
            for (int i = 0; i <= a; i++) {
                Square edge = GameContainer.findSquareByCoords(0, 0); updateBoardPositions(1, true, sender);
                if (edge.indexX == bounds[0]) {
                    bounds[0]--; for (int j = bounds[2]; j <= bounds[3]; j++) {
                        board.Add(new Square { Y = O[1] - sf2 * j, X = O[0] + (bounds[0] * sf2), indexY = (short)j, indexX = (short)bounds[0] });
                    } } } drawGrid();
            if (state == GameState.MOVING_BLACK || state == GameState.MOVING_WHITE) { boardPanel.drawAvailableMovement(sender, pieces[pieceMoving]); }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            drawGrid();
            label2.Text = state.ToString();
        }

        private void chessWin_Load(object sender, EventArgs e)
        {

        }

        public static int findLargest(int[] i) {
            int j = int.MinValue;
            foreach (int k in i) { if (k > j) j = k; }
            return j;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            movementColour = colorDialog1.Color;
        }

        private void draw_Click(object sender, EventArgs e)
        {
            drawGrid();
        }
    }
}
