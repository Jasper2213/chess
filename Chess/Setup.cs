using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string namePlayer1 = txtPlayer1.Text;
                string namePlayer2 = txtPlayer2.Text;

                if (namePlayer1 == "" || namePlayer2 == "")
                    throw new ArgumentException("Please fill in a name.");

                string color1 = comboBox1.Text;
                string color2 = comboBox2.Text;
                Color tileColor1 = Color.FromName(color1);
                Color tileColor2 = Color.FromName(color2);

                if (color1 == "" || color1 == "")
                    throw new ArgumentException("Please choose a color.");

                if (tileColor1 == tileColor2)
                    throw new ArgumentException("Please choose 2 different colors.");

                Settings.Player1 = namePlayer1;
                Settings.Player2 = namePlayer2;
                Settings.TileColor1 = tileColor1;
                Settings.TileColor2 = tileColor2;

                this.Hide();
                Form Board = new Board();
                Board.Closed += (s, args) => this.Close();
                Board.Show();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
