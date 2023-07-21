using ChessChallenge.API;
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class MyBot : IChessBot
{
    //Phases 
    //0=Opening
    //2=Middle Game
    //3=Endgame
    int phase = 0;

    Dictionary<ulong, Move> storedMoves = new Dictionary<ulong, Move>();

    public Move Think(Board board, Timer timer)
    {
        ulong key = board.ZobristKey;
        if (storedMoves.ContainsKey(key)) return storedMoves[key];
        Move move = new Move();


        Move[] moves = board.GetLegalMoves();
        move = moves[new Random().Next(moves.Length)];

        storedMoves[key] = move;
        return move; ;
    }
}