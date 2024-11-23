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
        public Piece piece(Position pos)
        {
            return _pieces[pos.Line, pos.Column];
        }

        public bool TheresPiece(Position pos)
        {

            PositionValid(pos);
            return piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (TheresPiece(pos))
            {
                throw new BoardExeption("There's already a piece in this position, try again");
            }
            _pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.Position = null;
            _pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns){
                return false;
            }
            return true;
        }

        public void PositionValid(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardExeption("invalid position, try again");
            }
        }

    }
}
