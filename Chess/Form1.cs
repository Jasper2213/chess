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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * 80, i * 80);
                    button.Size = new Size(80, 80);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Tag = "Tile";

                    if ((i + j) % 2 == 0)
                        button.BackColor = Color.White;
                    else button.BackColor = Color.Black;

                    button.BackgroundImage = Image.FromFile(@"../images/rook-white.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.BackgroundImage.Tag = "White rook";

                    button.Click += Tile_Click;

                    this.Controls.Add(button);
                }
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click!");
        }
    }
}
