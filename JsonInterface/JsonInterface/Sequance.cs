using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Sequance:IPattern
    {
        IPattern[] patterns;


        public Sequance(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string textCopy = text;
            foreach (var pattern in patterns)
            {
               
                if (pattern.Match(text).Success())
                {

                    text = pattern.Match(text).RemainingText();
                }
                else return (IMatch)new FailedMatch(textCopy);

            }
            return (IMatch)new SuccessMatch(text);
        }  

    }
    
}
