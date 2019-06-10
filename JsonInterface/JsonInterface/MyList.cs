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
        
            var elem = new OneOrMore(element);
            var sep = new OneOrMore(separator);

            var matchElem = elem.Match(text);
            var matchSep = sep.Match(matchElem.RemainingText());
            while (matchElem.Success())
            {

                var previous = matchElem;
                text = matchSep.RemainingText();
                matchElem = elem.Match(text);
                matchSep = sep.Match(matchElem.RemainingText());
                if (!matchElem.Success()) return new SuccessMatch(previous.RemainingText());
               
            }
            return new SuccessMatch(matchElem.RemainingText());







            //string textCopy = text;
            //var elem = element.Match(text);
            //var sep = separator.Match(elem.RemainingText());

            //while (elem.Success())
            //{
            //    if (!sep.Success()) return new SuccessMatch(elem.RemainingText());
            //    var previous = elem;
            //    elem = element.Match(sep.RemainingText());
            //    if (!elem.Success()) return new SuccessMatch(previous.RemainingText());
            //    sep = separator.Match(elem.RemainingText());


            ////  return new SuccessMatch(sep.RemainingText());
            //}
            //return new SuccessMatch(textCopy);
        }
    }
}
