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
        Console.Clear();
        ShowRouteMenu(startStation, endStation);
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        FindRouteMenu();
      }
    }
    public static void CheckStationMenu()
    {
      string errorMessage = "Error: An invalid station was entered. Do not enter stations outside zone 1, DLR, Elizabeth Line, and London Overground rail lines";

      MenuHelper.MenuHeader();
      Console.WriteLine("Check any station information within Zone 1.\n");

      (bool isStationCorrect, string station) = MenuHelper.stationInputChecker("Enter Station");

      if (isStationCorrect)
      {
        // Go to station information
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        CheckStationMenu();
      }
    }

    public static void ShowRouteMenu(string startStation, string endStation)
    {
      // TODO: Call function that calculates the travel time and generates the route path including change over stations etc.

      // TODO: Get the Line names of the startStation and the endStation. The values are currently hardcoded

      string errorMessage = "Error: Enter only 1 or 2 to select your preferred menu option";
      int totalJourneyTime = 36;
      string start = TextHelper.CapitalizeFirstLetter(startStation);
      string end = TextHelper.CapitalizeFirstLetter(endStation);

      MenuHelper.MenuHeader();
      Console.WriteLine($"Route: {start} to {end}\n\n");
      Console.WriteLine($"Start: {start} (Central)\n");

      //TODO: Input change over details here

      Console.WriteLine($"End: {end} (Cicle)\n");
      Console.WriteLine($"Total Journey Time: {totalJourneyTime}min\n");

      (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1 to find another route or 2 to go to main customer menu");

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
            OptionMenu();
            break;
          default:
            MenuHelper.ErrorMessage(errorMessage);
            ShowRouteMenu(startStation, endStation);
            break;
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        ShowRouteMenu(startStation, endStation);
      }
    }
  }
}