using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    public interface IGomokuBoard
    {
        int BoardSize { get; }

        int FreeCellCount { get; }

        List<IGomokuCell> FiveInARowCells { get; }

        bool IsEmptyCell(int row, int col);

        List<IGomokuCell> GetEmptyCells();

        void MarkCellAsEmpty(IGomokuCell move);

        void MarkCellAsEmpty(int row, int col);

        bool IsThereAnyFiveInARow(IGomokuCell move);

        char this[int row, int col] { get; set; }

        char this[IGomokuCell move] { get; set; }


    }
}
