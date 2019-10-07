using System;
using Xunit;
using validators;

namespace unittests
{
    public class ValidatorsUnitTests
    {
        
        [Theory]
        [InlineData("3623981230", true)]
        [InlineData("9531204591", true)]
        [InlineData("9542223907", true)]
        [InlineData("9542223901", false)]
        [InlineData("5252438106", true)]
        [InlineData("5851404935", true)]
        public void NIPValidatorTest(string number, bool expected)
        {
            IValidator validator = new NIPValidator();

            bool result = validator.IsValid(number);

             Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData("49040501580", true)]
        [InlineData("75012403718", true)]
        [InlineData("46040501580", false)]
        public void PeselValidatorTest(string number, bool expected)
        {
            IValidator validator = new PeselValidator();

            bool result = validator.IsValid(number);

             Assert.Equal(expected, result);

        }

        [Fact]
        public void InvalidNipTest()
        {
             IValidator validator = new PeselValidator();
             Assert.Throws<FormatException>(() => validator.IsValid("954222390"));
             Assert.Throws<FormatException>(() => validator.IsValid("9542223909999"));
             Assert.Throws<FormatException>(() => validator.IsValid("AAA954222390"));
        }


        [Fact]
        public void InvalidPeselTest()
        {
             IValidator validator = new PeselValidator();
             Assert.Throws<FormatException>(() => validator.IsValid("55555012403718"));
             Assert.Throws<FormatException>(() => validator.IsValid("5012403718"));
             Assert.Throws<FormatException>(() => validator.IsValid("AAA12403718"));
        }
    }
}
