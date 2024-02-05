using static ExerciseExtendedMethods.Program;

namespace ExerciseExtendedMethods.Extentions
{
    public static class SeasonExtentions
    {
        public static Season Next(this Season season)
        {
            int seasonAsInt = (int)season;
            int nextSeason = (seasonAsInt + 1) % 4;
            return (Season)nextSeason;
        }
    }
}
