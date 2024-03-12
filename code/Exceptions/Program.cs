namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string input = "hello";
            //int number = int.Parse(input);

            //Console.WriteLine(number);

            //DivideNumbers(2, 0);

            RecursiveMethod();

            Console.ReadLine();
        }

        public static int DivideNumbers(int a, int b)
        {
            //your code goes here
            try
            {
                return a / b;
            }
            catch
            {
                //your code goes here
                Console.WriteLine("Division by zero."); 
                return 0;
            }
            finally
            {
                Console.WriteLine("The DivideNumbers method ends.");
            }
        }

        public static void RecursiveMethod()
        {
            Console.WriteLine("I'm going to call myself.");
            RecursiveMethod();
        }

        public static int GetMaxValue(List<int> numbers)
        {
            //if (numbers == null)
            //{
            //    throw new ArgumentNullException("The numbers list cannot be null.", ex);
            //}
            try
            {
                return numbers.Max();
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("The numbers list cannot be null.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("The numbers list cannot be empty.");
                throw ex;
                throw new Exception();
            }
        }
    }
}