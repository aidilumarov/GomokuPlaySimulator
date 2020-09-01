using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    public interface IGomokuPlayer
    {
        char PlayerCharacter { get; }

        IGomokuCell GetNextBestMove(IGomokuBoard gameState);

        IGomokuCell GetRandomMove(IGomokuBoard gameState);
    }
}
