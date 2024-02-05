namespace DiceRollGame
{
    public class GameLoss
    {
        public void output(int numberOfGuesses, int maxGuesses)
        {
            DisplayMessage displayMessage = new DisplayMessage();

            if (numberOfGuesses == maxGuesses)
            {
                displayMessage.LossMessage();
            }
        }
    } 
}