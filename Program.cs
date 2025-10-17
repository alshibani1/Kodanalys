using System;
using System.Collections.Generic;
using System.Linq;
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
                ShowMenu();
                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        ShowUsers();
                        break;
                    case "3":
                        RemoveUser();
                        break;
                    case "4":
                        SearchUser();
                        break;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("Programmet avslutas...");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Lägg till användare");
            Console.WriteLine("2. Visa alla användare");
            Console.WriteLine("3. Ta bort användare");
            Console.WriteLine("4. Sök användare");
            Console.WriteLine("5. Avsluta");
        }

        static void AddUser()
        {
            Console.Write("Ange namn: ");
            string userName = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Namnet får inte vara tomt.");
                return;
            }

            if (users.Any(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Användaren finns redan.");
                return;
            }

            users.Add(new User { Name = userName });
            Console.WriteLine($"Användaren '{userName}' lades till.");
        }

        static void ShowUsers()
        {
            if (!users.Any())
            {
                Console.WriteLine("Inga användare finns i listan.");
                return;
            }

            Console.WriteLine("Användare:");
            foreach (User user in users)
            {
                Console.WriteLine(user.Name);
            }
        }

        static void RemoveUser()
        {
            Console.Write("Ange namn att ta bort: ");
            string nameToRemove = Console.ReadLine()?.Trim();

            User foundUser = users.FirstOrDefault(u => u.Name.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase));
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

        static void SearchUser()
        {
            Console.Write("Ange namn att söka: ");
            string searchName = Console.ReadLine()?.Trim();

            bool exists = users.Any(u => u.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            if (exists)
                Console.WriteLine($"Användaren '{searchName}' finns i listan.");
            else
                Console.WriteLine("Användaren hittades inte.");
        }
    }
}
