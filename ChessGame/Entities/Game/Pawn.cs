using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Pawn : Piece
    {
        public Pawn(Board boad, Color color) : base(boad, color) { }

        public override string ToString()
        {
            return "P";
        }

        private bool TheresEnemy(Position pos)
        {
            Piece p = Board.piece(pos);
            return p != null && p.Color != Color;
        }
        private bool Free(Position pos)
        {
            return Board.piece(pos) == null;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && MovementNumber == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && TheresEnemy(pos)) 
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && TheresEnemy(pos)) 
                {
                    mat[pos.Line, pos.Column] = true;
                }

            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && MovementNumber == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && TheresEnemy(pos)) 
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && TheresEnemy(pos)) 
                {
                    mat[pos.Line, pos.Column] = true;
                }

            }
            return mat;
        }
    }
}
