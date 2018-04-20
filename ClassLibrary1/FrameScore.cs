using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame1
{
    public class FrameScore
    {
        public FrameScore()
        {
            Score = BonusRolls = 0;
        }

        public int Score { get; set; }
        public int BonusRolls { get; set; }

    }
}
