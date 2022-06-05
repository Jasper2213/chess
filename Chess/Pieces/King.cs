using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class King : Piece
    {
        public King(string name, int positionX, int positionY, string color) 
            : base(name, positionX, positionY, color)
        {
        }

        public override void Move(int destinationX, int destinationY)
        {
            throw new NotImplementedException();
        }

        public override void ShowMoves(int currentRow, int currentCol)
        {
            throw new NotImplementedException();
        }
    }
}
