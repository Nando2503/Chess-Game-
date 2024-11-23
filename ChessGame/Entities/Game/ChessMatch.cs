using board;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace Game
{
    internal class ChessMatch
    {
        public Board board {  get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer {  get; private set; }

        public bool Finished { get; private set; }

        private HashSet<Piece> pices;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            board = new Board(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            pices = new HashSet<Piece>();
            captured = new HashSet<Piece>();
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
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
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


        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> pieceInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pices)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }


        public void AddNewPiece(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new PositionGame(column, line).ToPosition());
            pices.Add(piece);
        }

        private void PutPieces()
        {
            AddNewPiece('c', 1, new Tower(board, Color.White));
            AddNewPiece('c', 2, new Tower(board, Color.White));
            AddNewPiece('e', 1, new Tower(board, Color.White));
            AddNewPiece('e', 2, new Tower(board, Color.White));
            AddNewPiece('d', 1, new King(board, Color.White));
            AddNewPiece('d', 2, new Tower(board, Color.White));


            AddNewPiece('c', 7, new Tower(board, Color.Black));
            AddNewPiece('c', 8, new Tower(board, Color.Black));
            AddNewPiece('e', 7, new Tower(board, Color.Black));
            AddNewPiece('e', 8, new Tower(board, Color.Black));
            AddNewPiece('d', 8, new King(board, Color. Black));
            AddNewPiece('d', 7, new Tower(board, Color.Black));




        }




    }
}
