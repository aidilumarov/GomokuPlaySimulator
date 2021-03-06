﻿using System;
using System.Threading;

namespace GomokuPlaySimulator.Core
{
    public class Game
    {
        public IGomokuBoard Board { get; private set; }

        public IGomokuPlayer Player1 { get; private set; }

        public IGomokuPlayer Player2 { get; private set; }

        public IGomokuPlayer CurrentPlayer { get; private set; }

        public IGomokuPlayer PreviousPlayer { get; private set; }

        public IGomokuPlayer Winner { get; private set; }

        public bool GameIsOver { get; private set; }

        public Game(int boardSize = 15, char player1Char = 'X', char player2Char = '0')
        {
            Board = new Board(boardSize);
            Player1 = new Player(player1Char);
            Player2 = new Player(player2Char);
        }

        public IGomokuPlayer Start()
        {
            CurrentPlayer = Player1;
            var firstMove = CurrentPlayer.GetRandomMove(Board);
            Board[firstMove] = CurrentPlayer.PlayerCharacter;

            while (!GameIsOver)
            {
                Board.DrawBoard();
                NextTurn();
            }

            if (Winner != null)
            {
                Board.DrawWinCombination();
                return Winner;
            }

            else
            {
                return null;
            }
        }

        private void NextTurn()
        {
            if (Board.FreeCellCount <= 0)
            {
                GameIsOver = true;
                return;
            }

            SwitchCurrentPlayer();
            var nextMove = CurrentPlayer.GetNextBestMove(Board, PreviousPlayer);

            if (nextMove != null)
            {
                Board[nextMove] = CurrentPlayer.PlayerCharacter;
            }

            if (Board.IsThereAnyFiveInARow(nextMove))
            {
                GameIsOver = true;
                Winner = CurrentPlayer;
            }

        }

        private void SwitchCurrentPlayer()
        {
            PreviousPlayer = CurrentPlayer;

            if (CurrentPlayer == Player1)
            {
                CurrentPlayer = Player2;
                return;
            }

            CurrentPlayer = Player1;
        }
    }
}
