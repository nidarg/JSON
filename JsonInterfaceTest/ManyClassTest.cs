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
           
            var matchChar = manyChar.Match(text);
           
            Assert.True(matchChar.Success());
            Assert.Equal(remainingText, matchChar.RemainingText());

        }

        [Theory]
        [InlineData("12345ab123", "ab123")]
        [InlineData("bcd", "bcd")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("bcdef", "bcdef")]


        public void TestManyRangeSuccess(string text, string remainingText)
        {
            
             var manyRange = new Many(new Ranges('0', '9'));
           
            var matchRange = manyRange.Match(text);
            Assert.True(matchRange.Success());
            Assert.Equal(remainingText, matchRange.RemainingText());

        }
    }
}
