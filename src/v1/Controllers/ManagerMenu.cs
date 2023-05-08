using System;
using tflzone1.Controllers;

namespace tflzone1.Models
{
  class ManagerMenu
  {
    private static Graph graph = GraphConstructor.graph;
    public static void OptionMenu()
    {
      string errorMessage = "Error: Enter only 1, 2, 3, 4, 5, 6 or 7 to select your preferred menu option";

      MenuHelper.MenuHeader();
      Console.WriteLine("Manager Menu\n");
      Console.WriteLine("(1) Adjust route walking time");
      Console.WriteLine("(2) Reset route walking time");
      Console.WriteLine("(3) Check all delayed routes");
      Console.WriteLine("(4) Close a route");
      Console.WriteLine("(5) Open a closed route");
      Console.WriteLine("(6) Check all closed routes");
      Console.WriteLine("(7) Go back\n");

      (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1, 2, 3, 4, 5, 6 or 7 to select an option");

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
            ResetRouteTimeMenu();
            break;
          case 3:
            Console.Clear();
            CheckDelayedRouteMenu();
            break;
          case 4:
            Console.Clear();
            CloseRouteMenu();
            break;
          case 5:
            Console.Clear();
            OpenClosedRouteMenu();
            break;
          case 6:
            Console.Clear();
            CheckClosedRouteMenu();
            break;
          case 7:
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
      (bool isNewRouteTimeCorrect, int delay) = MenuHelper.InputChecker("Enter Delay Time (in minutes)");

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
          ChangeRouteTimeMenu();
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

    public static void ResetRouteTimeMenu()
    {
      string errorMessage1 = "Error: Invalid routes entered";
      string errorMessage2 = "Error: Enter only 1 or 2 to select your preferred option";

      MenuHelper.MenuHeader();
      Console.WriteLine("Reset Route Walking Time\n");

      string startLine = MenuHelper.lineInputChecker("Enter Start line");
      (bool isStartStationCorrect, string startStation) = MenuHelper.stationInputChecker("Enter Start Station", startLine);
      string nextLine = MenuHelper.lineInputChecker("Enter End line");
      (bool isNextStationCorrect, string nextStation) = MenuHelper.stationInputChecker("Enter Next Station", nextLine);

      void ShowNavigation()
      {
        (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1 to reset another route walking time or 2 to go back to the main manager menu");

        if (isInputInteger)
        {
          switch (inputValue)
          {
            case 1:
              Console.Clear();
              ResetRouteTimeMenu();
              break;
            case 2:
              Console.Clear();
              OptionMenu();
              break;
            default:
              MenuHelper.ErrorMessage(errorMessage2);
              ResetRouteTimeMenu();
              break;
          }
        }
        else
        {
          MenuHelper.ErrorMessage(errorMessage2);
          ResetRouteTimeMenu();
        }
      }

      if (isStartStationCorrect && isNextStationCorrect)
      {
        var from  = startStation.Trim();
        var to  = nextStation.Trim();

        Console.WriteLine($"{from} and {to}");

        //TODO: Check if the stations entered are next to eachother: For example, Paddington and Edgware road are next to eachother, so set areStartionNext variable to true and vice versa.
        var delayRemoved = graph.RemoveDelay(from.ToLower(), to.ToLower());

        if (delayRemoved)
        {
          //TODO: Write logic to change the route time to the new route time: Update the state

          MenuHelper.SuccessMessage($"Success: The walking route time from {TextHelper.CapitalizeFirstLetter(startStation)} to {TextHelper.CapitalizeFirstLetter(nextStation)} is now normal");
          ShowNavigation();
        }
        else
        {
          MenuHelper.ErrorMessage($"Error: {TextHelper.CapitalizeFirstLetter(startStation)} and {TextHelper.CapitalizeFirstLetter(nextStation)} are not next to each other or do not exist");
          ResetRouteTimeMenu();
        }

      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage1);
        ResetRouteTimeMenu();
      }

    }
    public static void CloseRouteMenu()
    {
      string errorMessage = "Error: An invalid station was entered. Do not enter stations outside zone 1, DLR, Elizabeth Line, and London Overground rail lines";

      MenuHelper.MenuHeader();
      Console.WriteLine("Close a route\n");

      string fromStationLine = MenuHelper.lineInputChecker("Enter Start Station line");
      (bool isFromStationCorrect, string fromStation) = MenuHelper.stationInputChecker("Enter Start Station", fromStationLine);
      string toStationLine = MenuHelper.lineInputChecker("Enter End Station line");
      (bool isToStationCorrect, string toStation) = MenuHelper.stationInputChecker("Enter End Station", toStationLine);
      Console.WriteLine("Enter the reason why this station is being closed: ");
      string? closureReason = Console.ReadLine();

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

      if (isFromStationCorrect && isToStationCorrect)
      {
        var routeClosed = graph.MakeRouteImpossible(fromStation, toStation, closureReason);

        if (!routeClosed)
        {
          MenuHelper.ErrorMessage($"Failed: Route is already closed!");
          ShowNavigation();
        }
        else
        {
          MenuHelper.SuccessMessage($"Success: Route has been closed successfully!");
          ShowNavigation();
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        CloseRouteMenu();
      }
    }
    public static void OpenClosedRouteMenu()
    {
      string errorMessage = "Error: An invalid station was entered. Do not enter stations outside zone 1, DLR, Elizabeth Line, and London Overground rail lines";

      MenuHelper.MenuHeader();
      Console.WriteLine("Open a closed route\n");

      string fromStationLine = MenuHelper.lineInputChecker("Enter Start Station line");
      (bool isFromStationCorrect, string fromStation) = MenuHelper.stationInputChecker("Enter Start Station", fromStationLine);
      string toStationLine = MenuHelper.lineInputChecker("Enter End Station line");
      (bool isToStationCorrect, string toStation) = MenuHelper.stationInputChecker("Enter End Station", toStationLine);

      void ShowNavigation()
      {
        (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1 to open another route or 2 to go back to the main manager menu");

        if (isInputInteger)
        {
          switch (inputValue)
          {
            case 1:
              Console.Clear();
              OpenClosedRouteMenu();
              break;
            case 2:
              Console.Clear();
              OptionMenu();
              break;
            default:
              MenuHelper.ErrorMessage(errorMessage);
              OpenClosedRouteMenu();
              break;
          }
        }
        else
        {
          MenuHelper.ErrorMessage(errorMessage);
          OpenClosedRouteMenu();
        }
      }

      if (isFromStationCorrect && isToStationCorrect)
      {
        var routeOpened = graph.MakeRoutePossible(fromStation, toStation);

        if (!routeOpened)
        {
          MenuHelper.ErrorMessage($"Failed: Route is already closed!");
          ShowNavigation();
        }
        else
        {
          MenuHelper.SuccessMessage($"Success: Route has been closed successfully!");
          ShowNavigation();
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        OpenClosedRouteMenu();
      }
    }
    
    public static void CheckClosedRouteMenu()
    {
      string errorMessage = "Error: Enter only 1 to select your preferred menu option";

      MenuHelper.MenuHeader();
      graph.DisplayImpossibleRoutes();


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
      
      graph.DisplayDelayedRoutes();

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