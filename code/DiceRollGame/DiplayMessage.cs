namespace DiceRollGame
{
    public class DisplayMessage
    {
        public void StartMessage()
        {
            Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");
            EnterNumberMessage();
        }

        public void WrongNumberMessage()
        {
            Console.WriteLine("Wrong number");
            EnterNumberMessage();
        }

        public void IncorrectNumberMessage()
        {
            Console.WriteLine("Incorrect input");
            EnterNumberMessage();
        }

        public void EnterNumberMessage()
        {
            Console.WriteLine("Enter a number:");
        }

        public void LossMessage()
        {
            Console.WriteLine("You lose :(");
        }

        public void WinMessage()
        {
            Console.WriteLine("You win! :)");
        }
    }
}