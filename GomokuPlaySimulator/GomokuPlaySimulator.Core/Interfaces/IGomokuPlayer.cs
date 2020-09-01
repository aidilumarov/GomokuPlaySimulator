using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    public interface IGomokuPlayer
    {
        IGomokuCell GetNextBestMove();

        IGomokuCell GetRandomMove();
    }
}
