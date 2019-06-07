using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class MyList:IPattern
    {
        readonly IPattern element;
        readonly IPattern separator;

        public MyList(IPattern element, IPattern separator)
        {
            this.element = element;
            this.separator = separator;
        }

        public IMatch Match(string text)
        {
            string textCopy = text;
            var elem = element.Match(text);
            var sep = separator.Match(elem.RemainingText());
          
            while (elem.Success())
            {
                if (!sep.Success()) return new SuccessMatch(elem.RemainingText());
                var previous = elem;
                elem = element.Match(sep.RemainingText());
                if (!elem.Success()) return new SuccessMatch(previous.RemainingText());
                sep = separator.Match(elem.RemainingText());
                

            //  return new SuccessMatch(sep.RemainingText());
            }
            return new SuccessMatch(textCopy);
        }
    }
}
