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
        static Board myBoard = new Board();

        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        Image king = Image.FromFile(@"C:\Users\Aleksandr\Documents\Моя папка\ChessPiecesMoves\MainView\king.png");
        Image knight = Image.FromFile(@"C:\Users\Aleksandr\Documents\Моя папка\ChessPiecesMoves\MainView\knight.png");
        Image rook = Image.FromFile(@"C:\Users\Aleksandr\Documents\Моя папка\ChessPiecesMoves\MainView\rook.png");
        Image bishop = Image.FromFile(@"C:\Users\Aleksandr\Documents\Моя папка\ChessPiecesMoves\MainView\bishop.png");
        Image queen = Image.FromFile(@"C:\Users\Aleksandr\Documents\Моя папка\ChessPiecesMoves\MainView\queen.png");
        Image point = Image.FromFile(@"C:\Users\Aleksandr\Documents\Моя папка\ChessPiecesMoves\MainView\point.png");
       

        private void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;
            int tempBoardSize = myBoard.Size; // Variable that displays the square number on the board
            char boardCoordinate = 'a';

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    if (i == 0)
                    {
                        
                        btnGrid[i, j].Text = tempBoardSize--.ToString();
                        btnGrid[i, j].TextAlign = ContentAlignment.BottomLeft;
                        btnGrid[i, j].Font = new Font("Microsoft Sans Serif", 64/myBoard.Size);
                    }

                    if (j == myBoard.Size - 1)
                    {
                        btnGrid[i,j].Text += "     " + boardCoordinate++.ToString();
                        btnGrid[i,j].TextAlign = ContentAlignment.BottomCenter;
                        btnGrid[i, j].Font = new Font("Microsoft Sans Serif", 64 / myBoard.Size);
                        if (i == 0)
                            btnGrid[i,j].TextAlign= ContentAlignment.BottomLeft;
                    }

                    btnGrid[i, j].Width = buttonSize;
                    btnGrid[i, j].Height = buttonSize;

                    btnGrid[i, j].Click += GridButtonClick;

                    panel1.Controls.Add(btnGrid[i, j]);

                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    //btnGrid[i, j].Text = i + "|" + j;
                    btnGrid[i, j].Tag = new Point(i, j);

                }

            }

            // Drawing the chess board
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
                        btnGrid[i, j].Image = point;
                    }
                    else if (myBoard.Grid[i, j].CurrentlyOccupied == true)
                    {
                        if (comboBox1.Text == "King")
                            btnGrid[i, j].Image = king;

                        else if (comboBox1.Text == "Knight")
                            btnGrid[i, j].Image = knight;

                        else if (comboBox1.Text == "Queen")
                            btnGrid[i, j].Image = queen;

                        else if (comboBox1.Text == "Rook")
                            btnGrid[i, j].Image = rook;

                        else if (comboBox1.Text == "Bishop")
                            btnGrid[i, j].Image = bishop;
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int newSize = Convert.ToInt32(textBox1.Text);

            if (newSize > 2 && newSize < 46)
            {
                myBoard = new Board(newSize);
                throw new Exception("Applaying changes");
            }
            else
                throw new Exception("The board size must be between 3 and 45");
        }
    }
}
