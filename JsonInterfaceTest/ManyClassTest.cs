using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class ManyClassTest
    {
        [Theory]
        [InlineData("abc", "bc")]
        [InlineData("aaaabcd", "bcd")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("bcdef", "bcdef")]


        public void TestManyCharSuccess(string text, string remainingText)
        {
            var manyChar = new Many(new Charact('a'));
           // var manyRange = new Many(new Ranges('0', '9'));
            var matchChar = manyChar.Match(text);
            //var matchRange = manyRange.Match(text);
            Assert.True(matchChar.Success());
            Assert.Equal(remainingText, matchChar.RemainingText());

        }
    }
}
