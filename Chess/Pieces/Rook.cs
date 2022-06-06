using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(string name, int positionX, int positionY, string color) 
            : base(name, positionX, positionY, color)
        {
        }

        public override void ShowMoves(int currentRow, int currentCol)
        {
            Rook rook = (Rook)Board.GetPiece(currentCol, currentRow);

            int row = currentRow;
            int col = currentCol;

            Button possibleMove;

            // Up
            possibleMove = Board.GetButton(row - 1, currentCol);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, rook.Color);
                row--;
                possibleMove = Board.GetButton(row, col);
            }

            HighlightButton(possibleMove, rook.Color);

            // Down
            row = currentRow;
            possibleMove = Board.GetButton(row + 1, col);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, rook.Color);
                row++;
                possibleMove = Board.GetButton(row, col);
            }

            HighlightButton(possibleMove, rook.Color);

            // Right
            row = currentRow;
            possibleMove = Board.GetButton(row, col + 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, rook.Color);
                col++;
                possibleMove = Board.GetButton(row, col);
            }

            HighlightButton(possibleMove, rook.Color);

            // Left
            col = currentCol;
            possibleMove = Board.GetButton(row, col - 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, rook.Color);
                col--;
                possibleMove = Board.GetButton(row, col);
            }

            HighlightButton(possibleMove, rook.Color);
        }
    }
}
