namespace FibonacciGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Fibonacci.DisplayList(Fibonacci.Generate(39));

            Console.ReadKey();
        }
    }
}