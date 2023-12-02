using System.Diagnostics;

namespace AoC2023;

public class DayTwo : IAoCMethod
{
    private string _input;
    private int _red, _green, _blue;
    
    public DayTwo(string input, int red, int green, int blue)
    {
        _input = File.ReadAllText(input);
        _red = red;
        _green = green;
        _blue = blue;
    }
    
    public (int, double) PartOne()
    {
        var sw = Stopwatch.StartNew();
        int sum = 0;

        List<int> possibleGames = new();
        
        int gameIdx = 1;
        foreach (var line in _input.AsSpan().EnumerateLines())
        {
            if (line.Length == 0)
                continue;

            int charIdx = 5;
            while (line[charIdx] != ':')
                ++charIdx;
            charIdx += 2;

            
            int currentGame = 0;
            while (charIdx < line.Length)
            {
                while (charIdx < line.Length && line[charIdx] != ';')
                {
                    while (charIdx < line.Length && line[charIdx] != ',' && line[charIdx] != ';')
                    {
                        int numDigits = 1;
                        while (line[charIdx + numDigits] != ' ')
                            ++numDigits;
                        var num = int.Parse(line.Slice(charIdx, numDigits));

                        charIdx += numDigits;

                        charIdx++;

                        switch (line[charIdx])
                        {
                            case 'r':
                                charIdx += 3;
                                if (num > _red)
                                    goto nextGame;

                                break;
                            case 'g':
                                charIdx += 5;
                                if (num > _green)
                                    goto nextGame;

                                break;
                            case 'b':
                                charIdx += 4;
                                if (num > _blue)
                                    goto nextGame;

                                break;
                        }
                    }

                    if (charIdx < line.Length && line[charIdx] != ';')
                        charIdx += 2;
                }
                ++currentGame;
                charIdx += 2;
            }
            possibleGames.Add(gameIdx);
            nextGame:
            ++gameIdx;
        }
        
        
        return (possibleGames.Sum(), sw.Elapsed.TotalMicroseconds);
    }

    public (int, double) DayTwoPartTwoBoring(string text)
    {
        StreamReader sr = new StreamReader("/Users/dom/Documents/Wayfarer Games/AoC/AoC2023/Day2_Input.txt");

        var sw = Stopwatch.StartNew();
        int sum = 0;

        while (!sr.EndOfStream)
        {
            int maxRed = 0;
            int maxGreen = 0;
            int maxBlue = 0;

            string line = sr.ReadLine();

            string[] firstSplit = line.Split(": ");

            int gameNr = int.Parse(firstSplit[0].Split(' ')[1]);

            string[] secondSplit = firstSplit[1].Split("; ");

            foreach (string s in secondSplit)
            {
                string[] thirdSplit = s.Split(", ");

                foreach (string s2 in thirdSplit)
                {
                    if (s2.Contains("red"))
                    {
                        int sumRed = int.Parse(s2.Split(' ')[0]);

                        if (sumRed > maxRed)
                        {
                            maxRed = sumRed;
                        }
                    }
                    else if (s2.Contains("green"))
                    {
                        int sumGreen = int.Parse(s2.Split(' ')[0]);

                        if (sumGreen > maxGreen)
                        {
                            maxGreen = sumGreen;
                        }
                    }
                    else if (s2.Contains("blue"))
                    {
                        int sumBlue = int.Parse(s2.Split(' ')[0]);

                        if (sumBlue > maxBlue)
                        {
                            maxBlue = sumBlue;
                        }
                    }
                }
            }

            int total = maxRed * maxGreen * maxBlue;
            sum += total;
        }

        return (sum, sw.Elapsed.TotalMicroseconds);
    }
    
    public (int, double) PartTwo()
    {
        var sw = Stopwatch.StartNew();
        int sum = 0;
        
        int gameIdx = 1;
        foreach (var line in _input.AsSpan().EnumerateLines())
        {
            if (line.Length == 0)
                continue;

            int charIdx = 5;
            while (line[charIdx] != ':')
                ++charIdx;
            charIdx += 2;
            
            int currentGame = 0;
            int maxRed = 0;
            int maxGreen = 0;
            int maxBlue = 0;
            // game
            while (charIdx < line.Length)
            {
                // match
                while (charIdx < line.Length && line[charIdx] != ';')
                {
                    // number of red/blue/green
                    while (charIdx < line.Length && line[charIdx] != ',' && line[charIdx] != ';')
                    {
                        int numDigits = 1;
                        while (line[charIdx + numDigits] != ' ')
                            ++numDigits;

                        var num = numDigits switch
                        {
                            1 => line[charIdx] - '0',
                            2 => (line[charIdx] - '0') * 10 + (line[charIdx + 1] - '0'),
                            _ => 0
                        };
                        
                        charIdx += numDigits;

                        charIdx++;

                        switch (line[charIdx])
                        {
                            case 'r':
                                charIdx += 3;
                                maxRed = Math.Max(num, maxRed);
                                break;
                            case 'g':
                                charIdx += 5;
                                maxGreen = Math.Max(num, maxGreen);
                                break;
                            case 'b':
                                charIdx += 4;
                                maxBlue = Math.Max(num, maxBlue);
                                break;
                        }
                    }

                    if (charIdx < line.Length && line[charIdx] != ';')
                        charIdx += 2;
                }
                ++currentGame;
                charIdx += 2;
            }
            sum += maxRed * maxGreen * maxBlue;
            ++gameIdx;
        }
        
        return (sum, sw.Elapsed.TotalMicroseconds);
    }
}