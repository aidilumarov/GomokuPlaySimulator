using System;
using GomokuPlaySimulator.Core;

namespace GomokuPlaySimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var winner = game.Start();
            Console.WriteLine($"Winner is {winner.PlayerCharacter}");
        }
    }
}
