using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    internal class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }

        private Piece[,] _pieces;

        public Board(int lines, int columns)
        {
            this.Lines = lines;
            this.Columns = columns;
            _pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return _pieces[line, column];

        }

        public void PutPiece(Piece p, Position pos)
        {
            _pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }
    }
}
