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
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(0, 3)]
        [TestCase(0, 4)]
        public void CheckHorizontal_ReturnsTrue(int row, int col)
        {
            var board = new Board(15);

            board[0, 0] = 'X';
            board[0, 1] = 'X';
            board[0, 2] = 'X';
            board[0, 3] = 'X';
            board[0, 4] = 'X';

            Assert.IsTrue(board.CheckHorizontal(new Cell(row, col)));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(0, 3)]
        [TestCase(0, 4)]
        public void CheckHorizontal_ReturnsFalse(int row, int col)
        {
            var board = new Board(15);

            board[0, 0] = 'X';
            board[0, 1] = 'X';
            board[0, 3] = 'X';
            board[0, 4] = 'X';

            Assert.IsFalse(board.CheckHorizontal(new Cell(row, col)));
        }

        [Test]
        [TestCase(4, 4)]
        [TestCase(5, 4)]
        [TestCase(6, 4)]
        [TestCase(7, 4)]
        [TestCase(8, 4)]
        public void CheckVertical_ReturnsTrue(int row, int col)
        {
            var board = new Board(15);

            board[4, 4] = 'X';
            board[5, 4] = 'X';
            board[6, 4] = 'X';
            board[7, 4] = 'X';
            board[8, 4] = 'X';

            Assert.IsTrue(board.CheckVertical(new Cell(row, col)));
        }

        [Test]
        [TestCase(4, 4)]
        [TestCase(5, 4)]
        [TestCase(6, 4)]
        [TestCase(7, 4)]
        [TestCase(8, 4)]
        public void CheckVertical_ReturnsFalse(int row, int col)
        {
            var board = new Board(15);

            board[4, 4] = 'X';
            board[5, 4] = 'X';
            board[7, 4] = 'X';
            board[8, 4] = 'X';

            Assert.IsFalse(board.CheckVertical(new Cell(row, col)));
        }

        [Test]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        [TestCase(6, 6)]
        [TestCase(7, 7)]
        [TestCase(8, 8)]
        public void CheckDiagonalDownward_ReturnsTrue(int row, int col)
        {
            var board = new Board(15);

            board[4, 4] = 'X';
            board[5, 5] = 'X';
            board[6, 6] = 'X';
            board[7, 7] = 'X';
            board[8, 8] = 'X';

            Assert.IsTrue(board.CheckDiagonalDownward(new Cell(row, col)));
        }

        [Test]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        [TestCase(6, 6)]
        [TestCase(7, 7)]
        [TestCase(8, 8)]
        public void CheckDiagonalDownward_ReturnsFalse(int row, int col)
        {
            var board = new Board(15);

            board[4, 4] = 'X';
            board[5, 5] = 'X';
            board[7, 7] = 'X';
            board[8, 8] = 'X';

            Assert.IsFalse(board.CheckDiagonalDownward(new Cell(row, col)));
        }

        [Test]
        [TestCase(14, 0)]
        [TestCase(13, 1)]
        [TestCase(12, 2)]
        [TestCase(11, 3)]
        [TestCase(10, 4)]
        public void CheckDiagonalUpward_ReturnsTrue(int row, int col)
        {
            var board = new Board(15);

            board[14, 0] = 'X';
            board[13, 1] = 'X';
            board[12, 2] = 'X';
            board[11, 3] = 'X';
            board[10, 4] = 'X';

            Assert.IsTrue(board.CheckDiagonalUpward(new Cell(row, col)));
        }

        [Test]
        [TestCase(14, 0)]
        [TestCase(13, 1)]
        [TestCase(12, 2)]
        [TestCase(11, 3)]
        [TestCase(10, 4)]
        public void CheckDiagonalUpward_ReturnsFalse(int row, int col)
        {
            var board = new Board(15);

            board[14, 0] = 'X';
            board[13, 1] = 'X';
            board[11, 3] = 'X';
            board[10, 4] = 'X';

            Assert.IsFalse(board.CheckDiagonalUpward(new Cell(row, col)));
        }
    }
}