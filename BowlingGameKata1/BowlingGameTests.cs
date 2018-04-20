using System;
using System.Collections.Generic;
using System.Text;
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

    }
}
