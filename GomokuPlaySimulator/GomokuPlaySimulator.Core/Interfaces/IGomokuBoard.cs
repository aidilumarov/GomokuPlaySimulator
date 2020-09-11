using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    public interface IGomokuBoard
    {
        int BoardSize { get; }

        int FreeCellCount { get; }

        bool IsEmptyCell(int row, int col);

        List<IGomokuCell> GetEmptyCells();

        bool IsThereAnyFiveInARow(IGomokuCell move);

        char this[int row, int col] { get; set; }

        char this[IGomokuCell move] { get; set; }


    }
}
