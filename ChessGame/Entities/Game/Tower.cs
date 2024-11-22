using board;
namespace Game
{
    internal class Tower : Piece
    {
        public Tower(Board boad, Color color) : base(boad, color) { }

        public override string ToString()
        {
            return "T";
        }

    }
}
