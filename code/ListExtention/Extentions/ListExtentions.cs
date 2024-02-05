namespace ListExtention.Extentions
{
    public static class ListExtentions
    {
        public static List<int> TakeEverySecond(this List<int> list)
        {
            if (list.Count == 0)
            {
                return new List<int>();
            }

            List<int> result = new List<int>();

            result.Add(list[0]);

            for (int i = 1; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }
    }
}
