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
