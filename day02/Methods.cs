public static class Methods
{
    public static long GetPartOne(string[] lines)
    {
        long sum = 0;

        foreach (var id in lines[0].Split(','))
        {
            long first = long.Parse(id.Split('-')[0]);
            long second = long.Parse(id.Split('-')[1]);
            for (long i = first; i <= second; i++)
            {
                if (!IsValidIdPartOne(i))
                    sum += i;
            }
        }

        return sum;
    }

    public static long GetPartTwo(string[] lines)
    {
        long sum = 0;

        foreach (var id in lines[0].Split(','))
        {
            long first = long.Parse(id.Split('-')[0]);
            long second = long.Parse(id.Split('-')[1]);
            for (long i = first; i <= second; i++)
            {
                if (!IsValidIdPartTwo(i))
                    sum += i;
            }
        }

        return sum;
    }

    private static bool IsValidIdPartOne(long id)
    {
        string str = id.ToString();
        int len = str.Length;
        if (len % 2 == 1)
            return true;
        string firstHalf = str.Substring(0, len / 2);
        string secondHalf = str.Substring(len / 2);
        return firstHalf != secondHalf;
    }

    private static bool IsValidIdPartTwo(long id)
    {
        string str = id.ToString();
        var divs = GetDivisorsMe(str.Length);
        foreach (var div in divs)
        {
            if (div == 1)
                continue;
            if (IsTheSame(str, div))
                return false;
        }
        return true;
    }

    private static bool IsTheSame(string str, long div)
    {
        var parts = SplitString(str, div);
        foreach (var part in parts)
        {
            if (part != parts[0])
                return false;
        }
        return true;
    }

    private static long[] GetDivisorsMe(long n)
    {
        if (n <= 0)
            return Array.Empty<long>();

        List<long> divisors = new List<long>();
        for (long i = 1; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
                if (i != n / i)
                    divisors.Add(n / i);
            }
        }
        divisors.Sort();
        return divisors.ToArray();
    }

    private static string[] SplitString(string str, long parts)
    {
        var len = str.Length;
        if ((float)len / parts % 1 != 0)
            return Array.Empty<string>();

        var ret = new string[parts];
        for (int i = 0; i < parts; i++)
            ret[i] = str.Substring(i * (int)(len / parts), (int)(len / parts));

        return ret;
    }
}
