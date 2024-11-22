using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementNumber { get; protected set; }
        public Board Board { get; protected set; }


        public Piece (Position position , Board board, Color color)
        {
            this.Position = position;
            this.Board = board;
            this.Color = color;
            this.MovementNumber = 0;

        }

        
    }
}
