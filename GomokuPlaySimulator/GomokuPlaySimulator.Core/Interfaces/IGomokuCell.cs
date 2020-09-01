using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    public interface IGomokuCell
    {
        int Row { get; }
        int Column { get; }
    }
}
