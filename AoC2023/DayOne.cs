using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace AoC2023;

public class DayOne : IAoCMethod
{
    private static readonly string[] _startsWithO = { "one" };
    private static readonly string[] _startsWithT = { "two", "three" };
    private static readonly string[] _startsWithF = { "four", "five" };
    private static readonly string[] _startsWithS = { "six", "seven" };
    private static readonly string[] _startsWithE = { "eight" };
    private static readonly string[] _startsWithN = { "nine" };

    private string _input;
    
    public DayOne(string input)
    {
        _input = File.ReadAllText(input);
    }
    
    public (int, double) PartOne()
    {
        var sw = Stopwatch.StartNew();
        int sum = 0;

        foreach (var line in _input.AsSpan().EnumerateLines())
        {
            if (line.Length == 0)
                continue;
            var digit0 = -1;
            var digit1 = -1;
            
            for (var charIdx = 0; charIdx < line.Length; charIdx++)
            {
                if (digit0 == -1)
                    digit0 = GetDigit(line, charIdx, false);
                if (digit1 == -1)
                    digit1 = GetDigit(line, line.Length - 1 - charIdx, false);
                if (digit0 >= 0 && digit1 >= 0)
                    break;
            }

            var digitValue = digit0 * 10 + digit1;
            sum += digitValue;
        }

        return (sum, sw.Elapsed.TotalMicroseconds);
    }
    
    public (int, double) PartTwo()
    {
        var sw = Stopwatch.StartNew();
        int sum = 0;

        foreach (var line in _input.AsSpan().EnumerateLines())
        {
            if (line.Length == 0)
                continue;
            var digit0 = -1;
            var digit1 = -1;
            
            for (var charIdx = 0; charIdx < line.Length; charIdx++)
            {
                if (digit0 == -1)
                    digit0 = GetDigit(line, charIdx, true);
                if (digit1 == -1)
                    digit1 = GetDigit(line, line.Length - 1 - charIdx, true);
                if (digit0 >= 0 && digit1 >= 0)
                    break;
            }
            
            var digitValue = digit0 * 10 + digit1;
            sum += digitValue;
        }

        return (sum, sw.Elapsed.TotalMicroseconds);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetDigit(ReadOnlySpan<char> line, int charIdx, bool searchText)
    {
        if (char.IsDigit(line[charIdx]))
            return line[charIdx] - '0';

        if (!searchText) return -1;
        
        var validTextDigits = line[charIdx] switch
        {
            'o' => _startsWithO,
            't' => _startsWithT,
            'f' => _startsWithF,
            's' => _startsWithS,
            'e' => _startsWithE,
            'n' => _startsWithN,
            _ => Array.Empty<string>()
        };
        
        for (var i = validTextDigits.Length - 1; i >= 0; i--)
        {
            var textDigit = validTextDigits[i];
            if (charIdx + textDigit.Length > line.Length)
                continue;
                    
            for (int j = textDigit.Length - 1; j >= 0; j--)
            {
                if (textDigit[j] != line[charIdx + j])
                    goto nextLoop;
            }
            
            return textDigit switch
            {
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => 0
            };
            nextLoop: ;
        }

        return -1;
    }
}