﻿using System.Threading;

namespace GomokuPlaySimulator.Core
{
    public class Game
    {
        public IGomokuBoard Board { get; private set; }

        public IGomokuPlayer Player1 { get; private set; }

        public IGomokuPlayer Player2 { get; private set; }

        public IGomokuPlayer CurrentPlayer { get; private set; }

        public IGomokuPlayer PreviousPlayer { get; private set; }

        public bool GameIsOver { get; private set; }

        public Game(int boardSize = 15, char player1Char = 'X', char player2Char = '0')
        {
            Board = new Board(boardSize);
            Player1 = new Player(player1Char);
            Player2 = new Player(player2Char);
            
            Board.BoardIsFull += OnBoardIsFull;
        }

        public void Start()
        {
            CurrentPlayer = Player1;
            var firstMove = CurrentPlayer.GetRandomMove(Board);
            Board[firstMove] = CurrentPlayer.PlayerCharacter;

            while (!GameIsOver)
            {
                Board.DrawBoard();
                Thread.Sleep(500);
                NextTurn();
            }
        }

        private void NextTurn()
        {
            SwitchCurrentPlayer();
            var nextMove = CurrentPlayer.GetRandomMove(Board);
            Board[nextMove] = CurrentPlayer.PlayerCharacter;

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

        private IGomokuPlayer CheckWinner(IGomokuBoard gameState, IGomokuCell lastMove)
        {
            return null;
        }

        private void OnBoardIsFull()
        {
            GameIsOver = true;
        }
    }
}
