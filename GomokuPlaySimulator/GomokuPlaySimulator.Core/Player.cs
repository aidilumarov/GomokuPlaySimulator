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

        public IGomokuCell GetNextBestMove(IGomokuBoard gameState)
        {
            throw new NotImplementedException();
        }

        public IGomokuCell GetRandomMove(IGomokuBoard gameState)
        {
            var randomNumberGenerator = new Random();
            var randomRow = randomNumberGenerator.Next(0, gameState.BoardSize);
            var randomCol = randomNumberGenerator.Next(0, gameState.BoardSize);

            return new Move(randomRow, randomCol);
        }
    }
}
