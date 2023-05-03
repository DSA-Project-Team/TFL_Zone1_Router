namespace tflzone1.Models
{
  class ManagerMenu
  {
    public static void OptionMenu()
    {
      string errorMessage = "Error: Enter only 1, 2, 3, 4, or 5 to select your preferred menu option";

      MenuHelper.MenuHeader();
      Console.WriteLine("Manager Menu\n");
      Console.WriteLine("(1) Adjust route walking time");
      Console.WriteLine("(2) Close a route");
      Console.WriteLine("(3) Check all closed routes");
      Console.WriteLine("(4) Check all delayed routes");
      Console.WriteLine("(5) Go back\n");

      (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1, 2, 3, 4, or 5 to select an option");

      if (isInputInteger)
      {
        switch (inputValue)
        {
          case 1:
            Console.Clear();
            ChangeRouteTimeMenu();
            break;
          case 2:
            Console.Clear();
            CloseRouteMenu();
            break;
          case 3:
            Console.Clear();
            CheckClosedRouteMenu();
            break;
          case 4:
            Console.Clear();
            CheckDelayedRouteMenu();
            break;
          case 5:
            Console.Clear();
            MainMenu.UserSelectMenu();
            break;
          default:
            MenuHelper.ErrorMessage(errorMessage);
            OptionMenu();
            break;
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        OptionMenu();
      }
    }

    public static void ChangeRouteTimeMenu() { }
    public static void CloseRouteMenu() { }
    public static void CheckClosedRouteMenu() { }
    public static void CheckDelayedRouteMenu()
    {
      string errorMessage = "Error: Enter only 1 to select your preferred menu option";

      MenuHelper.MenuHeader();
      Console.WriteLine("All delayed routes\n");

      //TODO: Dynamically render the list using a loop and fetching the data from the "delayed routes" list (It is hardcoded ATM)

      //TODO: The "delayed routes" list should have the have objects with the following properties: Line name, start station, end station, previous route time, and current route time.

      Console.WriteLine("Victoria Line: Oxford Circus - Warren Street : 18 min now 23 min");
      Console.WriteLine("Victoria Line: Oxford Circus - Warren Street : 18 min now 23 min");
      Console.WriteLine("Victoria Line: Oxford Circus - Warren Street : 18 min now 23 min");

      (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1 to go back to the main manager menu");

      if (isInputInteger)
      {
        switch (inputValue)
        {
          case 1:
            Console.Clear();
            OptionMenu();
            break;
          default:
            MenuHelper.ErrorMessage(errorMessage);
            CheckDelayedRouteMenu();
            break;
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        CheckDelayedRouteMenu();
      }
    }
  }
}