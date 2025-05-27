// See https://aka.ms/new-console-template for more information
using System;

public class Program // Runs on program execution... Awake();
{
    // To declare MenuManager here at the class level.
    // You'd need to create an instance of Program.
    // Instead, just create an instance of MenuManager in Main which is static.

    // Questions
    // #1 static void Main(); always essential as a utility/program-wide accessbile class?
    // #2 best practices for branching out to other classes, and/or starting instances?
    // #3 making everything static? Consequences?
    
    // static = exists in memory automatically, cannot be instantiated.
    static void Main()    // Main() occurs at program startup // 1st method run
    {
        Console.WriteLine("Welcome to an example krint.dev terminal Script using C#");

        // Initial Reference to MenuManager in a static method.
        // It will always be available program-wide.
        MenuManager menuManager = new MenuManager();
        menuManager.Menu();
    }
}