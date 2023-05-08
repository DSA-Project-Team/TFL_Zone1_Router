using System;
using System.Collections.Generic;
using System.Linq;
using tflzone1.Controllers;

namespace tflzone1.Models
{
  class MenuHelper
  {
    private static Graph graph = GraphConstructor.graph;
    public static void MenuHeader()
    {
      Console.WriteLine("===================================================");
      Console.WriteLine("===== TFL TUBE WALKING ROUTE (ZONE 1) CHECKER =====");
      Console.WriteLine("===================================================\n");
    }

    public static void ErrorMessage(string message)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"\n{message}\n");
      Console.ResetColor();
    }

    public static void SuccessMessage(string message)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"\n{message}\n");
      Console.ResetColor();
    }

    public static (bool, int) InputChecker(string inputInstuction)
    {
      Console.Write($"\n{inputInstuction}: ");

      var inputValue = Console.ReadLine();
      int inputValueOut;
      bool isInputInteger = int.TryParse(inputValue, out inputValueOut);

      return (isInputInteger, inputValueOut);
    }

    public static (bool, string) stationInputChecker(string inputInstuction, string line)
    {
      Console.Write($"{inputInstuction}: ");
      var inputValue = Console.ReadLine();

      string station = inputValue != null ? $"{line.Trim().ToLower()}: {inputValue.ToLower()}" : line;

      List<string> validRoutes = graph.Vertices.Keys.Select((route) => route.ToLower()).ToList();

      //TODO: List of dummy route names within zone 1 (to be changed later)
      // List<string> validRoutes = new List<string> { "Oxford Circus", "Paddington", "Waterloo" };

      //TODO: Check if the route name exists within zone 1 and change the state of isRouteValid accordingly [It is important to convert route input value from the console and the actual route values from the list to lowercase before comparing them because some users might enter "oxford CircuS" instead of "Oxford Circus", which will result to a mismatch]

      bool isRouteValid = validRoutes.Contains(station);

      return (isRouteValid, station);
    }

    public static string lineInputChecker(string lineInstruction)
    {
      Console.Write($"{lineInstruction}: ");
      var inputValue = Console.ReadLine();

      string line = inputValue != null ? inputValue.ToLower() : ""; 
      return line;
    }
  }
}