using System;

class MenuManager
{
    // string? is a nullable type. Meaning it can be null without error (add ?)
    public string? currentSelection { get; private set; }
    public string? ping { get; private set; }

    private NetworkScanner networkScanner;
    
    public void Menu()
    {
        Console.WriteLine("------Menu------");
        Console.WriteLine("Enter 1 to scan currently connected network");
        Console.WriteLine("Enter 0 to exit");
        Console.WriteLine("----------------");
        
        currentSelection = Console.ReadLine();
        
        if (currentSelection == "1") // switch
        {
            networkScanner = new NetworkScanner(); // Initialize the instance
            networkScanner.ScanConnectedNetwork();
            // ScanConnectedNetworkManager scanManager = new ScanConnectedNetworkManager();
            // scanManager.ScanConnectedNetwork(); // Call instance method
        }
        else
        {
            Console.WriteLine("Exiting Program...");
        }
    }
}