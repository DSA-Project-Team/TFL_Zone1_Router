namespace tflzone1.Models
{
  class MenuHelper
  {
    public static void MenuHeader()
    {
      Console.WriteLine("===================================================");
      Console.WriteLine("===== TFL TUBE WALKING ROUTE (ZONE 1) CHECKER =====");
      Console.WriteLine("===================================================");
      Console.WriteLine("");

    }

    public static void ErrorMessage(string message)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"\n{message}\n");
      Console.ResetColor();
    }

    public static (bool, int) InputCommand(string inputInstuction)
    {
      Console.Write($"\n{inputInstuction}: ");

      var inputValue = Console.ReadLine();
      int inputValueOut;
      bool isInputInteger = int.TryParse(inputValue, out inputValueOut);

      return (isInputInteger, inputValueOut);
    }
  }
}