namespace ExerciseExtendedMethods.Extentions
{
    public static class StringExtentions
    {
        public static int CountLines(this string input) => input.Split(Environment.NewLine).Length;
    }
}
