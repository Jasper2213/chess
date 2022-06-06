using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public static class Settings
    {
        static string player1;
        static string player2;
        static Color tileColor1;
        static Color tileColor2;
        static string winner;

        public static string Player1 { get => player1; set => player1 = value; }
        public static string Player2 { get => player2; set => player2 = value; }
        public static Color TileColor1 { get => tileColor1; set => tileColor1 = value; }
        public static Color TileColor2 { get => tileColor2; set => tileColor2 = value; }
        public static string Winner { get => winner; set => winner = value; }
    }
}
