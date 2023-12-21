using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            string userInput;

            Console.WriteLine("Hello!\nInput the first number:");

            firstNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Input the first number:");

            secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("What do you want to do with those numbers?");
            Console.WriteLine("[A]dd\n[S]ubtract\n[M]ultiply");

            userInput = Console.ReadLine();

            if (userInput == "a" || userInput == "A")
            {
                Console.WriteLine(firstNumber + "  + " + secondNumber + " = " + (firstNumber + secondNumber));
            }
            else if (userInput == "s" || userInput == "S")
            {
                Console.WriteLine(firstNumber + "  - " + secondNumber + " = " + (firstNumber - secondNumber));
            }
            else if (userInput == "m" || userInput == "M")
            {
                Console.WriteLine(firstNumber + "  * " + secondNumber + " = " + (firstNumber * secondNumber));
            }
            else
            {
                Console.WriteLine("Invalid option");
            }

            Console.WriteLine("Press any key to close");

            Console.ReadKey();
        }
    }
}