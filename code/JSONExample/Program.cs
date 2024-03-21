using System.Text.Json;

namespace JSONExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person
            //{
            //    FirstName = "Sakhile",
            //    LastName = "Msibi",
            //    YearOfBirth = 1989
            //};

            //string asJon = JsonSerializer.Serialize(person);

            //Console.WriteLine("As JSON: ");
            //Console.WriteLine(asJon);

            //string personJson = "{\"FirstName\":\"Sakhile\",\"LastName\":\"Msibi\",\"YearOfBirth\":1989}";
            //Person ? personFromJson = JsonSerializer.Deserialize<Person>(personJson);

            //Person person = new Programmer();
            //Console.WriteLine(person.Greet());

            Console.ReadKey();
        }
    }

    public abstract class Person
    {
        public abstract string Greet();// => "Hello!";

        public Address Address { get; init; }

        //public Person(string name)
        //{
        //   // _name = name;
        //}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearOfBirth { get; set; }
    }

    public static class Programmer //: Person
    {
        public static string Greet() => "Hello! What is your favorite language?";
    }

    public class Address
    {
        public string Street { get; init; }
    }
}