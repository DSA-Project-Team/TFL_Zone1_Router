using System;
using testing_and_benchmarking;
using tflzone1.Controllers;

namespace tflzone1.Models
{
  class MainMenu
  {
    private Graph graph = GraphConstructor.graph;
    public static void UserSelectMenu()
    {
      string errorMessage = "Error: Enter only 1, 2 or 3 to select your preferred user profile";

      MenuHelper.MenuHeader();
      Console.WriteLine("Welcome to TFL tube walking route checker app,\nplease select your preferred user profile to access\nthe app menu.\n");
      Console.WriteLine("(1) Customer");
      Console.WriteLine("(2) Manager");
      Console.WriteLine("(3) See Test Runtime Results\n");

      (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1 2, or 3 to select an option");

      if (isInputInteger)
      {
        switch (inputValue)
        {
          case 1:
            Console.Clear();
            CustomerMenu.OptionMenu();
            break;
          case 2:
            Console.Clear();
            ManagerMenu.OptionMenu();
            break;
          case 3:
            Console.Clear();
            RunTimeAnalyzer.DisplayRunTimeDiagnostics();
            UserSelectMenu();
            break;
          default:
            MenuHelper.ErrorMessage(errorMessage);
            UserSelectMenu();
            break;
        }
      }
      else
      {
        MenuHelper.ErrorMessage(errorMessage);
        UserSelectMenu();
      }
    }
  }
}