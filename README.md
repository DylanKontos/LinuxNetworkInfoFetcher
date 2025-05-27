Welcome to the Linux (Debian 12) Network Info Fetcher.

This program will:

- Fetch public authentication/encryption types from active (currently connected) network using ncmli.

This program is written in C# and when built, creates a natively executable filetype for Linux (run like so: ./NetworkFetcher). 
So no .dll file and no requirement for dotnet installation.

Reminder this 'trade off' creates a system specific program (and is larger), as opposed to a cross platform program that has dotnet dependency.

Published on Linux Debian 12 using using:
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true -o publish

