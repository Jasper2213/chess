using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: Setup screen(s): player names, board colors?, ...
// TODO: Players take turns, white starts
// TODO: Overview of pieces each player took?

namespace Chess
{
    public partial class Form1 : Form
    {
        const int tileSize = 120;
        const byte ROW_COUNT = 8;
        const byte COL_COUNT = 8;

        static List<Button> allButtons;
        public static List<Piece> pieces;
        public static List<Piece> takenPieces;

        Piece selectedPiece = null;

        public Form1()
        {
            InitializeComponent();

            allButtons = new List<Button>();
            pieces = new List<Piece>();

            takenPieces = new List<Piece>();

            pieces.Add(new Rook("rook 1", 0, 0, "black"));
            pieces.Add(new Knight("knight 1", 1, 0, "black"));
            pieces.Add(new Bishop("bishop 1", 2, 0, "black"));
            pieces.Add(new Queen("queen", 3, 0, "black"));
            pieces.Add(new King("king", 4, 0, "black"));
            pieces.Add(new Bishop("bishop 2", 5, 0, "black"));
            pieces.Add(new Knight("knight 2", 6, 0, "black"));
            pieces.Add(new Rook("rook 2", 7, 0, "black"));
            pieces.Add(new Pawn("pawn 1", 0, 1, "black"));
            pieces.Add(new Pawn("pawn 2", 1, 1, "black"));
            pieces.Add(new Pawn("pawn 3", 2, 1, "black"));
            pieces.Add(new Pawn("pawn 4", 3, 1, "black"));
            pieces.Add(new Pawn("pawn 5", 4, 1, "black"));
            pieces.Add(new Pawn("pawn 6", 5, 1, "black"));
            pieces.Add(new Pawn("pawn 7", 6, 1, "black"));
            pieces.Add(new Pawn("pawn 8", 7, 1, "black"));

            pieces.Add(new Pawn("pawn 1", 0, 6, "white"));
            pieces.Add(new Pawn("pawn 2", 1, 6, "white"));
            pieces.Add(new Pawn("pawn 3", 2, 6, "white"));
            pieces.Add(new Pawn("pawn 4", 3, 6, "white"));
            pieces.Add(new Pawn("pawn 5", 4, 6, "white"));
            pieces.Add(new Pawn("pawn 6", 5, 6, "white"));
            pieces.Add(new Pawn("pawn 7", 6, 6, "white"));
            pieces.Add(new Pawn("pawn 8", 7, 6, "white"));
            pieces.Add(new Rook("rook 1", 0, 7, "white"));
            pieces.Add(new Knight("knight 1", 1, 7, "white"));
            pieces.Add(new Bishop("bishop 1", 2, 7, "white"));
            pieces.Add(new King("king", 3, 7, "white"));
            pieces.Add(new Queen("queen", 4, 7, "white"));
            pieces.Add(new Bishop("bishop 2", 5, 7, "white"));
            pieces.Add(new Knight("knight 2", 6, 7, "white"));
            pieces.Add(new Rook("rook 2", 7, 7, "white"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(tileSize * COL_COUNT + 300, tileSize * ROW_COUNT + 50);
            this.CenterToScreen();

            for (int row = 0; row < ROW_COUNT; row++)
            {
                for (int col = 0; col < COL_COUNT; col++)
                {
                    Button button = new Button();
                    button.Location = new Point(col * tileSize, row * tileSize);
                    button.Size = new Size(tileSize, tileSize);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.White;
                    button.Tag = row + " " + col;
                    button.BackgroundImageLayout = ImageLayout.Center;

                    button.Click += new EventHandler(Tile_Click);

                    this.Controls.Add(button);
                    allButtons.Add(button);
                }
            }

            ReloadBoard();
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            int row = int.Parse(button.Tag.ToString().Split(' ')[0]);
            int col = int.Parse(button.Tag.ToString().Split(' ')[1]);

            Piece piece = GetPiece(col, row);


            // if the player clicks on a piece
            if (button.BackgroundImage != null)
            {
                // If the player already clicked on a piece
                if (selectedPiece != null)
                {
                    // If the player wants to see the possible moves for another of its pieces
                    if (selectedPiece.Color == piece.Color)
                    {
                        ReloadBoard();
                        selectedPiece = piece;
                        selectedPiece.ShowMoves(selectedPiece.Row, selectedPiece.Col);
                    }
                    // Player wants to take the piece it clicked on (Taking is handled in Piece)
                    else
                    {
                        if (MoveIsValid(row, col))
                        {
                            selectedPiece.Move(selectedPiece.Row, selectedPiece.Col, row, col);
                            selectedPiece = null;
                            ReloadBoard();
                        }
                    }
                }
                // No piece was selected yet
                else
                {
                    ReloadBoard();
                    selectedPiece = piece;
                    selectedPiece.ShowMoves(selectedPiece.Row, selectedPiece.Col);
                }
            }
            // Player clicked on an empty space
            else
            {
                // If player selected a piece to move
                if (selectedPiece != null)
                {
                    if (MoveIsValid(row, col))
                    {
                        selectedPiece.Move(selectedPiece.Row, selectedPiece.Col, row, col);
                        selectedPiece = null;
                        ReloadBoard();
                    }
                }
            }
        }

        public bool MoveIsValid(int targetRow, int targetCol)
        {
            Button button = GetButton(targetRow, targetCol);
            return button.BackColor == Color.CadetBlue;
        }

        public static Piece GetPiece(string name, string color)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.Name == name && piece.Color == color)
                    return piece;
            }

            return null;
        }

        public static Piece GetPiece(int col, int row)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.Col == col && piece.Row == row)
                    return piece;
            }

            return null;
        }

        public static Button GetButton(int row, int col)
        {
            foreach (Button button in allButtons)
            {
                if (int.Parse(button.Tag.ToString().Split(' ')[0]) == row && int.Parse(button.Tag.ToString().Split(' ')[1]) == col)
                    return button;
            }

            return null;
        }

        private void ReloadBoard()
        {
            for (int row = 0; row < ROW_COUNT; row++)
            {
                for (int col = 0; col < COL_COUNT; col++)
                {
                    Button button = GetButton(row, col);
                    Piece piece = GetPiece(col, row);

                    if (piece != null)
                    {
                        button.BackgroundImage = piece.Image;
                        button.BackgroundImage.Tag = piece.Color + " " + piece.Name;
                    }
                    else button.BackgroundImage = null;

                    if ((row + col) % 2 == 0)
                        button.BackColor = Color.Wheat;
                    else button.BackColor = Color.Olive;
                }
            }
        }
    }
}
