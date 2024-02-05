namespace Exercise
{
     class Program
    {
        static void Main(string[] args)
        {
            //var pizza = new Pizza();
            //pizza.AddIngredient(new Cheddar());
            //pizza.AddIngredient(new Mozzarella());
            //pizza.AddIngredient(new TomatoSauce());
            //Ingredient ingredient = new Ingredient();

            //Console.WriteLine(pizza.Describe());
            //Console.WriteLine("Variable of type Cheddar");
            //Cheddar cheddar = new Cheddar();
            //Console.WriteLine(cheddar.Name);
            //var numericTypesDescriber = new NumericTypesDescriber();
            //var oneObject = new OneObject();
            //double test = 9;

            //Console.WriteLine(numericTypesDescriber.Describe(test));

            //Console.WriteLine("Variable of type Ingredient");
            //Ingredient ingredient = new Cheddar();
            //Console.WriteLine(ingredient.Name);

            //var animal = new Animal();// { NumberOfLegs = 4 };
            //var tiger = new Tiger();// { NumberOfLegs = 8 };

            //Console.WriteLine(tiger.NumberOfLegs);

            var ingredients = new List<Ingredient>
            {
                new Cheddar(),
                new Mozzarella(),
                new TomatoSauce()
            };

            //foreach (var ingredient in ingredients)
            //{
            //    Console.WriteLine(ingredient.Name);
            //}


            List<string> list = new List<string>
            {
                "bobcat",
                "wolverine",
                "grizzly"
            };
            DisplayList(ProcessAll(list));

            Console.ReadKey();
        }

        //public static List<int> GetCountsOfAnimalsLegs()
        //{
        //    var animals = new List<Animal>
        //    {
        //        new Lion(),
        //        new Tiger(),
        //        new Duck(),
        //        new Spider()
        //    };

        //    var result = new List<int>();
        //    foreach (var animal in animals)
        //    {
        //        result.Add(animal.NumberOfLegs);
        //    }
        //    return result;
        //}

        public static List<string> ProcessAll(List<string> words)
        {
            var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };

            string str = string.Join(" ", words.ToArray());

            List<string> result = words;
            foreach (var stringsProcessor in stringsProcessors)
            {
                result = stringsProcessor.Process(result);
            }
            return result;
        }

        public static void DisplayList(List<string> ints)
        {
            foreach (var animal in ints)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine();
        }

    }

    public class OneObject
    {
        public int integer = 7;
    }

    public class NumericTypesDescriber
    {
        public string Describe(object someObject)
        {
            //your code goes here
            if (someObject is int)
            {
                return Wording("Int", someObject);
            }
            else if (someObject is double)
            {
                return Wording("Double", someObject);
            }
            else if (someObject is decimal)
            {
                return Wording("Decimal", someObject);
            }
            else
            {
                return null;
            }
        }

        private static  string Wording(string objectType, object someObject) => $"{objectType} of value {someObject}";
    }

    public class StringsProcessor
    {
        public virtual List<string> Process(List<string> strings)
        {
            List<string> proccessedStrings = new List<string>();

            for (int i = 0; i < strings.Count; i++)
            {
                proccessedStrings.Add(proccessedString(strings[i]));
            }

            return proccessedStrings;
        }

        public virtual string proccessedString(string unproccessedString)
        {
            return "";
        }

    }

    public class StringsUppercaseProcessor : StringsProcessor
    {
        public override string proccessedString(string unproccessedString) => unproccessedString.ToUpper();
    }

    public class StringsTrimmingProcessor : StringsProcessor
    {
        public override string proccessedString(string unproccessedString)
        {
            int halfStringLen = unproccessedString.Length / 2;

            return unproccessedString.Substring(0, halfStringLen);
        }
    }

    public class Animal
    {
        public virtual int NumberOfLegs { get;  } = 4;
    }

    public class Lion : Animal
    {
        //public override int NumberOfLegs { get; set; } = 4;
    }

    public class Tiger : Animal
    {
        //public  int NumberOfLegs { get; set; }
    }

    public class Duck : Animal
    {
        public override int NumberOfLegs { get;  } = 2;
    }

    public class Spider : Animal
    {
        public override int NumberOfLegs { get; } = 8;
    }

    //public class Animal
    //{
    //    public virtual int NumberOfLegs { get; set; } = 4;
    //}

    //public class Tiger : Animal
    //{
    //    public override int NumberOfLegs { get; set; } = 2;
    //}

    public abstract class Ingredient
    {
        public override string ToString() => Name;

        public virtual string Name { get; } = "Some ingredient";

        public string PublicMethod() => "This method is PUBLIC in the ingredient class.";
    }

    public class Cheddar : Ingredient 
    {
        public override string Name => "Cheddar cheese";
    }

    public class TomatoSauce : Ingredient
    {
        public override string Name => "Tomato sauce";
    }

    public class Mozzarella : Ingredient
    {
        public override string Name => "Mozarella";
    }

    public class Pizza
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();

        public void AddIngredient(Ingredient ingredient) => _ingredients.Add(ingredient);

        public string Describe() => $"This is a pizza with {string.Join(", ", _ingredients)}";
    }
}