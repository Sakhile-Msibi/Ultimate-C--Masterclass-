namespace UnitTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 3, 4, 5, 7, 8 };

            int result = input.SumOfEvenNumbers();

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}