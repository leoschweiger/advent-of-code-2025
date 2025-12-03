public static class Methods
{
    public static long GetPartOne(string[] lines)
    {
        long sum = 0;

        foreach (var line in lines)
            sum += SolveLine(line, 2);

        return sum;
    }

    public static long GetPartTwo(string[] lines)
    {
        long sum = 0;

        foreach (var line in lines)
            sum += SolveLine(line, 12);

        return sum;
    }

    private static long SolveLine(string line, int max_digits)
    {
        List<int> ints = ParseLine(line);
        string num = "";
        int counter = max_digits - 1;
        int max = ints.GetRange(0, ints.Count - counter).Max();
        for (int i = 0; i < ints.Count; i++)
        {
            if (ints[i] == max)
            {
                num += ints[i];
                if (num.Length >= max_digits)
                    return long.Parse(num);
                counter--;
                max = ints.GetRange(i + 1, ints.Count - i - 1 - counter).Max();
            }
        }
        throw new Exception("something went wrong");
    }

    private static List<int> ParseLine(string line)
    {
        List<int> ret = new();
        foreach (char c in line)
            ret.Add(int.Parse(c.ToString()));

        return ret;
    }
}
