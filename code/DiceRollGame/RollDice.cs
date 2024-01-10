namespace DiceRollGame
{
    public class RollDice
    {
        public int Roll() => new Random().Next(1, 7);
    }
}