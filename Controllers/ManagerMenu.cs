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
            Console.WriteLine("Adjust route walking time");
            break;
          case 2:
            Console.Clear();
            Console.WriteLine("Close a route");
            break;
          case 3:
            Console.Clear();
            Console.WriteLine("Check all closed routes");
            break;
          case 4:
            Console.Clear();
            Console.WriteLine("Check all delayed routes");
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
  }
}