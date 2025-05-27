using System;

class MenuManager
{
    // string? is a nullable type. Meaning it can be null without error (add ?)
    public string? currentSelection { get; private set; }
    public string? ping { get; private set; }

    // private NetworkScanner networkScanner; // Create an instance whenever MenuManager instantiates
    private readonly NetworkScanner networkScanner = NetworkScanner.Instance; // Use Singleton instead
    // Only one networkScanner instance will exist at a time.

    public void Menu()
    {
        while (true) // infinite loop broken only by return (0 = exit)
        {
            Console.WriteLine("---------Menu----------");
            Console.WriteLine("Enter 1 to scan active network");
            Console.WriteLine("Enter 2 to fetch BSSID of active network");
            Console.WriteLine("Enter 3 to fetch encryption of active network");
            Console.WriteLine("Enter 0 to exit");

            currentSelection = Console.ReadLine();

            switch (currentSelection)
            {
                case "1": // SCAN
                    networkScanner.ScanConnectedNetwork();
                    break; // exits the loop, but method will continue so loop re-commences

                case "2": // FETCH BSSID
                    networkScanner.FetchActiveBSSID();
                    break;

                case "3": // FETCH AUTH
                    networkScanner.FetchActiveEncryption();
                    break;

                case "0": // EXIT
                    Console.WriteLine("Exiting Program...");
                    return; // exits the loop AND the method. Ends program...

                default: // Exception....
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }
}

// learning....  if statements...

// public void Menu()
// {
//     Console.WriteLine("---------Menu----------");
//     Console.WriteLine("Enter 1 to scan active network");
//     Console.WriteLine("Enter 2 to fetch BSSID of active network");
//     Console.WriteLine("Enter 3 to fetch encryption of active network");
//     Console.WriteLine("Enter 0 to exit");
//         
//     currentSelection = Console.ReadLine();
//         
//     if (currentSelection == "1") // SCAN
//     {
//         // networkScanner = new NetworkScanner(); // NO, we initialized the instance as a singelton.
//         networkScanner.ScanConnectedNetwork();
//         Menu(); // Return to menu after scan
//     }
//         
//     if (currentSelection == "2") // FETCH BSSID
//     {
//         // networkScanner = new NetworkScanner(); // NO, we initialized the instance as a singelton.
//         networkScanner.FetchActiveBSSID();
//         Menu(); // Return to menu after scan
//     }
//         
//     if (currentSelection == "3") // FETCH AUTH
//     {
//         // networkScanner = new NetworkScanner(); // NO, we initialized the instance as a singelton.
//         networkScanner.FetchActiveEncryption();
//         Menu(); // Return to menu after scan
//     }
//     else
//     {
//         Console.WriteLine("Exiting Program...");
//     }
// }
// }

