namespace DiceRollGame
{
    public class Program
    {
        public static void Main()
        {
            RollDice _dice = new RollDice();
            EnterNumber _enterNumber = new EnterNumber();
            GameResult _gameResult = new GameResult();
            GameLoss _gameLoss = new GameLoss();
            DisplayMessage displayMessage = new DisplayMessage();

            const int MAXGUESSES = 3;
            int numberOfGuesses = 0;
            int rolledNumber = _dice.Roll();

            displayMessage.StartMessage();

            do
            {
                int number = _enterNumber.EnterNumberFromConsole();

                if (!_gameResult.GameResults(rolledNumber, number))
                {
                    numberOfGuesses++;
                }
                else
                {
                    break;
                }

                _gameLoss.output(numberOfGuesses, MAXGUESSES);

            } while (numberOfGuesses != MAXGUESSES);

            Console.ReadKey();
        }
    }
}