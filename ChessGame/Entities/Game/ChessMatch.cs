using board;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using System;
using ChessGame.Entities.Game;

namespace Game
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }

        public bool Finished { get; private set; }

        public bool Check { get; private set; }

        private HashSet<Piece> pices;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            pices = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMovement(Position origin, Position destination)
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
            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = board.RemovePiece(destination);
            p.MinusMoveAmount();
            if (capturedPiece != null)
            {
                board.PutPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            board.PutPiece(p, origin);
        }
        public void RealizePlay(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMovement(origin, destination);
            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardExeption("you cannot put yourself in check!");
            }
            if (IsInCheck(Enemy(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if(CheckTest(Enemy(CurrentPlayer)))
            {
                Finished = true;
            }


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
            if (!board.piece(origin).PossibleMove(destination))
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
                if (x.Color == color)
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

        private Color Enemy(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece x in pieceInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece R = King(color);
            if (R == null)
            {
                throw new BoardExeption("Theres no king with the colour " + color + "in the board");
            }

            foreach (Piece x in pieceInGame(Enemy(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[R.Position.Line, R.Position.Column])
                {
                    return true;
                }
            }
            return false;

        }

        public bool CheckTest(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach(Piece x in pieceInGame(color))
            {
                bool[,] mat = x.PossibleMoves();
                for(int i = 0; i<board.Lines;  i++)
                {
                    for(int j = 0; j<board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMovement(origin, destiny);
                            bool checktest = IsInCheck(color);
                            UndoMove(origin, destiny,capturedPiece);
                            if (!checktest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void AddNewPiece(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new PositionGame(column, line).ToPosition());
            pices.Add(piece);
        }

        private void PutPieces()
        {
            AddNewPiece('a', 1, new Tower(board, Color.White));
            AddNewPiece('b', 1, new Horse(board, Color.White));
            AddNewPiece('c', 1, new Bishop(board, Color.White));
            AddNewPiece('d', 1, new Queen(board, Color.White));
            AddNewPiece('e', 1, new King(board, Color.White));
            AddNewPiece('f', 1, new Bishop(board, Color.White));
            AddNewPiece('g', 1, new Horse(board, Color.White));
            AddNewPiece('h', 1, new Tower(board, Color.White));
            AddNewPiece('a', 2, new Pawn(board, Color.White));
            AddNewPiece('b', 2, new Pawn(board, Color.White));
            AddNewPiece('c', 2, new Pawn(board, Color.White));
            AddNewPiece('d', 2, new Pawn(board, Color.White));
            AddNewPiece('e', 2, new Pawn(board, Color.White));
            AddNewPiece('f', 2, new Pawn(board, Color.White));
            AddNewPiece('g', 2, new Pawn(board, Color.White));
            AddNewPiece('h', 2, new Pawn(board, Color.White));


            

            AddNewPiece('a', 8, new Tower(board, Color.Black));
            AddNewPiece('b', 8, new Horse(board, Color.Black));
            AddNewPiece('c', 8, new Bishop(board, Color.Black));
            AddNewPiece('d', 8, new Queen(board, Color.Black));
            AddNewPiece('e', 8, new King(board, Color.Black));
            AddNewPiece('f', 8, new Bishop(board, Color.Black));
            AddNewPiece('g', 8, new Horse(board, Color.Black));
            AddNewPiece('h', 8, new Tower(board, Color.Black));
            AddNewPiece('a', 7, new Pawn(board, Color.Black));
            AddNewPiece('b', 7, new Pawn(board, Color.Black));
            AddNewPiece('c', 7, new Pawn(board, Color.Black));
            AddNewPiece('d', 7, new Pawn(board, Color.Black));
            AddNewPiece('e', 7, new Pawn(board, Color.Black));
            AddNewPiece('f', 7, new Pawn(board, Color.Black));
            AddNewPiece('g', 7, new Pawn(board, Color.Black));
            AddNewPiece('h', 7, new Pawn(board, Color.Black));





        }




    }
}
