using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GomokuPlaySimulator.Core
{
    public static class BoardUtils
    {
        public static void DrawBoard(this IGomokuBoard board)
        {
            // Clear console
            Console.Clear();

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
