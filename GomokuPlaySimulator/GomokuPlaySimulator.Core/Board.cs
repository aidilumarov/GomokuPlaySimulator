using System;
using System.Runtime.InteropServices;

namespace GomokuPlaySimulator.Core
{
    internal class Board : IGomokuBoard
    {
        #region Fields

        private readonly char[,] board;

        private char defaultChar = '-';

        #endregion

        #region Properties

        public int BoardSize { get; private set; }

        #endregion

        #region Constructor

        public Board(int size)
        {
            BoardSize = size;
            board = new char[BoardSize, BoardSize];
            InitializeBoard();
        }

        #endregion

        #region PublicMethods

        public char this[int row, int col]
        {
            get
            {
                return board[row, col];
            }
            
            set
            {
                CheckProvidedCellValueIsValid(value);
                board[row, col] = value;
            }
        }

        public char this[IGomokuCell cell]
        {
            get
            {
                return board[cell.Row, cell.Column];
            }

            set
            {
                CheckProvidedCellValueIsValid(value);
                board[cell.Row, cell.Column] = value;
            }
        }

        public bool IsEmptyCell(int row, int col)
        {
            return this[row, col] == defaultChar;
        }

        public bool IsEmptyCell(IGomokuCell cell)
        {
            return IsEmptyCell(cell.Row, cell.Column);
        }

        #endregion

        #region PrivateMethods

        private void InitializeBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    board[i, j] = defaultChar;
                }
            }
        }

        private void CheckProvidedCellValueIsValid(char value)
        {
            if (value == defaultChar)
            {
                throw new ArgumentException("Cannot mark occupied field as empty.");
            }
        }

        #endregion
    }
}
