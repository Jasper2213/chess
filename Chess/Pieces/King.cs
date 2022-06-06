using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Pieces
{
    public class King : Piece
    {
        public King(string name, int positionX, int positionY, string color) 
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
            King king = (King)Form1.GetPiece(currentCol, currentRow);
            Button possibleMove;

            possibleMove = Form1.GetButton(currentRow - 1, currentCol);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Form1.GetButton(currentRow - 1, currentCol + 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Form1.GetButton(currentRow - 1, currentCol - 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Form1.GetButton(currentRow + 1, currentCol);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Form1.GetButton(currentRow + 1, currentCol + 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Form1.GetButton(currentRow + 1, currentCol - 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Form1.GetButton(currentRow, currentCol + 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Form1.GetButton(currentRow, currentCol - 1);
            HighlightButton(possibleMove, king.Color);
        }
    }
}
