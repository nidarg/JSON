using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class RangeTest
    {
        [Theory]
        [InlineData( "fgh", "gh")]
        public void TestMatchRange(string text, string remaining)
        {
            var range = new Ranges('b', 'g');
            var match = range.Match(text);
            Assert.True(match.Success());
            Assert.Equal(match.RemainingText(), remaining);
        }

        [Theory]
        [InlineData("fgh", "fgh")]
        public void TestMatchRangeFail(string text, string remaining)
        {
            var range = new Ranges('g', 'k');
            var match = range.Match(text);
            Assert.False(match.Success());
            Assert.Equal(match.RemainingText(), remaining);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void TestemptyOrNullString(string text, string remaining)
        {
            var range = new Ranges('g', 'k');
            var match = range.Match(text);
            Assert.False(match.Success());
            Assert.Equal(match.RemainingText(), remaining);
        }

    }
}
