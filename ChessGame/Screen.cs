using board;
using System.Data;
using System;

namespace ChessGame
{
    internal class Screen
    {
        public static void PrintBoard(Board chessboard)
        {
            for (int i = 0; i < chessboard.Lines; i++)
            {
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (chessboard.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(chessboard.piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
