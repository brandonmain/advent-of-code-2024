using AoC_2024;
using System.Diagnostics;

var day = DayFactory.GetAndInitDay(day: args[0]);
var stopwatch = Stopwatch.StartNew();
day.Run();
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed.TotalSeconds.ToString());
