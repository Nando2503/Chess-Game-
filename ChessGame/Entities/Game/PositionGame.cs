using board;

namespace Game
{
    internal class PositionGame
    {
        public char Pilar { get; set; }
        public int Position { get; set; }

        public PositionGame(char pilar, int position)
        {
            this.Pilar = pilar;
            this.Position = position;
        }

        public Position ToPosition()
        {
            return new Position(8 - Position, Pilar - 'a');
        }

        public override string ToString()
        {

            return "" + Pilar + Position;
        }
    }
}

