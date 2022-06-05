using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public override void Move(int destinationX, int destinationY)
        {
            throw new NotImplementedException();
        }

        public override void ShowMoves(int currentRow, int currentCol)
        {
            Pawn piece = (Pawn)Form1.GetPiece(currentCol, currentRow);
            Button possibleMove1;

            if (piece.IsWhite)
                possibleMove1 = Form1.GetButton(currentRow - 1, currentCol);
            else possibleMove1 = Form1.GetButton(currentRow + 1, currentCol);

            possibleMove1.BackColor = System.Drawing.Color.CadetBlue;

            if (isFirstMove)
            {
                Button possibleMove2;

                if (piece.IsWhite)
                    possibleMove2 = Form1.GetButton(currentRow - 2, currentCol);
                else possibleMove2 = Form1.GetButton(currentRow + 2, currentCol);

                possibleMove2.BackColor = System.Drawing.Color.CadetBlue;
            }
        }

        public bool IsFirstMove { get { return isFirstMove; } }
        public bool SetIsFirstMove { set { isFirstMove = value; } }
    }
}
