using System;

class MenuManager
{
    // string? is a nullable type. Meaning it can be null without error (add ?)
    public string? currentSelection { get; private set; }
    public string? ping { get; private set; }

    // private NetworkScanner networkScanner;
    private readonly NetworkScanner networkScanner = NetworkScanner.Instance; // Use Singleton
    public void Menu()
    {
        Console.WriteLine("---------Menu----------");
        Console.WriteLine("Enter 1 to scan active network");
        Console.WriteLine("Enter 2 to fetch BSSID of active network");
        Console.WriteLine("Enter 3 to fetch encryption of active network");
        Console.WriteLine("Enter 0 to exit");
        
        currentSelection = Console.ReadLine();
        
        if (currentSelection == "1") // SCAN
        {
            // networkScanner = new NetworkScanner(); // Initialize the instance
            networkScanner.ScanConnectedNetwork();
            Menu(); // Return to menu after scan
            // ScanConnectedNetworkManager scanManager = new ScanConnectedNetworkManager();
            // scanManager.ScanConnectedNetwork(); // Call instance method
        }
        
        if (currentSelection == "2") // FETCH AUTH
        {
            // networkScanner = new NetworkScanner(); // Initialize the instance
            networkScanner.FetchActiveBSSID();
            Menu(); // Return to menu after scan
            // ScanConnectedNetworkManager scanManager = new ScanConnectedNetworkManager();
            // scanManager.ScanConnectedNetwork(); // Call instance method
        }
        
        if (currentSelection == "3") // FETCH AUTH
        {
            // networkScanner = new NetworkScanner(); // Initialize the instance
            networkScanner.FetchActiveEncryption();
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