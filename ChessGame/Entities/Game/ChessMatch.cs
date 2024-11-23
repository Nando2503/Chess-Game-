using board;

namespace Game
{
    internal class ChessMatch
    {
        public Board board {  get; private set; }
        public int Turn { get; set; }
        private Color CurrentPlayer {  get; set; }

        public bool Finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            if (board.piece(origin) == null)
            {
                throw new BoardExeption("No piece found at the origin position.");
            }
            Piece p = board.RemovePiece(origin);
            p.AddMoveAmount();            
            Piece capturedPiece = board.RemovePiece(destination);
            board.PutPiece(p, destination);
        }

        private void PutPieces()
        {
            board.PutPiece(new Tower(board, Color.White), new PositionGame('c', 1).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new PositionGame('c', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new PositionGame('c', 3).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new PositionGame('d', 5).ToPosition());

        }




    }
}
