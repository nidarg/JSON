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
    }
}
