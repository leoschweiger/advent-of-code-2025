public static class Methods
{
    public static long GetPartOne(string[] lines)
    {
        return GetMovableCount(lines);
    }

    public static long GetPartTwo(string[] lines)
    {
        long sum = 0;
        while (CheckBoard(lines, out long count, out lines))
        {
            sum += count;
        }
        return sum;
    }

    private static bool CheckRoll(string[] lines, long x, long y)
    {
        long adjacentRolls = 0;
        for (long y_ = -1; y_ <= 1; y_++)
        {
            for (long x_ = -1; x_ <= 1; x_++)
            {
                if (y_ == 0 && x_ == 0)
                    continue;
                long new_x = x + x_;
                long new_y = y + y_;
                if (GetChar(lines, new_x, new_y, out char c) && c == '@')
                    adjacentRolls++;
            }
        }
        return adjacentRolls < 4;
    }

    private static bool GetChar(string[] lines, long x, long y, out char c)
    {
        c = ' ';
        if (x < 0 || y < 0)
            return false;
        if (x >= lines[0].Length || y >= lines.Length)
            return false;
        c = lines[y][(int)x];
        return true;
    }

    private static long GetMovableCount(string[] lines)
    {
        CheckBoard(lines, out long count, out _);
        return count;
    }

    private static bool CheckBoard(string[] lines, out long count, out string[] lines_new)
    {
        lines_new = new string[lines.Length];

        long sum = 0;
        for (long y = 0; y < lines.Length; y++)
        {
            string line = "";
            for (long x = 0; x < lines[y].Length; x++)
            {
                char c = lines[(int)y][(int)x];
                if (c == '@')
                {
                    if (CheckRoll(lines, x, y))
                    {
                        sum++;
                        c = '.';
                    }
                }
                line += c;
            }
            lines_new[y] = line;
        }
        count = sum;
        return sum > 0;
    }
}
