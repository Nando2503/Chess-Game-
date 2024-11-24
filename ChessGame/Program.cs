using System;
using System.Linq.Expressions;
using board;
using ChessGame;
using Game;
try
{



    ChessMatch match = new ChessMatch();
    while (!match.Finished)
    {

        try
        {


            Console.Clear();
            Screen.PressMatch(match);
            Console.WriteLine();
            Console.Write("Origin: ");
            Position origin = Screen.ReadPositionChess().ToPosition();
            match.OriginPValidation(origin);

            bool[,] possibleposition = match.board.piece(origin).PossibleMoves();

            Console.Clear();
            Screen.PrintBoard(match.board, possibleposition);

            Console.WriteLine();
            Console.Write("Destination: ");
            Position destination = Screen.ReadPositionChess().ToPosition();
            match.DestinyPValidation(origin, destination);
            match.RealizePlay(origin, destination);
        }
        catch (BoardExeption e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

    }
    Console.Clear();
    Screen.PressMatch(match);
}
catch (BoardExeption exeption)
{
    Console.WriteLine(exeption.Message);
}





