using board;
using System.Data;
using System;
using Game;
namespace ChessGame
{
    internal class Screen
    {
        public static void PrintBoard(Board chessboard)
        {
            for (int i = 0; i < chessboard.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (chessboard.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PressPiece(chessboard.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");



        }
        public static PositionGame ReadPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1].ToString());
            return new PositionGame(column, line);
        }

        public static void PressPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
            
        }



    }
}
