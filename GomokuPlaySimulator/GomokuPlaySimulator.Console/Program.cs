using System;
using GomokuPlaySimulator.Core;

namespace GomokuPlaySimulator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Start();
            game.Board.DrawBoard();
        }
    }
}
