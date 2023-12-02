namespace AoC2023;

public class AoCMain
{
    public static void Main()
    {
        IAoCMethod method = new DayOne("../../../Day1_Input.txt");
        
        List<double> timingsPart1 = new List<double>(1000);
        List<double> timingsPart2 = new List<double>(1000);
        var sumPart1 = 0;
        var sumPart2 = 0;
        for (int i = 999; i >= 0; --i)
        {
            var (resultOne, timeOne) = method.PartOne();
            var (resultTwo, timeTwo) = method.PartTwo();
            if (i == 999)
                continue;
            timingsPart1.Add(timeOne);
            sumPart1 = resultOne;
            timingsPart2.Add(timeTwo);
            sumPart2 = resultTwo;
        }
        
        Console.WriteLine($"Day 1 Part 1: {sumPart1} | average: {timingsPart1.Average(): 0.00}μs");
        Console.WriteLine($"Day 2 Part 2: {sumPart2} | average: {timingsPart2.Average(): 0.00}μs");
        
        
        method = new DayTwo("../../../Day2_Input.txt", 12, 13, 14);
        
        timingsPart1 = new List<double>(1000);
        timingsPart2 = new List<double>(1000);
        sumPart1 = 0;
        sumPart2 = 0;
        for (int i = 999; i >= 0; --i)
        {
            var (resultOne, timeOne) = method.PartOne();
            var (resultTwo, timeTwo) = method.PartTwo();
            if (i == 999)
                continue;
            timingsPart1.Add(timeOne);
            sumPart1 = resultOne;
            timingsPart2.Add(timeTwo);
            sumPart2 = resultTwo;
        }
        
        Console.WriteLine($"Day 1 Part 1: {sumPart1} | average: {timingsPart1.Average(): 0.00}μs");
        Console.WriteLine($"Day 2 Part 2: {sumPart2} | average: {timingsPart2.Average(): 0.00}μs");
    }
}