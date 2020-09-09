﻿using System;
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
                numberOfFreeCells -= 1;

                if (numberOfFreeCells == 0 && BoardIsFull != null)
                {
                    var localCopy = BoardIsFull;
                    localCopy();                    
                }
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
        /// <returns></returns>
        public bool IsEmptyCell(IGomokuCell cell)
        {
            return IsEmptyCell(cell.Row, cell.Column);
        }

        public List<IGomokuCell> GetEmptyCells()
        {
            var list = new List<IGomokuCell>(numberOfFreeCells);

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

        public bool IsThereAnyFiveInARow(int col, int row)
        {
            return IsThereAnyFiveInARow(new Cell(col, row));
        }

        /// <summary>
        /// Checks if a given characters appears five times in a row.
        /// Horizontal, vertical, and two diagonals are considered
        /// </summary>
        /// <param name="move">Position to check</param>
        /// <returns>true if there are five given characters in a row</returns>
        public bool IsThereAnyFiveInARow(IGomokuCell move)
        {
            // Check horizontal
            return CheckHorizontal(move);
        }

        #endregion

        #region PrivateMethods

        private bool CheckHorizontal(IGomokuCell move)
        {
            var contigious = 1;

            var nextRow = move.Row;
            var nextColumn = move.Column - 1;

            // Check backwards
            while (nextColumn >= 0)
            {
                if (this[nextRow, nextColumn] == this[move])
                {
                    contigious += 1;
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
                }

                else
                {
                    break;
                }

                nextColumn += 1;
            }

            return contigious == 5;
        }

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
