using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    internal struct Move : IGomokuCell
    {
        public int Row { get; private set; }

        public int Column { get; private set; }

        public Move(int row, int col)
        {
            Row = row;
            Column = col;
        }
    }
}
