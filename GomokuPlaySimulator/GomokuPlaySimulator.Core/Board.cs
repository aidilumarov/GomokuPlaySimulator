using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GomokuPlaySimulator.Core
{
    public class Board : IGomokuBoard
    {
        #region Fields
        public readonly char defaultChar = '-';

        private readonly char[,] board;

        #endregion

        #region Properties

        public int BoardSize { get; private set; }

        public int FreeCellCount { get; private set; }

        public List<IGomokuCell> FiveInARowCells { get; private set; }

        #endregion

        #region Constructor

        public Board(int size)
        {
            BoardSize = size;
            FreeCellCount = BoardSize * BoardSize;
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
        /// <returns>Cell value</returns>
        /// <exception cref="ArgumentException"></exception>
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
                FreeCellCount -= 1;
            }
        }

        /// <summary>
        /// Assign a char value to a cell. If cell is not free, exception will be thrown
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        /// <returns>Cell value</returns>
        /// <exception cref="ArgumentException"></exception>
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
        /// <returns>true if the cell is empty</returns>
        public bool IsEmptyCell(IGomokuCell cell)
        {
            return IsEmptyCell(cell.Row, cell.Column);
        }

        /// <summary>
        /// Returns a list of currently empty cells
        /// </summary>
        /// <returns>list of cell</returns>
        public List<IGomokuCell> GetEmptyCells()
        {
            var list = new List<IGomokuCell>(FreeCellCount);

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (IsEmptyCell(i, j))
                    {
                        list.Add(new Cell(i, j));
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Marks a cell as empty
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void MarkCellAsEmpty(int row, int col)
        {
            board[row, col] = defaultChar;
            FreeCellCount += 1;
        }

        /// <summary>
        /// Marks a cell as empty
        /// </summary>
        /// <param name="cell"></param>
        public void MarkCellAsEmpty(IGomokuCell cell)
        {
            MarkCellAsEmpty(cell.Row, cell.Column);
        }

        /// <summary>
        /// Checks if a given character appears five times in a row.
        /// Horizontal, vertical, and two diagonals are considered
        /// </summary>
        /// <param name="move">Position to check</param>
        /// <returns>true if there are five given characters in a row</returns>
        public bool IsThereAnyFiveInARow(int col, int row)
        {
            return IsThereAnyFiveInARow(new Cell(col, row));
        }

        /// <summary>
        /// Checks if a given character appears five times in a row.
        /// Horizontal, vertical, and two diagonals are considered
        /// </summary>
        /// <param name="move">Position to check</param>
        /// <returns>true if there are five given characters in a row</returns>
        public bool IsThereAnyFiveInARow(IGomokuCell move)
        {
            return CheckHorizontal(move) ||
                    CheckVertical(move) ||
                    CheckDiagonalDownward(move) ||
                    CheckDiagonalUpward(move);
        }

        /// <summary>
        /// Checks if a given character appears five times in a row
        /// Check is performed horizontally
        /// </summary>
        /// <param name="move">Position to check</param>
        /// <returns>true if there are five given characters in a row</returns>
        public bool CheckHorizontal(IGomokuCell move)
        {
            if (IsEmptyCell(move)) return false;

            var contigious = 1;
            var contigiousCells = new List<IGomokuCell>();
            contigiousCells.Add(move);

            var nextRow = move.Row;
            var nextColumn = move.Column - 1;

            // Check backwards
            while (nextColumn >= 0)
            {
                if (this[nextRow, nextColumn] == this[move])
                {
                    contigious += 1;
                    contigiousCells.Add(new Cell(nextRow, nextColumn));
                }

                else
                {
                    break;
                }

                nextColumn -= 1;
            }

            nextColumn = move.Column + 1;

            // Check forward
            while (nextColumn < this.BoardSize)
            {
                if (this[nextRow, nextColumn] == this[move])
                {
                    contigious += 1;
                    contigiousCells.Add(new Cell(nextRow, nextColumn));
                }

                else
                {
                    break;
                }

                nextColumn += 1;
            }

            if (contigious == 5)
            {
                FiveInARowCells = contigiousCells;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a given character appears five times in a row
        /// Check is performed vertically
        /// </summary>
        /// <param name="move">Position to check</param>
        /// <returns>true if there are five given characters in a row</returns>
        public bool CheckVertical(IGomokuCell move)
        {
            if (IsEmptyCell(move)) return false;

            var contigious = 1;
            var contigiousCells = new List<IGomokuCell>();
            contigiousCells.Add(move);

            var nextRow = move.Row - 1;
            var nextColumn = move.Column;

            // Check backwards
            while (nextRow >= 0)
            {
                if (this[nextRow, nextColumn] == this[move])
                {
                    contigious += 1;
                    contigiousCells.Add(new Cell(nextRow, nextColumn));
                }

                else
                {
                    break;
                }

                nextRow -= 1;
            }

            nextRow = move.Row + 1;

            // Check toward bottom
            while (nextRow < this.BoardSize)
            {
                if (this[nextRow, nextColumn] == this[move])
                {
                    contigious += 1;
                    contigiousCells.Add(new Cell(nextRow, nextColumn));
                }

                else
                {
                    break;
                }

                nextRow += 1;
            }

            if (contigious == 5)
            {
                FiveInARowCells = contigiousCells;
                return true;
            }

            return false;
        }


        /// <summary>
        /// Checks if a given character appears five times in a row
        /// Downward facing diagonal is checked
        /// </summary>
        /// <param name="move">Position to check</param>
        /// <returns>true if there are five given characters in a row</returns>
        public bool CheckDiagonalDownward(IGomokuCell move)
        {
            if (IsEmptyCell(move)) return false;

            var contigious = 1;
            var contigiousCells = new List<IGomokuCell>();
            contigiousCells.Add(move);

            var nextRow = move.Row - 1;
            var nextColumn = move.Column - 1;

            // Check backwards
            while (nextRow >= 0 && nextColumn >= 0)
            {
                if (this[nextRow, nextColumn] == this[move])
                {
                    contigious += 1;
                    contigiousCells.Add(new Cell(nextRow, nextColumn));
                }

                else
                {
                    break;
                }

                nextRow -= 1;
                nextColumn -= 1;
            }

            nextRow = move.Row + 1;
            nextColumn = move.Column + 1;

            // Check toward bottom
            while (nextRow < this.BoardSize && nextColumn < this.BoardSize)
            {
                if (this[nextRow, nextColumn] == this[move])
                {
                    contigious += 1;
                    contigiousCells.Add(new Cell(nextRow, nextColumn));
                }

                else
                {
                    break;
                }

                nextRow += 1;
                nextColumn += 1;
            }

            if (contigious == 5)
            {
                FiveInARowCells = contigiousCells;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a given character appears five times in a row
        /// Upward facing diagonal is checked
        /// </summary>
        /// <param name="move">Position to check</param>
        /// <returns>true if there are five given characters in a row</returns>
        public bool CheckDiagonalUpward(IGomokuCell move)
        {
            if (IsEmptyCell(move)) return false;

            var contigious = 1;
            var contigiousCells = new List<IGomokuCell>();
            contigiousCells.Add(move);

            var nextRow = move.Row + 1;
            var nextColumn = move.Column - 1;

            // Check backwards
            while (nextRow < this.BoardSize && nextColumn >= 0)
            {
                if (this[nextRow, nextColumn] == this[move])
                {
                    contigious += 1;
                    contigiousCells.Add(new Cell(nextRow, nextColumn));
                }

                else
                {
                    break;
                }

                nextRow += 1;
                nextColumn -= 1;
            }

            nextRow = move.Row - 1;
            nextColumn = move.Column + 1;

            // Check toward bottom
            while (nextRow >= 0 && nextColumn < this.BoardSize)
            {
                if (this[nextRow, nextColumn] == this[move])
                {
                    contigious += 1;
                    contigiousCells.Add(new Cell(nextRow, nextColumn));
                }

                else
                {
                    break;
                }

                nextRow -= 1;
                nextColumn += 1;
            }

            if (contigious == 5)
            {
                FiveInARowCells = contigiousCells;
                return true;
            }

            return false;
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
                throw new ArgumentException("Cannot mark field as empty using indexer.");
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
