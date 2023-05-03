namespace tflzone1.Models
{
  class MenuHelper
  {
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

    public static (bool, string) stationInputChecker(string inputInstuction)
    {
      Console.Write($"{inputInstuction}: ");
      var inputValue = Console.ReadLine();

      string station = inputValue != null ? inputValue : "";

      // List of dummy route names within zone 1 (to be changed later)
      List<string> validRoutes = new List<string> { "Oxford Circus", "Paddington", "Waterloo" };

      //TODO: Check if the route name exists within zone 1 and change the state of isRouteValid accordingly [It is important to convert route input value and actual route values to lowercase before comparing them because some users might enter "oxford Circus" instead of "Oxford Circus"]

      bool isRouteValid = validRoutes.Contains(station);

      return (isRouteValid, station);
    }

    public static string CapitalizeFirstLetter(string content)
    {
      if (string.IsNullOrEmpty(content))
      {
        return content;
      }

      string[] words = content.Split(' ');

      for (int i = 0; i < words.Length; i++)
      {
        if (words[i].Length > 0)
        {
          char firstChar = Char.ToUpper(words[i][0]);
          words[i] = firstChar + words[i].Substring(1).ToLower();
        }
      }

      return string.Join(" ", words);
    }
  }
}