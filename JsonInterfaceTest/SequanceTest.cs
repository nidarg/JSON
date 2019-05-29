using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace JsonInterfaceTest
{
    public class SequanceTest
    {

        [Theory]
        [InlineData("abcd", "d")]
        public void TestSequanceSuccess(string text,string remaining)
        {
            var ab = new Sequance(
                new Charact('a'),
                new Charact('b')
                );

            var abc = new Sequance(
                    ab,
                    new Charact('c')
                    );


            var match = abc.Match(text);
            Assert.True(match.Success());
            Assert.Equal(remaining, match.RemainingText());
        }

    }
}
