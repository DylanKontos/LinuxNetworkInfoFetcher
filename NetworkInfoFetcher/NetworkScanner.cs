using System;
using System.Diagnostics; // Needed to launch a process

class NetworkScanner
{
    public string? activeNetwork { get; private set; }
    public string? BSSID { get; private set; }



    private static NetworkScanner? _instance;
    public static NetworkScanner Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new NetworkScanner();
            }
            return _instance;
        }
    }
    private NetworkScanner() { } // Private constructor to prevent external instantiation
    
    
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
            
            
            // Ensures that the whole word is taken, not just the first word (if there are spaces)
            string[] lines = result.Split('\n');
            if (lines.Length > 1)
            {
                activeNetwork = string.Join(" ", lines[1].Split().TakeWhile(word => !word.Contains("-")));  
            }


            // activeNetwork = result.Split('\n')[0].Split(' ')[0].Trim();
            Console.WriteLine("activeNetwork: " + activeNetwork);
            // Console.WriteLine("Active Network Connection(s):\n" + result.Trim());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error scanning network: " + ex.Message);
        }
    }
    
    
    public void FetchActiveBSSID()
    {
        try 
        {         
            Console.WriteLine("Scanning BSSID......");
            
            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash"; // using linux binaries and bas
            
            // ncmli -t = Terse mode (remove unnecessary space) // -f = Filter (in use and bssid) 
            // IN-USE gets marked wtih an * // Then use grep '^*' to find the IN-USE!!!
            process.StartInfo.Arguments = "-c \"nmcli -t -f IN-USE,BSSID device wifi list | grep '^*'\""; // simple nmcli bash command
            
            
            process.StartInfo.RedirectStandardOutput = true; // makes readable by this program
            process.StartInfo.UseShellExecute = false; // runs in THIS PROCESS not in an external terminal
            process.StartInfo.CreateNoWindow = true; 

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            BSSID = result.Trim().Split('*')[1].Trim().Replace("\\", "").TrimStart(':');

            // BSSID = result.Trim().Split('*')[1].Trim();
            
            Console.WriteLine("Active Network BSSID\n" + result.Trim());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error scanning network: " + ex.Message);
        }
    }
    
    public void FetchActiveEncryption()
    {
        try 
        {         
            Console.WriteLine("Scanning Encryption for: " + activeNetwork);
            Console.WriteLine("On BSSID: " + BSSID);
            Console.WriteLine("Scanning Encryption......");
            
            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash"; // using linux binaries
            
            // NF = last column which will be the encryption type
            process.StartInfo.Arguments = "-c \"nmcli device wifi list | grep '" + BSSID + "' | awk '{print $(NF-1), $(NF)}'\n\"";

            //process.StartInfo.Arguments = "-c \"nmcli device wifi list | grep '" + BSSID + "' | awk '{print $4}'"; 
            
            
            process.StartInfo.RedirectStandardOutput = true; // makes readable by this program
            process.StartInfo.UseShellExecute = false; // runs in THIS PROCESS not in an external terminal
            process.StartInfo.CreateNoWindow = true; 

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine("Encryption for Active Network \n" + result.Trim());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error scanning network: " + ex.Message);
        }
    }
}