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

        public override void ShowMoves(int currentRow, int currentCol)
        {
            Knight piece = (Knight) Board.GetPiece(currentCol, currentRow);
            Button possibleMove;

            for (int i = 0; i < 8; i++)     // 8, because a knight has 8 possible moves
            {
                switch (i)
                {
                    case 0:
                        possibleMove = Board.GetButton(currentRow - 2, currentCol + 1);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 1:
                        possibleMove = Board.GetButton(currentRow - 1, currentCol + 2);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 2:
                        possibleMove = Board.GetButton(currentRow + 1, currentCol + 2);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 3:
                        possibleMove = Board.GetButton(currentRow + 2, currentCol + 1);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 4:
                        possibleMove = Board.GetButton(currentRow + 2, currentCol - 1);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 5:
                        possibleMove = Board.GetButton(currentRow + 1, currentCol - 2);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 6:
                        possibleMove = Board.GetButton(currentRow - 1, currentCol - 2);
                        HighlightButton(possibleMove, piece.Color);
                        break;

                    case 7:
                        possibleMove = Board.GetButton(currentRow - 2, currentCol - 1);
                        HighlightButton(possibleMove, piece.Color);
                        break;
                }
            }
        }
    }
}
