﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things4Trip
{
    internal class ItemManager
    {
        public Event Event { get; }
        public ItemManager(Event @event)
        {
            Event = @event;
        }

        public void PrintMenuOptions()
        {
            while (true)
            {
                string[] menuOptions = new string[]
                    {
                    "Print all items",
                    "Add item",
                    "Remove item",
                    "Save to file",
                    "Exit",
                    };

                Console.Clear();

                for (int i = 0; i < menuOptions.Length; i++)
                {                    
                    Console.WriteLine(i + 1 + ". " + menuOptions[i]);
                }

                int menuOption = ReadInt(" your menu option: ");

                if (menuOption == 1)
                {
                    PrintAllItems();
                }
                else if (menuOption == 2)
                {
                    AddItems();
                }
                else if (menuOption == 3)
                {
                    RemoveItems();
                }
                else if(menuOption == 4)
                {
                    SaveToFile();
                }
                else if (menuOption == 5)
                {
                    Exit();
                    break;
                }
            }
        }

        private void SaveToFile()
        {
            string fileName = Event.EventName + ".txt";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Event.EventName);
            sb.AppendLine($"Starts: {Event.StartDateTime}, ends: {Event.EndDateTime}");
            sb.AppendLine();

            foreach(string item in Event.Items)
            {
                sb.AppendLine($"[ ] {item}");
            }
            sb.AppendLine();
            sb.AppendLine("Generated by Things4Trip 1.0. (c) Lenka Svobodová 2024.");
            File.WriteAllText(fileName, sb.ToString());
            Console.WriteLine($"The file was saved: {fileName}. You can open it and print it. Press enter to continue...");
            Console.ReadLine();
        }

        public void PrintAllItems()
        {

            foreach (var item in Event.Items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        public void AddItems()
        {
            Console.Write("Item to add: ");
            string newItem = Console.ReadLine();
            Event.Items.Add(newItem);

        }
        public void RemoveItems()
        {
            Console.Write("Item to remove: ");
            string itemToTrash = Console.ReadLine();
            Event.Items.Remove(itemToTrash);
        }
        public void Exit()
        {
            Console.WriteLine("Exiting. Goodbye");
        }

        private int ReadInt(string message)
        {
            Console.WriteLine($"Enter " + message);
            bool isNumber = int.TryParse(Console.ReadLine(), out int result);
            while (isNumber == false)
            {
                Console.WriteLine("Incorrect option choice.");
                isNumber = int.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }

    }
}