using System;

class MenuManager
{
    // string? is a nullable type. Meaning it can be null without error (add ?)
    public string? currentSelection { get; private set; }
    public string? ping { get; private set; }

    private NetworkScanner networkScanner;
    
    public void Menu()
    {
        Console.WriteLine("---------Menu----------");
        Console.WriteLine("Enter 1 to scan active network");
        Console.WriteLine("Enter 2 to fetch authentication/encrpytion of active network");
        Console.WriteLine("Enter 0 to exit");
        
        currentSelection = Console.ReadLine();
        
        if (currentSelection == "1") // SCAN
        {
            networkScanner = new NetworkScanner(); // Initialize the instance
            networkScanner.ScanConnectedNetwork();
            Menu(); // Return to menu after scan
            // ScanConnectedNetworkManager scanManager = new ScanConnectedNetworkManager();
            // scanManager.ScanConnectedNetwork(); // Call instance method
        }
        
        if (currentSelection == "2") // FETCH AUTH
        {
            networkScanner = new NetworkScanner(); // Initialize the instance
            networkScanner.FetchActiveConnectionAuthentication();
            Menu(); // Return to menu after scan
            // ScanConnectedNetworkManager scanManager = new ScanConnectedNetworkManager();
            // scanManager.ScanConnectedNetwork(); // Call instance method
        }
        else
        {
            Console.WriteLine("Exiting Program...");
        }
    }
}