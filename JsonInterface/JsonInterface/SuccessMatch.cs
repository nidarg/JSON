using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    class SuccessMatch : IMatch
    {
        readonly string text;

        public SuccessMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Success()
        {
            return true;
        }
    }
}
