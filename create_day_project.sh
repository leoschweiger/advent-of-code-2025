#!/bin/bash


# ./create_day_project.sh 1

if [ -z "$1" ]; then
  echo "Usage: $0 <day_number>"
  exit 1
fi

DAY=$(printf "day%02d" $1)

mkdir -p "$DAY"
cd "$DAY"
dotnet new console

cat > Program.cs <<EOL
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        string[] lines = File.ReadAllLines(@"input.txt");

        Console.WriteLine("\n---");

        stopwatch.Restart();
        Console.Write($"part one:  {Methods.GetPartOne(lines)}  ");
        Console.WriteLine($"({stopwatch.ElapsedMilliseconds} ms)");

        stopwatch.Restart();
        Console.Write($"part two:  {Methods.GetPartTwo(lines)}  ");
        Console.WriteLine($"({stopwatch.ElapsedMilliseconds} ms)");

        Console.WriteLine("---\n");
    }
}
EOL

cat > Methods.cs <<EOL
public static class Methods
{
    public static long GetPartOne(string[] lines)
    {
        long sum = 0;

        foreach (var line in lines)
        {
            //
        }

        return sum;
    }

    public static long GetPartTwo(string[] lines)
    {
        long sum = 0;

        foreach (var line in lines)
        {
            //
        }

        return sum;
    }
}
EOL

touch input.txt

code -n .