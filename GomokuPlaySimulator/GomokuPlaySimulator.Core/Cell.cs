using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    internal struct Cell : IGomokuCell
    {
        public int Row { get; private set; }

        public int Column { get; private set; }

        public Cell(int row, int col)
        {
            Row = row;
            Column = col;
        }
    }
}
