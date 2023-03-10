using System;


namespace ChessModel
{
    public class Board
    {
        public int Size { get; set; }
        public Square[,] Grid { get; set; }

        public Board(int s = 8)
        {
            Size = s;
            Grid = new Square[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Square(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Square currentSquare, string chessPiece)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j].CurrentlyOccupied = false;
                    Grid[i, j].LegalNextMove = false;
                }
            }

            switch (chessPiece)
            {
                case "Knight":
                    KnightCase(currentSquare);
                    break;

                case "Rook":
                    int vertical = currentSquare.ColumnNumber;
                    int horizontal = currentSquare.RowNumber;
                    RookCase(currentSquare, ref vertical, ref horizontal);
                    break;

                case "Bishop":
                    vertical = currentSquare.ColumnNumber;
                    horizontal = currentSquare.RowNumber;
                    BishopCase(currentSquare, ref vertical, ref horizontal);                         
                    break;

                case "Queen":
                    vertical = currentSquare.ColumnNumber;
                    horizontal = currentSquare.RowNumber;
                    QueenCase(currentSquare, ref vertical, ref horizontal);
                    break;

                case "King":
                    vertical = currentSquare.ColumnNumber;
                    horizontal = currentSquare.RowNumber;
                    KingCase(currentSquare, ref vertical, ref horizontal);
                    break;

                default:
                    throw new FormatException("The input cannot be blank, try again");
            }

            currentSquare.CurrentlyOccupied = true;
        }

        // Helper method for the Knights' moves, doesn't allow for Knight to go out of bounds
        public bool IsSafe(int row, int column)
        {
            if ((row > Size - 1 || column > Size - 1) || (row < 0 || column < 0))
                return false;
            else
                return true;
        }

        // Methods with move logic for each piece
        public void KnightCase(Square currentSquare)
        {
            if (IsSafe(currentSquare.RowNumber + 2, currentSquare.ColumnNumber + 1))
                Grid[currentSquare.RowNumber + 2, currentSquare.ColumnNumber + 1].LegalNextMove = true;

            if (IsSafe(currentSquare.RowNumber + 2, currentSquare.ColumnNumber - 1))
                Grid[currentSquare.RowNumber + 2, currentSquare.ColumnNumber - 1].LegalNextMove = true;

            if (IsSafe(currentSquare.RowNumber - 2, currentSquare.ColumnNumber + 1))
                Grid[currentSquare.RowNumber - 2, currentSquare.ColumnNumber + 1].LegalNextMove = true;

            if (IsSafe(currentSquare.RowNumber - 2, currentSquare.ColumnNumber - 1))
                Grid[currentSquare.RowNumber - 2, currentSquare.ColumnNumber - 1].LegalNextMove = true;

            if (IsSafe(currentSquare.RowNumber + 1, currentSquare.ColumnNumber + 2))
                Grid[currentSquare.RowNumber + 1, currentSquare.ColumnNumber + 2].LegalNextMove = true;

            if (IsSafe(currentSquare.RowNumber + 1, currentSquare.ColumnNumber - 2))
                Grid[currentSquare.RowNumber + 1, currentSquare.ColumnNumber - 2].LegalNextMove = true;

            if (IsSafe(currentSquare.RowNumber - 1, currentSquare.ColumnNumber + 2))
                Grid[currentSquare.RowNumber - 1, currentSquare.ColumnNumber + 2].LegalNextMove = true;

            if (IsSafe(currentSquare.RowNumber - 1, currentSquare.ColumnNumber - 2))
                Grid[currentSquare.RowNumber - 1, currentSquare.ColumnNumber - 2].LegalNextMove = true;
        }
        public void RookCase(Square currentSquare, ref int vertical, ref int horizontal)
        {            
            while (vertical < Size - 1)
            {
                vertical++;
                Grid[horizontal, vertical].LegalNextMove = true;
            }
            vertical = currentSquare.ColumnNumber;
            while (vertical > 0)
            {
                vertical--;
                Grid[horizontal, vertical].LegalNextMove = true;
            }
            vertical = currentSquare.ColumnNumber;

            while (horizontal < Size - 1)
            {
                horizontal++;
                Grid[horizontal, vertical].LegalNextMove = true;
            }
            horizontal = currentSquare.RowNumber;
            while (horizontal > 0)
            {
                horizontal--;
                Grid[horizontal, vertical].LegalNextMove = true;
            }
        }
        public void BishopCase(Square currentSquare, ref int vertical, ref int horizontal)
        {
            while (vertical < Size - 1 && horizontal < Size - 1)
            {
                vertical++;
                horizontal++;
                Grid[horizontal, vertical].LegalNextMove = true;
            }

            vertical = currentSquare.ColumnNumber;
            horizontal = currentSquare.RowNumber;

            while (vertical > 0 && horizontal > 0)
            {
                vertical--;
                horizontal--;
                Grid[horizontal, vertical].LegalNextMove = true;
            }

            vertical = currentSquare.ColumnNumber;
            horizontal = currentSquare.RowNumber;

            while (vertical < Size - 1 && horizontal > 0)
            {
                vertical++;
                horizontal--;
                Grid[horizontal, vertical].LegalNextMove = true;
            }

            vertical = currentSquare.ColumnNumber;
            horizontal = currentSquare.RowNumber;

            while (vertical > 0 && horizontal < Size - 1)
            {
                vertical--;
                horizontal++;
                Grid[horizontal, vertical].LegalNextMove = true;
            }
        }
        public void QueenCase(Square currentSquare, ref int vertical, ref int horizontal)
        {
            RookCase(currentSquare, ref vertical, ref horizontal);
            vertical = currentSquare.ColumnNumber;
            horizontal = currentSquare.RowNumber;
            BishopCase(currentSquare, ref vertical, ref horizontal);
        }
        public void KingCase(Square currentSquare, ref int vertical, ref int horizontal)
        {
            if (vertical < Size - 1)
            {
                vertical++;
                Grid[horizontal, vertical].LegalNextMove = true;
            }
            vertical = currentSquare.ColumnNumber;
            if (vertical > 0)
            {
                vertical--;
                Grid[horizontal, vertical].LegalNextMove = true;
            }
            vertical = currentSquare.ColumnNumber;

            if (horizontal < Size - 1)
            {
                horizontal++;
                Grid[horizontal, vertical].LegalNextMove = true;
            }
            horizontal = currentSquare.RowNumber;
            if (horizontal > 0)
            {
                horizontal--;
                Grid[horizontal, vertical].LegalNextMove = true;
            }

            vertical = currentSquare.ColumnNumber;
            horizontal = currentSquare.RowNumber;

            if (vertical < Size - 1 && horizontal < Size - 1)
            {
                vertical++;
                horizontal++;
                Grid[horizontal, vertical].LegalNextMove = true;
            }

            vertical = currentSquare.ColumnNumber;
            horizontal = currentSquare.RowNumber;

            if (vertical > 0 && horizontal > 0)
            {
                vertical--;
                horizontal--;
                Grid[horizontal, vertical].LegalNextMove = true;
            }

            vertical = currentSquare.ColumnNumber;
            horizontal = currentSquare.RowNumber;

            if (vertical < Size - 1 && horizontal > 0)
            {
                vertical++;
                horizontal--;
                Grid[horizontal, vertical].LegalNextMove = true;
            }

            vertical = currentSquare.ColumnNumber;
            horizontal = currentSquare.RowNumber;

            if (vertical > 0 && horizontal < Size - 1)
            {
                vertical--;
                horizontal++;
                Grid[horizontal, vertical].LegalNextMove = true;
            }
        }
    }
}


