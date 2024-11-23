using board;
namespace Game
{
    internal class King : Piece
    {
        public King(Board boad, Color color) : base(boad, color) { }
        
        public override string ToString()
        {
            return "K";
        }

    }
}
