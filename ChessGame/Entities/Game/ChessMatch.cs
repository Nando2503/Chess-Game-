using board;

namespace Game
{
    internal class ChessMatch
    {
        public Board board {  get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer {  get; private set; }

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

        public void RealizePlay(Position origin, Position destination)
        {
            ExecuteMovement(origin, destination);
            Turn++;
            PlayerChange();
        }

        public void OriginPValidation(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardExeption("The Origin Position is empty, select a piece!");
            }
            if (CurrentPlayer != board.piece(pos).Color)
            {
                throw new BoardExeption("This piece is not from your team!!");
            }
            if (!board.piece(pos).ThereIsPossibleMovement())
            {
                throw new BoardExeption("There are no possible movements for this piece!");
            }

        }
        public void DestinyPValidation(Position origin, Position destination)
        {
            if(!board.piece(origin).CanYouMoveTo(destination))
            {
                throw new BoardExeption("Invalid Destitation");
            }
        }
        private void PlayerChange()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        private void PutPieces()
        {
            board.PutPiece(new Tower(board, Color.White), new PositionGame('c', 1).ToPosition());
            board.PutPiece(new King(board, Color.White), new PositionGame('c', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new PositionGame('c', 3).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new PositionGame('d', 5).ToPosition());

        }




    }
}
