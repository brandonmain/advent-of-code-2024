/*
 * Disclaimer and credit: I struggled a bit with this one. My original solution was close but not quite correct.
 * Therefore after checking other solutions I found https://github.com/codevogel/AdventOfCode/blob/3ffc6769ecabe08c4cb9fd9dbb12c6edb2eeb4c1/2024/day8/Solver.cs
 * which most of this solution is based on.
 */

using AoC_2024.Utilities;
using static AoC_2024.Utilities.Utilities;

namespace AoC_2024.Days;

public sealed class Day8 : Day
{
    public override void Run()
    {
        var rowLen = Input.Length;
        var colLen = Input[0].Length;
        var uniqueAntiNodes = new HashSet<Coordinate>();
        var antennas = Input.SelectMany((x, i) => x.Select((y, j) => (Freq: y, Coord: new Coordinate(i, j))))
            .Where(x => x.Freq != '.')
            .ToList();
        var antennaToCoordinates = antennas.GroupBy(x => x.Freq)
            .ToDictionary(x => x.Key, x => x.Select(y => y.Coord).ToList());

        foreach (var antenna in antennas)
        {
            var sameFrequencyAntennas = antennaToCoordinates[antenna.Freq]
                .Where(x => x.Row != antenna.Coord.Row || x.Col != antenna.Coord.Col)
                .ToList();

            foreach (var coord in sameFrequencyAntennas)
            {
                var delta = antenna.Coord - coord;
                var potentialAntinode = antenna.Coord + delta;

                if (IsInGrid(potentialAntinode, rowLen, colLen))
                {
                    uniqueAntiNodes.Add(potentialAntinode);
                }
            }
        }

        Console.WriteLine(uniqueAntiNodes.Count);

        // Part 2
        uniqueAntiNodes.Clear();
        foreach (var antenna in antennas)
        {
            var sameFrequencyAntennas = antennaToCoordinates[antenna.Freq]
                .Where(x => x.Row != antenna.Coord.Row || x.Col != antenna.Coord.Col)
                .ToList();

            foreach (var coord in sameFrequencyAntennas)
            {
                var delta = antenna.Coord - coord;
                var potentialAntinodeA = antenna.Coord + delta;
                var potentialAntinodeB = antenna.Coord - delta;

                while (IsInGrid(potentialAntinodeA, rowLen, colLen))
                {
                    uniqueAntiNodes.Add(potentialAntinodeA);
                    potentialAntinodeA = potentialAntinodeA + delta;
                }
                while (IsInGrid(potentialAntinodeB, rowLen, colLen))
                {
                    uniqueAntiNodes.Add(potentialAntinodeB);
                    potentialAntinodeB = potentialAntinodeB - delta;
                }
            }
        }

        Console.WriteLine(uniqueAntiNodes.Count);
    }
}