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
        public void TestSequanceOfCharSuccess(string text,string remaining)
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

        [Theory]
        [InlineData("u1234", "")]
        [InlineData("uabcdef", "ef")]
        [InlineData("uB005 ab", " ab")]
        public void TestSequanceOfHexSuccess(string text, string remaining)
        {
            var hex = new Choices(
                new Ranges('0', '9'),
                new Ranges('a', 'f'),
                new Ranges('A', 'F')
            );

            var hexSeq = new Sequance(
                new Charact('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex
                )
             );


            var match = hexSeq.Match(text);
            Assert.True(match.Success());
            Assert.Equal(remaining, match.RemainingText());
        }

    }
}
