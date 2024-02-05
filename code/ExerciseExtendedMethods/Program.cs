using ExerciseExtendedMethods.Extentions;

namespace ExerciseExtendedMethods
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            var multilineText = @"aaa
            bbb
            ccc
            ddd";

            Console.WriteLine("Count of lines is " + multilineText.CountLines());
            Console.WriteLine("Count of lines is " +  StringExtentions.CountLines(multilineText));

            Console.WriteLine("Next after string is " + Season.Spring.Next());
            Console.WriteLine("Next after string is " + Season.Winter.Next());

            Console.ReadKey();
        }

        static int CountLines(string input) => input.Split(Environment.NewLine).Length;
    }
}