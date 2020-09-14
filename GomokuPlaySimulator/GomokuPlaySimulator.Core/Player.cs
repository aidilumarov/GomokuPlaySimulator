using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    internal class Player : IGomokuPlayer
    {
        public char PlayerCharacter { get; private set; }

        public Player(char playerCharacter)
        {
            PlayerCharacter = playerCharacter;
        }

        public IGomokuCell GetNextBestMove(IGomokuBoard gameState, IGomokuPlayer opponent)
        {
            var minimax = new MinimaxGomokuMoveGetter();
            return minimax.GetBestMove(this, opponent, gameState, 2);
        }

        public IGomokuCell GetRandomMove(IGomokuBoard gameState)
        {
            var emptyCells = gameState.GetEmptyCells();

            var randomNumberGenerator = new Random();
            var randomIndex = randomNumberGenerator.Next(0, emptyCells.Count);

            return emptyCells[randomIndex];
        }
    }
}
