namespace TodoList
{
    internal class Program
    {
        List<string> ToDoList = new List<string>();

        static void Main(string[] args)
        {
            Program program = new Program();

            string? userInput = "";
            bool isUserIputInvalid = false;

            Console.WriteLine("Hello!\n");

            do
            {
                isUserIputInvalid = true;

                Console.WriteLine("What do you want to do?");
                Console.WriteLine("[S]ee all TODOs");
                Console.WriteLine("[A]dd a TODO");
                Console.WriteLine("[R]emove a TODO");
                Console.WriteLine("[E]xit");

                userInput = Console.ReadLine();

                if (userInput != null)
                {
                    userInput = userInput.ToUpper();
                }

                switch (userInput)
                {
                    case "S":
                        program.DisplayToDoList();
                        break;
                    case "A":
                        isUserIputInvalid = program.AddToDo();
                        break;
                    case "R":
                        isUserIputInvalid = program.RemoveATODO();
                        break;
                    case "E":
                        isUserIputInvalid = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice\n");
                        break;
                }
            } while (isUserIputInvalid);
        }

        bool RemoveATODO()
        {
            bool isIndexValid = false;

            if (ToDoList.Count == 0) 
            {
                Console.WriteLine("No TODOs have been added yet\n");
                return true;
            }

            do
            {
                Console.WriteLine("Select the index of the TODO you want to remove:");
                DisplayToDoList();

                string? indexToRemove = Console.ReadLine();

                if (indexToRemove != null)
                {
                    if (indexToRemove.Length == 0)
                    {
                        Console.WriteLine("Selected index cannot be empty.");
                        isIndexValid = false;
                    }
                    else if (int.TryParse(indexToRemove, out int toDoIndex) && (toDoIndex > 0 && toDoIndex <= ToDoList.Count))
                    {
                        string removedTODO = ToDoList[toDoIndex - 1];
                        ToDoList.Remove(ToDoList[toDoIndex - 1]);
                        Console.WriteLine("TODO removed: " + removedTODO);
                        Console.WriteLine();
                        isIndexValid = true;
                    }
                    else
                    {
                        Console.WriteLine("The given index is not valid.");
                        isIndexValid = false;
                    }
                }
               
            } while (!isIndexValid);

            return isIndexValid;
        }

        void DisplayToDoList()
        {
            if (ToDoList.Count > 0)
            {
                for (int i = 0; i < ToDoList.Count; i++)
                {
                    Console.WriteLine($"{(i + 1)}. {ToDoList[i]}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No TODOs have been added yet\n");
            }
        }

        bool AddToDo()
        {
            bool isToDoValid = false;

            do
            {
                isToDoValid = true;
                Console.WriteLine("Enter the TODO description:");
                string? tODOdescription = Console.ReadLine();

                if (tODOdescription != null)
                {
                    if (tODOdescription.Length > 0)
                    {
                        foreach (string value in ToDoList)
                        {
                            if (value.Equals(tODOdescription))
                            {
                                isToDoValid = false;
                                break;
                            }
                        }

                        if (isToDoValid)
                        {
                            ToDoList.Add(tODOdescription);

                            Console.WriteLine("TODO successfully added: " + ToDoList[^1]);
                            Console.WriteLine();
                            isToDoValid = true;
                        }
                        else
                        {
                            Console.WriteLine("The description must be unique.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("The description cannot be empty.");
                        isToDoValid = false;
                    }
                }

            } while (!isToDoValid);

            return isToDoValid;
        }
    }
}