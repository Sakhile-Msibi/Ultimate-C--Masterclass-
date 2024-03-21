using FibonacciGenerator;
using NUnit.Framework;

namespace FibonacciGeneratorTest
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(-12)]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-41)]
        public void Generate_ForNumbersLessThanZero_ShallThrowException(int number)
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.Generate(number));
        }

        [TestCase(212)]
        [TestCase(58)]
        [TestCase(100)]
        [TestCase(47)]
        public void Generate_ForNumbersGreaterThanFortySix_ShallThrowException(int number)
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.Generate(number));
        }

        [Test]
        public void Generate_ForZero_ShallReurnEmpty()
        {
            int number = 0;

            //IEnumerable<int> expected = new int[] { };

            IEnumerable<int> numbers = Fibonacci.Generate(number);

            Assert.IsEmpty(numbers);
        }

        [Test]
        public void Generate_ForFortySix_ShallReurnANumber()
        {
            int number = 46;

            IEnumerable<int> expected = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987,
                1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465,
                14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170 };

            IEnumerable<int> numbers = Fibonacci.Generate(number);

            Assert.AreEqual(expected, numbers);
        }

        [TestCaseSource(nameof(GenerateTestCases))]
        public void Generate_ForNumbersBetweenOneAndFortyFive_ShallRetrunNumbers(int number, IEnumerable<int> expected)
        {
            IEnumerable<int> numbers = Fibonacci.Generate(number);

            Assert.AreEqual(expected, numbers);
        }

        public static IEnumerable<object> GenerateTestCases()
        {
            return new[]
            {
                new object[] { 1, new List<int> { 0 } },

                new object[] { 2, new List<int> { 0, 1 } },

                new object[] { 10, new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 } },

                new object[] { 22, new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946 } },

                new object[] { 39, new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 
                    10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169 } }
            };
        }
    }
}