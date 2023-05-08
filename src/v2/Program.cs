using System;
using v2.Controllers;

namespace v2;
class Program
{
    static void Main(string[] args)
    {
        // TFL ZONE 1
        GraphConstructor.ConstructGraph();
        var graph = GraphConstructor.graph;
        MainMenu.UserSelectMenu();
    }
}
