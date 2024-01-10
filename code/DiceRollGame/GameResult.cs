namespace DiceRollGame
{
    public class GameResult
    {
        public bool GameResults(int roll, int enteredNumber)
        {
            DisplayMessage displayMessage = new DisplayMessage();

            if (roll == enteredNumber)
            {
                displayMessage.WinMessage();
                return true;
            }
            else
            {
                displayMessage.WrongNumberMessage();
                return false;
            }
        }
    }
}