using System.Diagnostics;
using testing_and_benchmarking.Utilities;

namespace testing_and_benchmarking;

public static class RunTimeAnalyzer
{
    private static Stopwatch stopwatch = new Stopwatch();
    private static List<string> results = new List<string>();

    public static void Start()
    {
        stopwatch.Start();
    }
    public static void Stop()
    {
        stopwatch.Stop();
    }
    public static TimeSpan GetElapsedTime()
    {
        return stopwatch.Elapsed;
    }

    public static void Reset()
    {
        stopwatch.Reset();
    }

    public static void Save()
    {
        TimeSpan ts = stopwatch.Elapsed;
        results.Add($"{ts.Seconds}:{ts.Milliseconds / 10}");
        stopwatch.Reset();
    }

    private static string CalculateRunTime()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;

        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
        return $"{ts.Seconds}:{ts.Milliseconds / 10}";
    }

    public static void DisplayRunTimeDiagnostics()
    {
        if(results.Count == 0) {
            Console.WriteLine("0 Tests have been run, so no results to see");
            return;
        }

        foreach(var dt in results) 
        {
            Console.WriteLine(dt);
        }
    }
    public static void DisplayRunTimeDiagnostics(List<string> columns, List<string[]> rows)
    {
        columns.Prepend("");
        var table = new ConsoleTable(columns.ToArray());
        foreach(var row in rows) 
        {
            table.AddRow(row);
        }
        table.Write();
    }
}
