using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class AnyClassTest
    {
        [Theory]
        [InlineData("afb","fgh","gh")]
        [InlineData("eE","Ea", "a")]

        public void TestAnySuccess(string accepted, string text, string remainingText)
        {
            var e = new Any(accepted);
            var match = e.Match(text);
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }


        [Theory]
        [InlineData("-+", "2", "2")]
        [InlineData("abc", "Ea", "Ea")]
        [InlineData("abc", "", "")]
        [InlineData("abc", null, null)]
        public void TestAnyFail(string accepted,string text, string remainingText)
        {
            var e = new Any(accepted);
            var match = e.Match(text);
            Assert.False(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }
    }
}
