using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    public interface IGomokuBoard
    {
        int BoardSize { get; }

        bool IsEmptyCell(int row, int col);

        char this[int row, int col] { get; set; }


    }
}
