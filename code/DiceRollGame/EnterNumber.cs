namespace DiceRollGame
{
    public class EnterNumber
    {
        public int EnterNumberFromConsole()
        {
            DisplayMessage displayMessage = new DisplayMessage();

            bool isNumberValid = int.TryParse(Console.ReadLine(), out int number);

            if (isNumberValid)
            {
                return number;
            }

            displayMessage.IncorrectNumberMessage();
            
            return EnterNumberFromConsole();
        }
    }
}