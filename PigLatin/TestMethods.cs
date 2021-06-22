using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PigLatin
{
    public class TestMethods
    {
        [Theory]
        [InlineData('a', true)]
        [InlineData('b', false)]
        // [InlineData('E', true)]
        public void TestIsVowel(char c, bool vowelOrNot)
        {
            bool expected = vowelOrNot;
            bool actual = Program.IsVowel(c);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("apple", "appleway")]
        [InlineData("heck", "eckhay")]
        [InlineData("strong", "ongstray")]
        [InlineData("tommy@email.com", "tommy@email.com")]
        [InlineData("aardvark", "aardvarkway")]
        [InlineData("Tommy", "ommytay")]
        [InlineData("gym", "gym")]
        [InlineData("apple joy gym tommy@email.com strong", "appleway oyjay gym tommy@email.com ongstray")]
        public void TestToPigLatin(string input, string expected)
        {
            string actual = Program.ToPigLatin(input);
            Assert.Equal(expected, actual);
        }
    }
}


// sample text