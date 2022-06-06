﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public abstract class Piece
    {

        protected string name;
        protected int col;
        protected int row;
        protected string color;

        public Piece(string name, int positionX, int positionY, string color)
        {
            this.name = name;
            this.col = positionX;
            this.row = positionY;
            this.color = color;
        }

        public abstract void Move(int currentRow, int currentCol, int targetRow, int targetCol);
        public abstract void ShowMoves(int currentRow, int currentCol);

        protected void HighlightButton(Button possibleMove, string color)
        {
            // If the button exists
            if (possibleMove != null)
            {
                Piece piece = Form1.GetPiece(int.Parse(possibleMove.Tag.ToString().Split(' ')[1]), int.Parse(possibleMove.Tag.ToString().Split(' ')[0]));

                // If there's a piece on the button that is from the opponent
                if (piece != null && piece.Color != color)
                    possibleMove.BackColor = System.Drawing.Color.CadetBlue;
                // If there's no piece on that button
                else if (piece == null)
                    possibleMove.BackColor = System.Drawing.Color.CadetBlue;
            }
        }

        public string Name { get { return name; } }
        public int Col { get { return col; } }
        public int SetCol { set { col = value; } }
        public int Row { get { return row; } }
        public int SetRow { set { row = value; } }
        public string Color { get { return color; } }
        public bool IsWhite { get { return color == "white"; } }
        public Image Image { get { return Image.FromFile(@"../images/" + name.Split(' ')[0] + "-" + color + ".png"); } }

    }
}
