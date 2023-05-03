using tflzone1.Controllers;

namespace tflzone1.Models
{
  class MainMenu
  {
    private Graph graph = GraphConstructor.graph;
    public static void UserSelectMenu()
    {
      string errorMessage = "Error: Enter only 1 or 2 to select your preferred user profile";

      MenuHelper.MenuHeader();
      Console.WriteLine("Welcome to TFL tube walking route checker app,\nplease select your preferred user profile to access\nthe app menu.\n");
      Console.WriteLine("(1) Customer");
      Console.WriteLine("(2) Manager\n");

      (bool isInputInteger, int inputValue) = MenuHelper.InputChecker("Enter 1 or 2 to select an option");

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