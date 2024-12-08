using AoC_2024;
using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();
var day = DayFactory.GetAndInitDay(day: args[0]);
day.Run();
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed.TotalSeconds.ToString());
