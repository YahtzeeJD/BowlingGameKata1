using BowlingGame1;
using System.Collections.Generic;

namespace BowlingGameKata1
{
    public class BowlingGame
    {
        public BowlingGame()
        {
            Frames = new List<Frame>();
        }

        public List<Frame> Frames { get; internal set; }
        public int Score { get; internal set; }

        public void AddFrame(Frame frame)
        {
            Frames.Add(frame);
        }

        public int ScoreGame()
        {
            Score = 0;
            var frameNumber = 0;

            foreach (var frame in Frames)
            {
                var frameScore = ScoreFrame(frame);
                var bonusScore = CalculateBonusScore(frameNumber, frameScore);
                Score += frameScore.Score + bonusScore;
                frameNumber++;
            }

            return Score;
        }

        private int CalculateBonusScore(int frameNumber, FrameScore frameScore)
        {
            var bonusScore = 0;
            var bonusRollsRemaining = frameScore.BonusRolls;
            var bonusRollFrame = frameNumber + 1;
            while (bonusRollsRemaining > 0)
            {
                foreach (var roll in Frames[bonusRollFrame].Rolls)
                {
                    if (bonusRollsRemaining > 0)
                    {
                        bonusScore += roll.Pins;
                        bonusRollsRemaining--;
                    }
                }
                bonusRollFrame += 1;
            }
            return bonusScore;
        }

        private FrameScore ScoreFrame(Frame frame)
        {
            var frameScore = new FrameScore();

            foreach (var roll in frame.Rolls)
                frameScore.Score += roll.Pins;

            if (frameScore.Score == 10)
                if (frame.Rolls.Count == 1)
                    frameScore.BonusRolls = 2;
                else if (frame.Rolls.Count == 2)
                    frameScore.BonusRolls = 1;

            return frameScore;
        }
    }
}
