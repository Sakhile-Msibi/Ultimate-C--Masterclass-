namespace ExerciseAbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>()
            {
                new Square(2.10),
                new Rectangle(2.00, 2.00),
                new Circle(2.00)
            };

            DisplayList(GetShapesAreas(shapes));

            Console.ReadKey();
        }

        public static List<double> GetShapesAreas(List<Shape> shapes)
        {
            var result = new List<double>();

            foreach (var shape in shapes)
            {
                result.Add(shape.CalculateArea());
            }

            return result;
        }

        static void DisplayList(IList<double> list)
        {
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
    }

    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    public class Square : Shape
    {
        public double Side { get; }

        public Square(double side)
        {
            Side = side;
        }

        //your code goes here
        public override double CalculateArea() => Side * Side;
    }

    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        //your code goes here
        public override double CalculateArea() => Width * Height;
    }

    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        //your code goes here
        public override double CalculateArea() => Math.PI * Math.Pow(Radius, 2);
    }
}