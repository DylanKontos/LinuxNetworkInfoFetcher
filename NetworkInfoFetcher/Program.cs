// See https://aka.ms/new-console-template for more information
using System;

public class Program
{
    // Main is static so "seperate to the public class Program". #Q1 How?
    // Therefore, to declare MenuManager menuManager here, at the class level
    // You'd need to create an instance of Program
    // private MenuManager menuManager;
    // Instead, just create an instance of MenuManager in Main

    // Question
    // #1 static void Main(); is always the go to?
    // #2 best practices for branching out to other classes, and/or starting instances	
    // #3 making everything static? bad?

    static void Main()    // Main() occurs at program startup // 1st method run
    {
        Console.WriteLine("Welcome to an example krint.dev terminal Script using C#");

        // Initial Reference to MenuManager
        MenuManager menuManager = new MenuManager();
        menuManager.Menu();
    }
}