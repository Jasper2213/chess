using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(string name, int positionX, int positionY, string color) 
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
            Queen queen = (Queen)Form1.GetPiece(currentCol, currentRow);

            int row = currentRow;
            int col = currentCol;

            Button possibleMove;

            // Up
            possibleMove = Form1.GetButton(row - 1, currentCol);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, queen.Color);
                row--;
                possibleMove = Form1.GetButton(row, col);
            }

            HighlightButton(possibleMove, queen.Color);

            // Down
            row = currentRow;
            possibleMove = Form1.GetButton(row + 1, col);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, queen.Color);
                row++;
                possibleMove = Form1.GetButton(row, col);
            }

            HighlightButton(possibleMove, queen.Color);

            // Right
            row = currentRow;
            possibleMove = Form1.GetButton(row, col + 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, queen.Color);
                col++;
                possibleMove = Form1.GetButton(row, col);
            }

            HighlightButton(possibleMove, queen.Color);

            // Left
            col = currentCol;
            possibleMove = Form1.GetButton(row, col - 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, queen.Color);
                col--;
                possibleMove = Form1.GetButton(row, col);
            }

            HighlightButton(possibleMove, queen.Color);

            row = currentRow;
            col = currentCol;

            // Diagonally right up
            possibleMove = Form1.GetButton(row - 1, currentCol + 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, queen.Color);
                row--;
                col++;
                possibleMove = Form1.GetButton(row, col);
            }

            HighlightButton(possibleMove, queen.Color);

            // Diagonally left down
            row = currentRow;
            col = currentCol;
            possibleMove = Form1.GetButton(row + 1, col - 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, queen.Color);
                row++;
                col--;
                possibleMove = Form1.GetButton(row, col);
            }

            HighlightButton(possibleMove, queen.Color);

            // Diagonally left up
            row = currentRow;
            col = currentCol;
            possibleMove = Form1.GetButton(row - 1, col - 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, queen.Color);
                row--;
                col--;
                possibleMove = Form1.GetButton(row, col);
            }

            HighlightButton(possibleMove, queen.Color);

            // Diagonally right down
            row = currentRow;
            col = currentCol;
            possibleMove = Form1.GetButton(row + 1, col + 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, queen.Color);
                row++;
                col++;
                possibleMove = Form1.GetButton(row, col);
            }

            HighlightButton(possibleMove, queen.Color);

        }
    }
}
