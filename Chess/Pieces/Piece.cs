using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public abstract class Piece
    {

        protected string name;
        protected int col;
        protected int row;
        protected string color;

        public Piece(string name, int positionX, int positionY, string color)
        {
            this.name = name;
            this.col = positionX;
            this.row = positionY;
            this.color = color;
        }

        public abstract void Move(int destinationX, int destinationY);
        public abstract void ShowMoves(int currentRow, int currentCol);

        public string Name { get { return name; } }
        public int Col { get { return col; } }
        public int Row { get { return row; } }
        public string Color { get { return color; } }
        public bool IsWhite { get { return color == "white"; } }
        public Image Image { get { return Image.FromFile(@"../images/" + name.Split(' ')[0] + "-" + color + ".png"); } }
    }
}
