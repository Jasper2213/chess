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

        public override void ShowMoves(int currentRow, int currentCol)
        {
            King king = (King)Board.GetPiece(currentCol, currentRow);
            Button possibleMove;

            possibleMove = Board.GetButton(currentRow - 1, currentCol);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Board.GetButton(currentRow - 1, currentCol + 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Board.GetButton(currentRow - 1, currentCol - 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Board.GetButton(currentRow + 1, currentCol);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Board.GetButton(currentRow + 1, currentCol + 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Board.GetButton(currentRow + 1, currentCol - 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Board.GetButton(currentRow, currentCol + 1);
            HighlightButton(possibleMove, king.Color);

            possibleMove = Board.GetButton(currentRow, currentCol - 1);
            HighlightButton(possibleMove, king.Color);
        }
    }
}
