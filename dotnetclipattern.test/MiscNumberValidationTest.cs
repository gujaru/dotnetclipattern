using dotnetclipattern.Domain;

namespace dotnetclipattern.test
{
    public class MiscNumberValidationTest
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(11)]
        public void WhenNumberIsPrimeThenTrue(int value)
        {
            var primeService = new MiscNumberValidation();
            bool result = primeService.IsPrime(value);
            Assert.True(result, $"{value} should be prime");
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void WhenNumberIsNotPrimeThenFalse(int value)
        {
            var primeService = new MiscNumberValidation();
            bool result = primeService.IsPrime(value);
            Assert.False(result, $"{value} should not be prime");
        }

        [Fact]
        public void WhenNumberIsEvenThenTrue()
        {
            var primeService = new MiscNumberValidation();
            bool result = primeService.IsEvenNumber(2);
            Assert.True(result, "2 should be even");
        }
        [Fact]
        public void WhenNumberIsEvenThenFalse()
        {
            var primeService = new MiscNumberValidation();
            bool result = primeService.IsEvenNumber(1);
            Assert.False(result, "1 should not be even");
        }

        [Fact]
        public void WhenNumberIsPalindromeThenTrue()
        {
            var primeService = new MiscNumberValidation();
            bool result = primeService.IsPalandrome(1111);
            Assert.True(result, "1111 is a palindrome");
        }

        [Fact]
        public void WhenNumberIsPalindromeThenFalse()
        {
            var primeService = new MiscNumberValidation();
            bool result = primeService.IsPalandrome(1112);
            Assert.False(result, "1112 is a palindrome");
        }
    }
}