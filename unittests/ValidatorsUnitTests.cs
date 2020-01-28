using System;
using Xunit;
using validators;

namespace unittests
{

    public class PeselValidatorTests
    {
        private readonly IValidator validator;

        public PeselValidatorTests()
        {
            validator = new PeselValidator();
        }

        [Theory]
        [InlineData("49040501580", true)]
        [InlineData("75012403718", true)]
        [InlineData("46040501580", false)]
        public void IsValid_ValidFormat_ReturnsStatus(string number, bool expected)
        {
            bool result = validator.IsValid(number);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void IsValid_InvalidFormat_ThrowsFormatException()
        {
             Assert.Throws<FormatException>(() => validator.IsValid("55555012403718"));
             Assert.Throws<FormatException>(() => validator.IsValid("5012403718"));
             Assert.Throws<FormatException>(() => validator.IsValid("AAA12403718"));
        }
    }
}
