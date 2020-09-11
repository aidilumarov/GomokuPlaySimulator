using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    internal enum Score
    {
        Default = int.MinValue,
        ThisPlayerWins = 10,
        OpponentWins = -10,
        Tie = 0
    }
}
