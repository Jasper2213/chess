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

        public override void ShowMoves(int currentRow, int currentCol)
        {
            Button possibleMove;
            Pawn piece = (Pawn)Board.GetPiece(currentCol, currentRow);

            int steps = 1;
            if (isFirstMove)
                steps = 2;

            // Forward steps
            for (int step = 1; step <= steps; step++)
            {
                if (piece.IsWhite)
                    possibleMove = Board.GetButton(currentRow - step, currentCol);
                else possibleMove = Board.GetButton(currentRow + step, currentCol);

                if (possibleMove.BackgroundImage == null)
                    HighlightButton(possibleMove, piece.Color);
            }

            // Diagonal moves to attack pieces
            if (piece.IsWhite)
            {
                possibleMove = Board.GetButton(currentRow - 1, currentCol - 1);
                if (possibleMove != null && possibleMove.BackgroundImage != null)
                    HighlightButton(possibleMove, piece.Color);

                possibleMove = Board.GetButton(currentRow - 1, currentCol + 1);
                if (possibleMove != null && possibleMove.BackgroundImage != null)
                    HighlightButton(possibleMove, piece.Color);
            }
            else
            {
                possibleMove = Board.GetButton(currentRow + 1, currentCol - 1);
                if (possibleMove != null && possibleMove.BackgroundImage != null)
                    HighlightButton(possibleMove, piece.Color);

                possibleMove = Board.GetButton(currentRow + 1, currentCol + 1);
                if (possibleMove != null && possibleMove.BackgroundImage != null)
                    HighlightButton(possibleMove, piece.Color);
            }
        }

        public bool SetIsFirstMove { set { isFirstMove = value; } }
    }
}
