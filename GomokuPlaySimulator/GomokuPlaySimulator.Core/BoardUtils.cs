using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    public static class BoardUtils
    {
        public static void DrawBoard(this IGomokuBoard board)
        {
            // drawing rows
            for (int i = 0; i < board.BoardSize; i++)
            {
                Console.Write(" ");

                // drawing columns
                for (int j = 0; j < board.BoardSize; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
