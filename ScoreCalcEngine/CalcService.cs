using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoreCalcEngine
{
    public class CalcService : ICalculation
    {
        public Task<Int32> GetHoleStableford(Int32 index, Int32 par, Int32 score, Int32 handicap)
        {
            Int32 twoShotIndexCap = 0;
            Int32 holeScore = 0;
            Int32 holeShot = 0;
            Int32 holeNett = 0;

            if (handicap > 18)
            {
                twoShotIndexCap = this.GetTwoShotIndexCap(handicap);
            }
            holeShot = GetHoleShot(handicap, twoShotIndexCap, index);
            holeNett = score - holeShot;
            if (score == 0)
            {
                holeScore = 0;
            }
            else
            {
                holeScore = this.GetHoleScore(holeNett, par);
            }

            return Task.FromResult(holeScore);
        }

        public Task<Int32> GetRoundStableford(IList<Int32> indices, IList<Int32> pars, IList<Int32> scores, Int32 handicap)
        {
            Int32 twoShotIndexCap = 0;
            Int32 total = 0;
            Int32 holeScore = 0;
            Int32 holeNett = 0;

            if (handicap > 18)
            {
                twoShotIndexCap = this.GetTwoShotIndexCap(handicap);
            }
            for (int i = 0; i < scores.Count; i++)
            {
                Int32 holeShot = 0;
                Int32 index = indices[i];
                Int32 par = pars[i];
                holeShot = GetHoleShot(handicap, twoShotIndexCap, index);
                holeNett = scores[i] - holeShot;
                if (scores[i] == 0)
                {
                    holeScore = 0;
                }
                else
                {
                    holeScore = GetHoleScore(holeNett, pars[i]);
                }

                total += holeScore;
            }

            return Task.FromResult(total);
        }

        private static Int32 GetHoleShot(Int32 handicap, Int32 twoShotIndexCap, Int32 index)
        {
            Int32 holeShot = 0;

            if (handicap >= index && twoShotIndexCap == 0)
            {
                holeShot = 1;
            }
            else if (handicap >= index)
            {
                if (twoShotIndexCap >= index)
                {
                    holeShot = 2;
                }
                else
                {
                    holeShot = 1;
                }
            }

            return holeShot;
        }

        private Int32 GetHoleScore(Int32 holeNett, Int32 par)
        {
            Int32 value = par - holeNett;
            Int32 score = 0;
            switch (value)
            {
                case -1:
                    score = 1;
                    break;

                case 0:
                    score = 2;
                    break;

                case 1:
                    score = 3;
                    break;

                case 2:
                    score = 4;
                    break;

                case 3:
                    score = 5;
                    break;
            }

            return score;
        }

        private Int32 GetTwoShotIndexCap(int handicap)
        {
            return handicap - 18;
        }
    }
}