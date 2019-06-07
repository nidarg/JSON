using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class ListTest
    {


        [Theory]
        [InlineData(",f")]
        //[InlineData( ",")]
        //[InlineData( "a")]
        //
        //[InlineData( "")]


        public void TestListSuccess(string remainingText)
        {
            var a = new MyList(new Ranges('0', '9'), new Charact(','));
            var match1 = a.Match("1,2,3,f");
            //var match2 = a.Match("1,2,3,");
            //var match3 =  a.Match("1a");
            //var match4 =  a.Match(null);
            //var match5 =  a.Match("");
            Assert.True(match1.Success());
            Assert.Equal(remainingText, match1.RemainingText());
            //Assert.True(match2.Success());
            //Assert.Equal(remainingText, match2.RemainingText());
            //Assert.True(match3.Success());
            //Assert.Equal(remainingText, match3.RemainingText());
            //Assert.True(match4.Success());
            //Assert.Equal(remainingText, match4.RemainingText());
            //Assert.True(match5.Success());
            //Assert.Equal(remainingText, match5.RemainingText());


           

        }

        [Theory]
        [InlineData(",")]
        public void TestListSuccessRemainingSeparator(string remainingText)
        {
            var a = new MyList(new Ranges('0', '9'), new Charact(','));
            var match = a.Match("1,2,3,");
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());
           
        }

        [Theory]
        [InlineData(null)]
        public void TestListSuccessNullString(string remainingText)
        {
            var a = new MyList(new Ranges('0', '9'), new Charact(','));
            var match = a.Match(null);
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }
        [Theory]
        [InlineData("")]
        public void TestListSuccessEmptyString(string remainingText)
        {
            var a = new MyList(new Ranges('0', '9'), new Charact(','));
            var match = a.Match("");
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }

        [Theory]
        [InlineData("")]
        public void TestListJsonString(string remainingText)
        {
            var digits = new OneOrMore(new Ranges('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequance(whitespace, new Charact(';'), whitespace);
            var list = new MyList(digits, separator);
            var match = list.Match("1; 22  ;\n 333 \t; 22");
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }

    }
}
