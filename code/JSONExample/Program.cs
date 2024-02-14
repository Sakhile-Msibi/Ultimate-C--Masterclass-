using System.Text.Json;

namespace JSONExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                FirstName = "Sakhile",
                LastName = "Msibi",
                YearOfBirth = 1989
            };

            string asJon = JsonSerializer.Serialize(person);

            Console.WriteLine("As JSON: ");
            Console.WriteLine(asJon);

            string personJson = "{\"FirstName\":\"Sakhile\",\"LastName\":\"Msibi\",\"YearOfBirth\":1989}";
            Person ? personFromJson = JsonSerializer.Deserialize<Person>(personJson);

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public int YearOfBirth { get; set; }
    }
}