using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    readonly internal struct Cell : IGomokuCell
    {
        public int Row { get; }

        public int Column { get; }

        public Cell(int row, int col)
        {
            Row = row;
            Column = col;
        }
    }
}
