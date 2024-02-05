namespace TransformInterface
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Transform(4));

            Console.ReadKey();
        }

        public static int Transform(
            int number)
        {
            var transformations = new List<INumericTransformation>
            {
                new By1Incrementer(),
                new By2Multiplier(),
                new ToPowerOf2Raiser()
            };

            var result = number;
            foreach (var transformation in transformations)
            {
                result = transformation.Transform(result);
            }
            return result;
        }
    }

    public interface INumericTransformation
    {
        int Transform(int result);
    }

    public class By1Incrementer : INumericTransformation
    {
        public int Transform(int result) => result + 1;
    }

    public class By2Multiplier : INumericTransformation
    {
        public int Transform(int result) => result * 2;
    }

    public class ToPowerOf2Raiser : INumericTransformation
    {
        public int Transform(int result) => (int)Math.Pow(result, 2);
    }
}