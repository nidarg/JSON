using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class CharacterTest
    {
        [Theory]
        [InlineData("fgh", "gh")]
        public void TestMatchCharacter( string text,string remainingText)
        {
            var  character = new Charact('f');
            var match = character.Match(text);
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }
        [Theory]
        [InlineData("fgh", "fgh")]
        public void TestNotMatchCharacter(string text, string remainingText)
        {
            var character = new Charact('a');
            var match = character.Match(text);
            Assert.False(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }


    }
}
