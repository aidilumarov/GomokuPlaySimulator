using GomokuPlaySimulator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    internal class MinimaxGomokuMoveGetter : IBestGomokuMoveGetter
    {
        public AIMove GetBestMove(IGomokuPlayer currentPlayer,
            IGomokuPlayer opponent,
            IGomokuBoard board,
            int depth)
        {
            var emptyCells = board.GetEmptyCells();
            AIMove bestMove = new AIMove(Score.Default, emptyCells[0]);

            foreach (var cell in emptyCells)
            {
                board[cell] = currentPlayer.PlayerCharacter;
                var potentialMove = Minimax(opponent, currentPlayer, board, cell, true, depth - 1);
                board.MarkCellAsEmpty(cell);

                if (potentialMove.Score > bestMove.Score)
                {
                    bestMove = potentialMove;
                }
            }

            return bestMove;
        }

        private AIMove Minimax(
            IGomokuPlayer currentPlayer,
            IGomokuPlayer opponent,
            IGomokuBoard board, 
            IGomokuCell lastMove, 
            bool maximizing, 
            int depth)
        {
            // Terminal conditions
            if (board.IsThereAnyFiveInARow(lastMove))
            {
                var score = maximizing ? Score.OpponentWins : Score.ThisPlayerWins;
                return new AIMove(score, lastMove);
            }

            if (depth <= 0)
            {
                Score score;

                if (board.IsThereAnyFiveInARow(lastMove))
                {
                    score = maximizing ? Score.OpponentWins : Score.ThisPlayerWins;
                }

                else
                {
                    score = Score.Tie;
                }

                return new AIMove(score, lastMove);
            }

            if (maximizing)
            {
                var emptyCells = board.GetEmptyCells();
                AIMove bestMove = new AIMove(Score.Default, emptyCells[0]);

                foreach (var cell in emptyCells)
                {
                    board[cell] = currentPlayer.PlayerCharacter;
                    var potentialMove = Minimax(opponent, currentPlayer, board, cell, false, depth - 1);
                    board.MarkCellAsEmpty(cell);

                    if (potentialMove.Score > bestMove.Score)
                    {
                        bestMove = potentialMove;
                    }
                }

                return bestMove;
            }

            else
            {
                var emptyCells = board.GetEmptyCells();
                AIMove bestMove = new AIMove(Score.Default, emptyCells[0]);

                foreach (var cell in emptyCells)
                {
                    board[cell] = currentPlayer.PlayerCharacter;
                    var potentialMove = Minimax(opponent, currentPlayer, board, cell, true, depth - 1);
                    board.MarkCellAsEmpty(cell);

                    if (potentialMove.Score < bestMove.Score)
                    {
                        bestMove = potentialMove;
                    }
                }

                return bestMove;
            }
        }
    }
}
