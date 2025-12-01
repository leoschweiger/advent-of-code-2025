public static class Methods
{
    public static long GetPartOne(string[] lines)
    {
        long sum = 0;
        long currentNumber = 50;
        foreach (var line in lines)
        {
            long value = ParseRotation(line);
            currentNumber = (currentNumber + value) % 100;
            if (currentNumber == 0)
                sum += 1;
        }

        return sum;
    }

    public static long GetPartTwo(string[] lines)
    {
        long sum = 0;
        long currentNumber = 50;
        foreach (var line in lines)
        {
            long value = ParseRotation(line);
            for (int i = 0; i < Math.Abs(value); i++)
            {
                currentNumber = (currentNumber + (value < 0 ? -1 : 1)) % 100;
                if (currentNumber == 0)
                    sum += 1;
            }
        }

        return sum;
    }

    private static long ParseRotation(string line)
    {
        bool toLeft = line.StartsWith("L");
        long value = long.Parse(line[1..]);
        return toLeft ? -value : value;
    }
}
