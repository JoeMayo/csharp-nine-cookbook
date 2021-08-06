using System;

Console.WriteLine("Address Info:\n");

Console.Write("Street: ");
string street = Console.ReadLine();

Console.Write("City: ");
string city = Console.ReadLine();

Console.Write("State: ");
string state = Console.ReadLine();

Console.Write("Zip: ");
string zip = Console.ReadLine();

Console.WriteLine($@"
    Your address is:

    {street}
    {city}, {state} {zip}");