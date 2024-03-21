using NUnit.Framework;
using UnitTests;

namespace UnitTestsTests
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void SumOfEvenNumbers_ForEmptyCollection_ShallReturnZero()
        {
            var input = Enumerable.Empty<int>();

            var result = input.SumOfEvenNumbers();

            Assert.AreEqual(0, result);
        }

        [Test]
        public void SumOfEvenNumbers_IfEvenNumbersArePresent_ShallReturnNonZeroResult()
        {
            //arrange
            var input = new int[] { 3, 1, 4, 6, 7 };

            //act
            var result = input.SumOfEvenNumbers();

            //assert
            int expected = 10;
            string inputString = string.Join(",", input);

            Assert.AreEqual(10, result, $"For input {inputString} the result shall be {expected}" +
                $" but it was {result}.");
        }

        [TestCase(6)]
        [TestCase(-8)]
        [TestCase(6)]
        [TestCase(0)]
        public void SumOfEvenNumbers_IfItIsEven_ShallReturnValueOfTheOnlyItem(int number)
        {
            //arrange
            var input = new int[] { number };

            //act
            var result = input.SumOfEvenNumbers();

            //assert
            Assert.AreEqual(number, result);
        }

        [Test]
        public void SumOfEvenNumbers_ForNullInput_ShallThrowException()
        {
            IEnumerable<int>? input = null;

            Assert.Throws<ArgumentNullException>(()  => input!.SumOfEvenNumbers());
        }

    }
}