using tflzone1.Controllers;

namespace tflzone1.Models
{
  class ManagerMenu
  {
    private static Graph graph = GraphConstructor.graph;
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

    public static void ChangeRouteTimeMenu()
    {
      string errorMessage1 = "Error: Invalid routes or route time entered";
      string errorMessage2 = "Error: Enter only 1 or 2 to select your preferred option";

      MenuHelper.MenuHeader();
      Console.WriteLine("Adjust Route Walking Time\n");

      string startLine = MenuHelper.lineInputChecker("Enter Start line");
      (bool isStartStationCorrect, string startStation) = MenuHelper.stationInputChecker("Enter Start Station", startLine);
      string nextLine = MenuHelper.lineInputChecker("Enter End line");
      (bool isNextStationCorrect, string nextStation) = MenuHelper.stationInputChecker("Enter Next Station", nextLine);
      (bool isNewRouteTimeCorrect, int delay) = MenuHelper.InputChecker("Enter New Route Time (in minutes)");

      bool areStartionNext = true; // hardcoded

      void ShowNavigation()
      {
        (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1 to adjust another route walking time or 2 to go back to the main manager menu");

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
              OptionMenu();
              break;
            default:
              MenuHelper.ErrorMessage(errorMessage2);
              ChangeRouteTimeMenu();
              break;
          }
        }
        else
        {
          MenuHelper.ErrorMessage(errorMessage2);
          CloseRouteMenu();
        }
      }

      if (isStartStationCorrect && isNextStationCorrect && isNewRouteTimeCorrect)
      {
        var from  = startStation.Trim();
        var to  = nextStation.Trim();

        Console.WriteLine($"{from} and {to}");

        //TODO: Check if the stations entered are next to eachother: For example, Paddington and Edgware road are next to eachother, so set areStartionNext variable to true and vice versa.
        var delayAdded = graph.AddDelay(from.ToLower(), to.ToLower(), delay);

        if (delayAdded)
        {
          //TODO: Write logic to change the route time to the new route time: Update the state

          MenuHelper.SuccessMessage($"Success: The walking route time from {TextHelper.CapitalizeFirstLetter(startStation)} to {TextHelper.CapitalizeFirstLetter(nextStation)} has been delayed by {delay} minutes");
          ShowNavigation();
        }
        else
        {
          MenuHelper.ErrorMessage($"Error: {TextHelper.CapitalizeFirstLetter(startStation)} and {TextHelper.CapitalizeFirstLetter(nextStation)} are not next to each other or do not exist");
          ChangeRouteTimeMenu();
        }

      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage1);
        ChangeRouteTimeMenu();
      }

    }
    public static void CloseRouteMenu()
    {
      string errorMessage = "Error: An invalid station was entered. Do not enter stations outside zone 1, DLR, Elizabeth Line, and London Overground rail lines";
      bool stationIsClosed = false;  // hardcoded

      MenuHelper.MenuHeader();
      Console.WriteLine("Close a route\n");

      string stationLine = MenuHelper.lineInputChecker("Enter Station line");
      (bool isStationCorrect, string station) = MenuHelper.stationInputChecker("Enter Station", stationLine);

      void ShowNavigation()
      {
        (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1 to close another route or 2 to go back to the main manager menu");

        if (isInputInteger)
        {
          switch (inputValue)
          {
            case 1:
              Console.Clear();
              CloseRouteMenu();
              break;
            case 2:
              Console.Clear();
              OptionMenu();
              break;
            default:
              MenuHelper.ErrorMessage(errorMessage);
              CloseRouteMenu();
              break;
          }
        }
        else
        {
          MenuHelper.ErrorMessage(errorMessage);
          CloseRouteMenu();
        }
      }

      if (isStationCorrect)
      {
        //TODO: CHECK if the station is already closed and change the hardcoded stationIsClosed variable

        if (stationIsClosed)
        {
          MenuHelper.ErrorMessage($"Failed: {TextHelper.CapitalizeFirstLetter(station)} is already closed!");
          ShowNavigation();
        }
        else
        {
          //TODO: Call function that closes the station
          MenuHelper.SuccessMessage($"Success: {TextHelper.CapitalizeFirstLetter(station)} has been closed successfully!");
          ShowNavigation();
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        CloseRouteMenu();
      }
    }
    public static void CheckClosedRouteMenu()
    {
      string errorMessage = "Error: Enter only 1 to select your preferred menu option";

      MenuHelper.MenuHeader();
      Console.WriteLine("All closed routes\n");

      //TODO: Dynamically render the list using a loop and fetching the data from the "closed routes" list (It is hardcoded ATM)

      //TODO: The "closed routes" list should have the have objects with the following properties: Line name, start station, and end station

      Console.WriteLine("Northern Line: London Bridge - Monument: Closed");
      Console.WriteLine("Northern Line: London Bridge - Monument: Closed");
      Console.WriteLine("Northern Line: London Bridge - Monument: Closed");
      Console.WriteLine("Northern Line: London Bridge - Monument: Closed");

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
            CheckClosedRouteMenu();
            break;
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        CheckClosedRouteMenu();
      }
    }
    public static void CheckDelayedRouteMenu()
    {
      string errorMessage = "Error: Enter only 1 to select your preferred menu option";

      MenuHelper.MenuHeader();
      Console.WriteLine("All delayed routes\n");

      //TODO: Dynamically render the list using a loop and fetching the data from the "delayed routes" list (It is hardcoded ATM)

      //TODO: The "delayed routes" list should have the have objects with the following properties: Line name, start station, end station, previous route time, and current route time.
      DisplayDelayedRoutes();

      // Console.WriteLine("Victoria Line: Oxford Circus - Warren Street : 18 min now 23 min");
      // Console.WriteLine("Victoria Line: Oxford Circus - Warren Street : 18 min now 23 min");
      // Console.WriteLine("Victoria Line: Oxford Circus - Warren Street : 18 min now 23 min");

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

    static void DisplayDelayedRoutes()
    {
      foreach (var vertex in graph.Vertices)
      {
        var delayedRoutes = vertex.Value.GetDelayedRoutes();

        foreach (var delayedRoute in delayedRoutes)
        {
          Console.WriteLine($"({vertex.Key} - {delayedRoute.Node}) : {vertex.Value.GetWeight(delayedRoute)} mins");
        }
      }
    }
  }
}