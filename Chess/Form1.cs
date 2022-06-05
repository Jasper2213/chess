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

namespace Chess
{
    public partial class Form1 : Form
    {
        const int tileSize = 120;

        static List<Button> allButtons;
        static List<Piece> pieces;

        public Form1()
        {
            InitializeComponent();

            allButtons = new List<Button>();
            pieces = new List<Piece>();

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
            this.Size = new Size(tileSize * 8 + 300, tileSize * 8 + 50);
            this.CenterToScreen();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Button button = new Button();
                    button.Location = new Point(col * tileSize, row * tileSize);
                    button.Size = new Size(tileSize, tileSize);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.White;
                    button.Tag = row + " " + col;

                    if ((row + col) % 2 == 0)
                        button.BackColor = Color.Wheat;
                    else button.BackColor = Color.Olive;

                    Piece piece = GetPiece(col, row);
                    if (piece != null)
                    {
                        button.BackgroundImage = piece.Image;
                        button.BackgroundImage.Tag = piece.Color + " " + piece.Name;
                    }
                    button.BackgroundImageLayout = ImageLayout.Center;

                    button.Click += new EventHandler(Tile_Click);

                    this.Controls.Add(button);
                    allButtons.Add(button);
                }
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            Button button = (Button) sender;

            if (button.BackgroundImage != null)
            {
                RestoreButtonColors();

                string[] tagWords = button.BackgroundImage.Tag.ToString().Split(' ');

                string name;
                if (tagWords.Length == 3)
                    name = tagWords[1] + " " + tagWords[2];
                else name = tagWords[1];

                Piece piece = GetPiece(name);
                piece.ShowMoves(int.Parse(button.Tag.ToString().Split(' ')[0]), int.Parse(button.Tag.ToString().Split(' ')[1]));
            }
        }

        public static Piece GetPiece(string name)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.Name == name)
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

        private void RestoreButtonColors()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = Form1.GetButton(i, j);

                    if ((i + j) % 2 == 0)
                        button.BackColor = System.Drawing.Color.Wheat;
                    else button.BackColor = System.Drawing.Color.Olive;
                }
            }
        }
    }
}
