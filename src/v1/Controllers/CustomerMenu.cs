using System;
using tflzone1.Controllers;

namespace tflzone1.Models
{
  class CustomerMenu
  {
    private static Graph graph = GraphConstructor.graph;
    public static void OptionMenu()
    {
      string errorMessage = "Error: Enter only 1, 2, or 3 to select your preferred menu option";

      MenuHelper.MenuHeader();
      Console.WriteLine("Customer Menu\n");
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

      string startLine = MenuHelper.lineInputChecker("Enter Start line");

      (bool isStartStationCorrect, string startStation) = MenuHelper.stationInputChecker("Enter Start Station", startLine);

      string endLine = MenuHelper.lineInputChecker("Enter End line");

      (bool isEndStationCorrect, string endStation) = MenuHelper.stationInputChecker("Enter End Station", endLine);


      if (isStartStationCorrect && isEndStationCorrect)
      {
        Console.Clear();
        graph.FindFastestWalkingRoute(startStation, endStation);
        ShowRouteMenu();
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

      string stationLine = MenuHelper.lineInputChecker("Enter Station line");
      (bool isStationCorrect, string station) = MenuHelper.stationInputChecker("Enter Station", stationLine);

      if (isStationCorrect)
      {
        Console.Clear();
        ShowStationInfo(station);
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        CheckStationMenu();
      }
    }

    public static void ShowRouteMenu()
    {
      string errorMessage = "Error: Enter only 1 or 2 to select your preferred menu option";

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
            ShowRouteMenu();
            break;
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        ShowRouteMenu();
      }
    }

    public static void ShowStationInfo(string stationName)
    {
      //TODO: Call function that gets the station information , probably in the form of a object with the following properties: id, name, tube line (central, circle, etc), travel zone (zone 1, etc), and station status (closed, opened, or delayed) 

      string errorMessage = "Error: Enter only 1 or 2 to select your preferred menu option";

      var station = graph.GetStationInfo(stationName);

      if(station is null) {
        MenuHelper.ErrorMessage("Station not found");
      } else {
        MenuHelper.MenuHeader();
        Console.WriteLine("Station Information\n");
        Console.WriteLine($"Station Name: {TextHelper.CapitalizeFirstLetter(station.Node.Split(':')[1])}");
        Console.WriteLine($"Tube Line: {TextHelper.CapitalizeFirstLetter(station.Node.Split(':')[0])}");
        Console.WriteLine($"Travel Zone: Zone 1");
        Console.WriteLine($"Station Status: {station.Status}\n");
      }



      (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1 to check another station information or 2 to go to main customer menu");

      if (isInputInteger)
      {
        switch (inputValue)
        {
          case 1:
            Console.Clear();
            CheckStationMenu();
            break;
          case 2:
            Console.Clear();
            OptionMenu();
            break;
          default:
            MenuHelper.ErrorMessage(errorMessage);
            ShowStationInfo(stationName);
            break;
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        ShowStationInfo(stationName);
      }
    }
  }
}