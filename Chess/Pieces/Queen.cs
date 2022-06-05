using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(string name, int positionX, int positionY, string color) 
            : base(name, positionX, positionY, color)
        {
        }

        public override void Move(int currentX, int currentY, int destinationX, int destinationY)
        {
            throw new NotImplementedException();
        }
    }
}
