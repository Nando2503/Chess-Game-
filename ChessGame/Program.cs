using System;
using board;
using ChessGame;
using Game;
try
{
    ChessMatch match = new ChessMatch();
    while (!match.Finished)
    {
        Console.Clear();
        Screen.PrintBoard(match.board);
        Console.WriteLine();
        Console.Write("Origin: ");
        Position origin = Screen.ReadPositionChess().ToPosition();
        Console.Write("Destination: ");
        Position destination = Screen.ReadPositionChess().ToPosition();
        match.ExecuteMovement(origin, destination);

    }



}

catch (BoardExeption exeption)
{
    Console.WriteLine(exeption.Message);
}


