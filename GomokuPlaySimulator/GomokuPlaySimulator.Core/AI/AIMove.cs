using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    internal struct AIMove
    {
        public Score Score;
        public IGomokuCell Cell;

        public AIMove(Score score, IGomokuCell cell)
        {
            Score = score;
            Cell = cell;
        }
    }
}
