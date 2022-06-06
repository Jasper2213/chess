using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        private bool isFirstMove;

        public Pawn(string name, int positionX, int positionY, string color) 
            : base(name, positionX, positionY, color)
        {
            isFirstMove = true;
        }

        public override void Move(int currentRow, int currentCol, int targetRow, int targetCol)
        {
            // TODO: En passant

            Button button = Form1.GetButton(targetRow, targetCol);
            if (button.BackgroundImage != null)
            {
                Form1.pieces.Remove(Form1.GetPiece(targetCol, targetRow));
                Form1.takenPieces.Add(Form1.GetPiece(targetCol, targetRow));
            }

            Pawn pawn = (Pawn) Form1.GetPiece(currentCol, currentRow);

            pawn.SetRow = targetRow;
            pawn.SetCol = targetCol;

            isFirstMove = false;
        }

        public override void ShowMoves(int currentRow, int currentCol)
        {
            Pawn piece = (Pawn) Form1.GetPiece(currentCol, currentRow);
            Button possibleMove1;

            int steps;
            if (isFirstMove) steps = 2;
            else steps = 1;

            for (int step = 1; step <= steps; step++)
            {
                if (piece.IsWhite)
                    possibleMove1 = Form1.GetButton(currentRow - step, currentCol);
                else possibleMove1 = Form1.GetButton(currentRow + step, currentCol);

                if (possibleMove1.BackgroundImage != null)
                    break;

                possibleMove1.BackColor = System.Drawing.Color.CadetBlue;
            }

            Button buttonDiagonalLeft;
            Button buttonDiagonalRight;

            if (piece.IsWhite)
            {
                if (piece.Col == 0)
                {
                    buttonDiagonalRight = Form1.GetButton(currentRow - 1, currentCol + 1);
                    if (buttonDiagonalRight.BackgroundImage != null)
                        buttonDiagonalRight.BackColor = System.Drawing.Color.CadetBlue;
                }
                else if (piece.Col == 7)
                {
                    buttonDiagonalLeft = Form1.GetButton(currentRow - 1, currentCol - 1);
                    if (buttonDiagonalLeft.BackgroundImage != null)
                        buttonDiagonalLeft.BackColor = System.Drawing.Color.CadetBlue;
                }
                else
                {
                    buttonDiagonalLeft = Form1.GetButton(currentRow - 1, currentCol - 1);
                    buttonDiagonalRight = Form1.GetButton(currentRow - 1, currentCol + 1);

                    if (buttonDiagonalLeft.BackgroundImage != null)
                        buttonDiagonalLeft.BackColor = System.Drawing.Color.CadetBlue;

                    if (buttonDiagonalRight.BackgroundImage != null)
                        buttonDiagonalRight.BackColor = System.Drawing.Color.CadetBlue;
                }
            }
            else
            {
                if (piece.Col == 7)
                {
                    buttonDiagonalRight = Form1.GetButton(currentRow + 1, currentCol - 1);
                    if (buttonDiagonalRight.BackgroundImage != null)
                        buttonDiagonalRight.BackColor = System.Drawing.Color.CadetBlue;
                }
                else if (piece.Col == 0)
                {
                    buttonDiagonalLeft = Form1.GetButton(currentRow + 1, currentCol + 1);
                    if (buttonDiagonalLeft.BackgroundImage != null)
                        buttonDiagonalLeft.BackColor = System.Drawing.Color.CadetBlue;
                }
                else
                {
                    buttonDiagonalLeft = Form1.GetButton(currentRow + 1, currentCol + 1);
                    buttonDiagonalRight = Form1.GetButton(currentRow + 1, currentCol - 1);

                    if (buttonDiagonalLeft.BackgroundImage != null)
                        buttonDiagonalLeft.BackColor = System.Drawing.Color.CadetBlue;

                    if (buttonDiagonalRight.BackgroundImage != null)
                        buttonDiagonalRight.BackColor = System.Drawing.Color.CadetBlue;
                }
            }
        }
    }
}
