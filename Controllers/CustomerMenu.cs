namespace tflzone1.Models
{
  class CustomerMenu
  {
    public static void OptionMenu()
    {
      string errorMessage = "Error: Enter only 1, 2, or 3 to select your preferred menu option";

      MenuHelper.MenuHeader();
      Console.WriteLine("Manager Menu\n");
      Console.WriteLine("(1) Find a route");
      Console.WriteLine("(2) Check station information");
      Console.WriteLine("(3) Go back\n");

      (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1, 2, or 3 to select an option");

      if (isInputInteger)
      {
        switch (inputValue)
        {
          case 1:
            Console.Clear();
            FindRouteMenu();
            break;
          case 2:
            Console.Clear();
            CheckStationMenu();
            break;
          case 3:
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

    public static void FindRouteMenu()
    {
      string errorMessage = "Error: An invalid station was entered. Do not enter stations outside zone 1, DLR, Elizabeth Line, and London Overground rail lines";

      MenuHelper.MenuHeader();
      Console.WriteLine("Find the fastest route to your destination within Zone 1.\n");

      (bool isStartStationCorrect, string startStation) = MenuHelper.stationInputChecker("Enter Start Station");

      (bool isEndStationCorrect, string endStation) = MenuHelper.stationInputChecker("Enter End Station");

      if (isStartStationCorrect && isEndStationCorrect)
      {
        // Go to route information
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        FindRouteMenu();
      }
    }
    public static void CheckStationMenu() { }
  }
}