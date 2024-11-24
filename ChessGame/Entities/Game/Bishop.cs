using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Bishop : Piece 
    {
        public Bishop(Board board, Color color) : base(board, color) { }
        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            //northwest
            pos.DefineValues(Position.Line -1,Position.Column -1);
            while(Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line -1,pos.Column -1);
            }

            //northeast
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
            }
            //southeast
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column + 1);
            }
            //southwest
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column - 1);
            }
            return mat;
        }

    }
}
