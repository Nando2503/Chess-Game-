using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private Piece[,] _pieces;

        public Board(int rows,int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            _pieces = new Piece[rows, columns];
        }
    }

}
