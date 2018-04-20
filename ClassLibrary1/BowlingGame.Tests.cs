using BowlingGame1;
using System.Collections.Generic;
using Xunit;

namespace BowlingGameKata1
{
    public class BowlingGameTests
    {
        public BowlingGameTests()
        {
        }

        [Fact]
        public void CanCreate()
        {
            var game = new BowlingGame();
            Assert.NotNull(game);
        }

        [Fact]
        public void CanAddFrameToGame()
        {
            var game = new BowlingGame();
            var frame = CreateFrame(new int[1]);
            game.AddFrame(frame);
            Assert.Single(game.Frames);
        }

        [Fact]
        public void CanScoreAnOpenFrame()
        {
            var game = CreateGame(new List<int[]>()
                {
                    new int[] { 1, 5 }
                }
            );

            var expected = 1 + 5;
            var actual = game.ScoreGame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanScoreAFrameWithASpare()
        {
            var game = CreateGame(new List<int[]>()
                {
                    new int[] { 4, 6 },
                    new int[] { 5, 2 }
                }
            );

            var expected = 4 + 6 + (5) + 5 + 2;
            var actual = game.ScoreGame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanScoreAnAllSparesGame()
        {
            var game = CreateGame(new List<int[]>()
                {
                    new int[] { 1, 9 },
                    new int[] { 2, 8 },
                    new int[] { 3, 7 },
                    new int[] { 4, 6 },
                    new int[] { 5, 5 },
                    new int[] { 6, 4 },
                    new int[] { 7, 3 },
                    new int[] { 8, 2 },
                    new int[] { 9, 1 },
                    new int[] { 1, 9, 4 }
                }
            );

            var expected = 1 + 9 + (2) + 2 + 8 + (3) + 3 + 7 + (4) + 4 + 6 + (5) +
                5 + 5 + (6) + 6 + 4 + (7) + 7 + 3 + (8) + 8 + 2 + (9) + 9 + 1 + (1) + 1 + 9 + 4;
            var actual = game.ScoreGame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanScoreAnAllOpenGame()
        {
            var game = CreateGame(new List<int[]>()
                {
                    new int[] { 1, 9 },
                    new int[] { 2, 8 },
                    new int[] { 3, 7 },
                    new int[] { 4, 6 },
                    new int[] { 5, 5 },
                    new int[] { 6, 4 },
                    new int[] { 7, 3 },
                    new int[] { 8, 2 },
                    new int[] { 4, 1 },
                    new int[] { 2, 2 }
                }
            );

            var expected = 1 + 9 + (2) + 2 + 8 + (3) + 3 + 7 + (4) + 4 + 6 + (5) + 
				5 + 5 + (6) + 6 + 4 + (7) + 7 + 3 + (8) + 8 + 2 + (4) + 4 + 1 + 2 + 2;
            var actual = game.ScoreGame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanScoreAFrameWithAStrike()
        {
            var game = CreateGame(new List<int[]>()
                {
                    new int[] { 10 },
                    new int[] { 5, 2 }
                }
            );

            var expected = 10 + (5 + 2) + 5 + 2;
            var actual = game.ScoreGame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanScoreAFrameWithConsecutiveStrikes()
        {
            var game = CreateGame(new List<int[]>()
                {
                    new int[] { 10 },
                    new int[] { 10 },
                    new int[] { 10 },
                    new int[] { 4, 1 }
                }
            );

            var expected = 10 + (10 + 10) + 10 + (10 + 4) + 10 + (4 + 1) + 4 + 1;
            var actual = game.ScoreGame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanScoreAnAlmostPerfectGame()
        {
            var game = new BowlingGame();

            var frame = CreateFrame(new int[] { 10 });
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);

            frame = CreateFrame(new int[] { 10, 10, 9 });
            game.AddFrame(frame);

            var expected = 10 + (10 + 10) + 10 + (10 + 10) + 10 + (10 + 10) +
                10 + (10 + 10) + 10 + (10 + 10) + 10 + (10 + 10) +
                10 + (10 + 10) + 10 + (10 + 10) + 10 + (10 + 10) +
                10 + 10 + 9;
            var actual = game.ScoreGame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanScoreAPerfectGame()
        {
            var game = new BowlingGame();

            var frame = CreateFrame(new int[] { 10 });
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);

            frame = CreateFrame(new int[] { 10, 10, 10 });
            game.AddFrame(frame);

            var expected = 10 + (10 + 10) + 10 + (10 + 10) + 10 + (10 + 10) +
                10 + (10 + 10) + 10 + (10 + 10) + 10 + (10 + 10) +
                10 + (10 + 10) + 10 + (10 + 10) + 10 + (10 + 10) +
                10 + 10 + 10;
            var actual = game.ScoreGame();
            Assert.Equal(expected, actual);
        }


        private BowlingGame CreateGame(List<int[]> arrayOfPins)
        {
            var game = new BowlingGame();
            foreach (var pins in arrayOfPins)
            {
                game.AddFrame(CreateFrame(pins));
            }
            return game;
        }

        private Frame CreateFrame(int[] pins)
        {
            var rolls = new List<Roll>();

            foreach (var roll in pins)
            {
                rolls.Add(new Roll(roll));
            }
            return new Frame(rolls);
        }

    }
}
