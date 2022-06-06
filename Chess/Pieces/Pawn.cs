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

            Piece piece = Form1.GetPiece(currentCol, currentRow);

            piece.SetRow = targetRow;
            piece.SetCol = targetCol;

            isFirstMove = false;
        }

        public override void ShowMoves(int currentRow, int currentCol)
        {
            // TODO: Dont show move to own piece

            Button possibleMove;
            Pawn piece = (Pawn)Form1.GetPiece(currentCol, currentRow);

            int steps = 1;
            if (isFirstMove)
                steps = 2;

            for (int step = 1; step <= steps; step++)
            {
                if (piece.IsWhite)
                    possibleMove = Form1.GetButton(currentRow - step, currentCol);
                else possibleMove = Form1.GetButton(currentRow + step, currentCol);

                HighlightButton(possibleMove, piece.Color);
            }

            if (piece.IsWhite)
            {
                possibleMove = Form1.GetButton(currentRow - 1, currentCol - 1);
                if (possibleMove != null && possibleMove.BackgroundImage != null)
                    HighlightButton(possibleMove, piece.Color);

                possibleMove = Form1.GetButton(currentRow - 1, currentCol + 1);
                if (possibleMove != null && possibleMove.BackgroundImage != null)
                    HighlightButton(possibleMove, piece.Color);
            }
            else
            {
                possibleMove = Form1.GetButton(currentRow + 1, currentCol - 1);
                if (possibleMove != null && possibleMove.BackgroundImage != null)
                    HighlightButton(possibleMove, piece.Color);

                possibleMove = Form1.GetButton(currentRow + 1, currentCol + 1);
                if (possibleMove != null && possibleMove.BackgroundImage != null)
                    HighlightButton(possibleMove, piece.Color);
            }
        }
    }
}
