using System;
using System.Collections.Generic;
using Kodanalys.Models;

namespace Kodanalys
{
    class Program
    {
        static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Lägg till användare");
                Console.WriteLine("2. Visa alla användare");
                Console.WriteLine("3. Ta bort användare");
                Console.WriteLine("4. Sök användare");
                Console.WriteLine("5. Avsluta");

                string menuChoice = Console.ReadLine();

                if (menuChoice == "1")
                {
                    Console.Write("Ange namn: ");
                    string userName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(userName))
                    {
                        users.Add(new User { Name = userName });
                        Console.WriteLine($"Användaren '{userName}' lades till.");
                    }
                    else
                    {
                        Console.WriteLine("Namnet får inte vara tomt.");
                    }
                }
                else if (menuChoice == "2")
                {
                    Console.WriteLine("Användare:");
                    foreach (User user in users)
                    {
                        Console.WriteLine(user.Name);
                    }
                }
                else if (menuChoice == "3")
                {
                    Console.Write("Ange namn att ta bort: ");
                    string nameToRemove = Console.ReadLine();
                    User foundUser = users.Find(u => u.Name == nameToRemove);
                    if (foundUser != null)
                    {
                        users.Remove(foundUser);
                        Console.WriteLine($"Användaren '{nameToRemove}' togs bort.");
                    }
                    else
                    {
                        Console.WriteLine("Användaren hittades inte.");
                    }
                }
                else if (menuChoice == "4")
                {
                    Console.Write("Ange namn att söka: ");
                    string searchName = Console.ReadLine();
                    bool exists = users.Exists(u => u.Name == searchName);
                    if (exists)
                    {
                        Console.WriteLine("Användaren finns i listan.");
                    }
                    else
                    {
                        Console.WriteLine("Användaren hittades inte.");
                    }
                }
                else if (menuChoice == "5")
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                }

                Console.WriteLine();
            }
        }
    }
}
