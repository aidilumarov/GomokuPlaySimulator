using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GomokuPlaySimulator.Core
{
    internal class Board : IGomokuBoard
    {
        #region Fields
        public readonly char defaultChar = '-';

        private readonly char[,] board;

        private int numberOfFreeCells;

        #endregion

        #region Properties

        public int BoardSize { get; private set; }

        #endregion

        #region Events

        public event Action BoardIsFull;

        #endregion

        #region Constructor

        public Board(int size)
        {
            BoardSize = size;
            numberOfFreeCells = BoardSize * BoardSize;
            board = new char[BoardSize, BoardSize];
            InitializeBoard();
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// Assign a char value to a cell. If cell is not free, exception will be thrown
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        /// <returns></returns>
        public char this[int row, int col]
        {
            get
            {
                return board[row, col];
            }
            
            set
            {
                CheckProvidedCellValueIsValid(value);
                CheckRequestedCellIsEmpty(row, col);

                board[row, col] = value;
                numberOfFreeCells -= 1;

                if (numberOfFreeCells == 0)
                {
                    BoardIsFull();                    
                }
            }
        }

        /// <summary>
        /// Assign a char value to a cell. If cell is not free, exception will be thrown
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        /// <returns></returns>
        public char this[IGomokuCell cell]
        {
            get
            {
                return this[cell.Row, cell.Column];
            }

            set
            {
                this[cell.Row, cell.Column] = value;
            }
        }

        /// <summary>
        /// Check if a cell is empty.
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        /// <returns></returns>
        public bool IsEmptyCell(int row, int col)
        {
            return this[row, col] == defaultChar;
        }

        /// <summary>
        /// Check if a cell is empty.
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        /// <returns></returns>
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
                throw new ArgumentException("Cannot mark field as empty.");
            }
        }

        private void CheckRequestedCellIsEmpty(int row, int col)
        {
            if (!IsEmptyCell(row, col))
            {
                throw new ArgumentException("Cannot reassign occupied field.");
            }
        }

        #endregion
    }
}
