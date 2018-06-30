using CodePanzer.GameLogic.PanzerAction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Fine
{
    internal class FineForSlowAlgorithm : FineBase
    {
        /// <summary>
        /// Кол-во милисекунд за которое должен отработать алгоритм. Иначе штраф.
        /// </summary>
        private const int MILLISECONDS_ON_TROUND = 1000;

        public FineForSlowAlgorithm(FineBase nextCalc) : base(nextCalc)
        {
        }

        protected override ushort CalcFine(FineContext fineContext)
        {
            if (fineContext.Intent.AVGMillesecondsOnStep < MILLISECONDS_ON_TROUND)
                return 0;

            return (ushort)Math.Ceiling(fineContext.Intent.AVGMillesecondsOnStep / MILLISECONDS_ON_TROUND);
        }
    }
}
