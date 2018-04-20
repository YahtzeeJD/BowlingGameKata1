using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame1
{
    public class Frame
    {
        public Frame(List<Roll> rolls)
        {
            Rolls = rolls;
            FrameScore = new FrameScore();
        }

        public List<Roll> Rolls { get; set; }
        public FrameScore FrameScore { get; set; }

    }
}
