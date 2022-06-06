using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(string name, int positionX, int positionY, string color) 
            : base(name, positionX, positionY, color)
        {
        }

        public override void ShowMoves(int currentRow, int currentCol)
        {
            Bishop bishop = (Bishop)Board.GetPiece(currentCol, currentRow);

            int row = currentRow;
            int col = currentCol;

            Button possibleMove;

            // Diagonally right up
            possibleMove = Board.GetButton(row - 1, currentCol + 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, bishop.Color);
                row--;
                col++;
                possibleMove = Board.GetButton(row, col);
            }

            HighlightButton(possibleMove, bishop.Color);

            // Diagonally left down
            row = currentRow;
            col = currentCol;
            possibleMove = Board.GetButton(row + 1, col - 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, bishop.Color);
                row++;
                col--;
                possibleMove = Board.GetButton(row, col);
            }

            HighlightButton(possibleMove, bishop.Color);

            // Diagonally left up
            row = currentRow;
            col = currentCol;
            possibleMove = Board.GetButton(row - 1, col - 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, bishop.Color);
                row--;
                col--;
                possibleMove = Board.GetButton(row, col);
            }

            HighlightButton(possibleMove, bishop.Color);

            // Diagonally right down
            row = currentRow;
            col = currentCol;
            possibleMove = Board.GetButton(row + 1, col + 1);
            while (possibleMove != null && possibleMove.BackgroundImage == null)
            {
                HighlightButton(possibleMove, bishop.Color);
                row++;
                col++;
                possibleMove = Board.GetButton(row, col);
            }

            HighlightButton(possibleMove, bishop.Color);
        }
    }
}
