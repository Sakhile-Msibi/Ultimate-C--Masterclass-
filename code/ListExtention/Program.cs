using ListExtention.Extentions;

namespace ListExtention
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 5, 10, 8, 12, 4, 5 };

            List<int> list1 = new List<int>() { 1, 5, 10, 8, 12, 4, 5, 6 };

            List<int> list2 = new List<int>() { 1 };

            List<int> list3 = new List<int>() { };

            List<int> list4 = null;

            DisplayList(list4.TakeEverySecond());

            Console.ReadKey();
        }

        static void DisplayList(IList<int> list)
        {
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
        }
    }
}