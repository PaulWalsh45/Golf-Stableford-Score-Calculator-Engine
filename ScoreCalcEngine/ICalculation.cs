using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoreCalcEngine
{
    public interface ICalculation
    {
        Task<Int32> GetRoundStableford(IList<Int32> indices, IList<Int32> pars, IList<Int32> scores, Int32 handicap);

        Task<Int32> GetHoleStableford(Int32 index, Int32 par, Int32 score, Int32 handicap);
    }
}