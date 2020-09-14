using GomokuPlaySimulator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GomokuPlaySimulator.Core
{
    internal class MinimaxGomokuMoveGetter : IBestGomokuMoveGetter
    {
        public IGomokuCell GetBestMove(IGomokuPlayer currentPlayer,
            IGomokuPlayer opponent,
            IGomokuBoard board,
            int depth)
        {
            var emptyCells = board.GetEmptyCellsInDenseRegion();
            
            if (!emptyCells.Any())
            {
                emptyCells = board.GetEmptyCells();
            }

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

            return bestMove.Cell;
        }

        private AIMove Minimax(
            IGomokuPlayer currentPlayer,
            IGomokuPlayer opponent,
            IGomokuBoard board, 
            IGomokuCell lastMove, 
            bool maximizing, 
            int depth)
        {
            var emptyCells = board.GetEmptyCellsInDenseRegion();

            if (!emptyCells.Any())
            {
                emptyCells = board.GetEmptyCells();
            }

            // Terminal conditions
            if (board.IsThereAnyFiveInARow(lastMove) || !emptyCells.Any())
            {
                var score = maximizing ? Score.ThisPlayerWins : Score.OpponentWins;
                return new AIMove(score, lastMove);
            }

            if (depth <= 0)
            {
                Score score;

                if (board.IsThereAnyFiveInARow(lastMove))
                {
                    score = maximizing ? Score.ThisPlayerWins : Score.OpponentWins;
                }

                else
                {
                    score = Score.Tie;
                }

                return new AIMove(score, lastMove);
            }

            AIMove bestMove = new AIMove(Score.Default, emptyCells[0]);

            if (maximizing)
            {
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
