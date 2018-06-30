using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map
{
    public class CastEnumerator<T> : IEnumerator<T>
    {
        public IEnumerator _mainEnumerator;
        public CastEnumerator(IEnumerator mainEnumerator)
        {
            _mainEnumerator = mainEnumerator;
        }

        public T Current => (T)_mainEnumerator.Current;

        object IEnumerator.Current => _mainEnumerator.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            return _mainEnumerator.MoveNext();
        }

        public void Reset()
        {
            _mainEnumerator.Reset();
        }
    }
}
