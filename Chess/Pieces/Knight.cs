using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(string name, int positionX, int positionY, string color) 
            : base(name, positionX, positionY, color)
        {
        }

        public override void Move(int currentRow, int currentCol, int targetRow, int targetCol)
        {
            Button button = Form1.GetButton(targetRow, targetCol);
            if (button.BackgroundImage != null)
            {
                Form1.pieces.Remove(Form1.GetPiece(targetCol, targetRow));
                Form1.takenPieces.Add(Form1.GetPiece(targetCol, targetRow));
            }

            Piece piece = Form1.GetPiece(currentCol, currentRow);

            piece.SetRow = targetRow;
            piece.SetCol = targetCol;
        }

        public override void ShowMoves(int currentRow, int currentCol)
        {
            Knight piece = (Knight) Form1.GetPiece(currentCol, currentRow);
            Button possibleMove;

            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        possibleMove = Form1.GetButton(currentRow - 2, currentCol + 1);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 1:
                        possibleMove = Form1.GetButton(currentRow - 1, currentCol + 2);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 2:
                        possibleMove = Form1.GetButton(currentRow + 1, currentCol + 2);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 3:
                        possibleMove = Form1.GetButton(currentRow + 2, currentCol + 1);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 4:
                        possibleMove = Form1.GetButton(currentRow + 2, currentCol - 1);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 5:
                        possibleMove = Form1.GetButton(currentRow + 1, currentCol - 2);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 6:
                        possibleMove = Form1.GetButton(currentRow - 1, currentCol - 2);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 7:
                        possibleMove = Form1.GetButton(currentRow - 2, currentCol - 1);
                        HighlightButton(possibleMove, piece.Color);
                        break;
                }
            }
        }
    }
}
