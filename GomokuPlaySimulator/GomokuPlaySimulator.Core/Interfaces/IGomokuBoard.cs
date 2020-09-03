using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    public interface IGomokuBoard
    {
        int BoardSize { get; }

        event Action BoardIsFull;

        bool IsEmptyCell(int row, int col);

        char this[int row, int col] { get; set; }

        char this[IGomokuCell move] { get; set; }


    }
}
