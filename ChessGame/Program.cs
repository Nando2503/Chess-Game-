﻿using System;
using board;
using ChessGame;
using Game;

try
{
    Board board = new Board(8, 8);
    board.PutPiece(new Tower(board, Color.Black), new Position(0, 0));
    board.PutPiece(new Tower(board, Color.Black), new Position(1, 3));
    board.PutPiece(new King(board, Color.Black), new Position(2, 4));
    Screen.PrintBoard(board);
}

catch (BoardExeption exeption)
{
    Console.WriteLine(exeption.Message);
}
Console.ReadLine();

