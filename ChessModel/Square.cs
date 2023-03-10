using System;

namespace ChessModel
{
    public class Square
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public bool LegalNextMove { get; set; }

        public Square(int RowNumber, int ColumnNumber)
        {
            this.RowNumber = RowNumber;
            this.ColumnNumber = ColumnNumber;
        }

    }



}

