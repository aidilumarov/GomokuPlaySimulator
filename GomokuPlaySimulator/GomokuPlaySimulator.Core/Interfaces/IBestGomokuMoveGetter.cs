using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core.Interfaces
{
    public interface IBestGomokuMoveGetter
    {
        IGomokuCell GetBestMove(IGomokuPlayer currentPlayer,
            IGomokuPlayer opponent,
            IGomokuBoard board,
            int depth);
    }
}
