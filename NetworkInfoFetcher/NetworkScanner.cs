using System;
using System.Diagnostics; // Needed to launch a process

class NetworkScanner
{
    
    public string? activeNetwork { get; private set; }

    
    public void ScanConnectedNetwork()
    {
        try 
        {         
            Console.WriteLine("Scanning......");

            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash"; // using linux binaries and bas
            process.StartInfo.Arguments = "-c \"nmcli con show --active\""; // simple nmcli bash command
            process.StartInfo.RedirectStandardOutput = true; // makes readable by this program
            process.StartInfo.UseShellExecute = false; // runs in THIS PROCESS not in an external terminal
            process.StartInfo.CreateNoWindow = true; 

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            
            activeNetwork = result.Trim();
            
            // TODO ASSIGN THIS AND FEED INTO AUTH SCANNER
            // Console.WriteLine(activeNetwork);

            Console.WriteLine("Active Network Connection(s):\n" + result.Trim());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error scanning network: " + ex.Message);
        }
    }
    
    
    public void FetchActiveConnectionAuthentication()
    {
        try 
        {         
            Console.WriteLine("Scanning......");

            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash"; // using linux binaries and bas
            process.StartInfo.Arguments = "-c \"nmcli con show --active\""; // simple nmcli bash command
            process.StartInfo.RedirectStandardOutput = true; // makes readable by this program
            process.StartInfo.UseShellExecute = false; // runs in THIS PROCESS not in an external terminal
            process.StartInfo.CreateNoWindow = true; 

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine("Active Network Connection(s):\n" + result.Trim());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error scanning network: " + ex.Message);
        }
    }
}