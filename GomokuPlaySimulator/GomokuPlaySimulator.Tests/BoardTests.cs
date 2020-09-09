using GomokuPlaySimulator.Core;
using NUnit.Framework;

namespace GomokuPlaySimulator.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsThereAnyFiveInARow_ReturnsTrue()
        {
            var board = new Board(15);

            board[0, 0] = 'X';
            board[0, 1] = 'X';
            board[0, 2] = 'X';
            board[0, 3] = 'X';
            board[0, 4] = 'X';

            Assert.IsTrue(board.IsThereAnyFiveInARow(0, 0));
        }
    }
}