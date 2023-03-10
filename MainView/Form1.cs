using ChessModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static Board myBoard = new Board(8);

        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        private void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    btnGrid[i, j].Width = buttonSize;
                    btnGrid[i, j].Height = buttonSize;

                    btnGrid[i, j].Click += GridButtonClick;

                    panel1.Controls.Add(btnGrid[i, j]);

                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    //btnGrid[i, j].Text = i + "|" + j;
                    btnGrid[i, j].Tag = new Point(i, j);

                }

            }

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    if ((j % 2 == 0 && i % 2 == 0) || (j % 2 != 0 && i % 2 != 0))
                        btnGrid[i, j].BackColor = Color.White;
                    else if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                        btnGrid[i, j].BackColor = Color.BurlyWood;
                }
            }

        }
        private void GridButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            Square currentSquare = myBoard.Grid[x, y];


            myBoard.MarkNextLegalMoves(currentSquare, comboBox1.Text);

            // update the text for each button press
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Image = null;
                    btnGrid[i, j].Text = "";
                    if (myBoard.Grid[i, j].LegalNextMove == true)
                    {
                        btnGrid[i, j].Text = "point";
                    }
                    else if (myBoard.Grid[i, j].CurrentlyOccupied == true)
                    {
                        if (comboBox1.Text == "King")
                            btnGrid[i, j].Text = "king";

                        else if (comboBox1.Text == "Knight")
                            btnGrid[i, j].Text = "knight";

                        else if (comboBox1.Text == "Queen")
                            btnGrid[i, j].Text = "queen";

                        else if (comboBox1.Text == "Rook")
                            btnGrid[i, j].Text = "rook";

                        else if (comboBox1.Text == "Bishop")
                            btnGrid[i, j].Text = "bishop";
                    }
                }

            }
        }
    }
}
