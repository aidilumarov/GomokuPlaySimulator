using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    readonly public struct Cell : IGomokuCell
    {
        public int Row { get; }

        public int Column { get; }

        public Cell(int row, int col)
        {
            Row = row;
            Column = col;
        }

        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
    }
}
