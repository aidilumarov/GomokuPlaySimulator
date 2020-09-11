using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        public static void DrawWinCombination(this IGomokuBoard board)
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
                    foreach (var cell in board.FiveInARowCells)
                    {
                        if (cell.Row == i && cell.Column == j)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }

                    Console.Write($"{board[i, j]} ");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}
