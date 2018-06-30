using CodePanzer.GameLogic.PanzerAction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Fine
{
    internal abstract class FineBase
    {
        FineBase _nextCalc;

        public FineBase(FineBase nextCalc)
        {
            _nextCalc = nextCalc;
        }

        public ushort CalcFine(ushort currentFine, FineContext fineContext)
        {
            currentFine += CalcFine(fineContext);
            return _nextCalc?.CalcFine(currentFine, fineContext) ?? currentFine;
        }

        protected abstract ushort CalcFine(FineContext fineContext);
    }
}
