using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Things4Trip
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Things4Trip01");


            string userName = ReadString("your name: ");
            Console.Write($"Welcome {userName} to program Things4Trip. ");
            Console.WriteLine();

            string eventName = ReadString("your event name: ");

            DateTime startDateTime = ReadDateTime("start day/time of your event (mm/dd/yy): ");
            DateTime endDateTime = ReadDateTime("end day/time of your event (mm/dd/yy): ");

            while (startDateTime > endDateTime || startDateTime < DateTime.Today)
            {
                Console.WriteLine("You have entered invalid start and/or end date.");
                startDateTime = ReadDateTime("start day/time of your event (mm/dd/yy): ");
                endDateTime = ReadDateTime("end day/time of your event (mm/dd/yy): ");
            }


            //string duration = ReadString("duration time in days: "); to be added later

            string isItAbroad = ReadString("'yes' for event abroad and 'no' for domestic event.  ");
            bool isAbroad = isItAbroad.ToLower() == "yes" ? true : false;


            Console.WriteLine("Enter the number of chosen event: 1.Hiking ,2. Cycling, 3. Fitness/other sport, 4. Social, 5. Ski, 6. To Sea. ");

            var input = Convert.ToInt32(Console.ReadLine());
            while (!(input > 0 && input <= 6))
            {
                Console.WriteLine("Enter valid option (select number 1-6)");
                input = Convert.ToInt32(Console.ReadLine());
            }

            Console.Clear();

            Console.WriteLine($"Your event {eventName} starts {startDateTime} and ends {endDateTime}.");

            Event newEvent = null;
            switch (input)
            {
                case 1:
                    newEvent = new HikingEvent(userName, eventName, startDateTime, endDateTime, isAbroad);
                    break;
                case 2:
                    newEvent = new CyclingEvent(userName, eventName, startDateTime, endDateTime, isAbroad);
                    break;
                case 3:
                    newEvent = new FitnessEvent(userName, eventName, startDateTime, endDateTime, isAbroad);
                    break;
                case 4:
                    newEvent = new SocialEvent(userName, eventName, startDateTime, endDateTime, isAbroad);
                    break;
                case 5:
                    newEvent = new SkiEvent(userName, eventName, startDateTime, endDateTime, isAbroad);
                    break;
                case 6:
                    newEvent = new ToSeaEvent(userName, eventName, startDateTime, endDateTime, isAbroad);
                    break;
                default:
                    { Console.WriteLine("Invalid option, please choose number from 1 to 6."); }
                    break;


            }
            Console.WriteLine("For your event you have the following items on the Item List: ");

            foreach (var item in newEvent.Items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var itemManager = new ItemManager(newEvent);

            itemManager.PrintMenuOptions();

            //Console.WriteLine("To add item to the list enter 'A', remove 'R', 'S' for safe,  'X' for exit .");
            //string action = Console.ReadLine();

            //if (action == "A")
            //{
            //    while (true)
            //    {
            //        Console.Write("Enter new item: ");
            //        var newItem = (Console.ReadLine());
            //        if (string.IsNullOrWhiteSpace(newItem))
            //            break;
            //        newEvent.Items.Add(newItem);

            //    }
            //}
            //else if (action == "R")
            //{
            //    while (true)
            //    {
            //        Console.Write("Enter item to remove: ");
            //        newEvent.Items.Add(Console.ReadLine());
            //    }

            //}
            //else if (action == "C")
            //{

            //}
            //else if ()
            //{ 

            //}

            //else
            //{
            //    Console.WriteLine("Incorrect input.");
            //}

            Console.WriteLine("Goodbye!");

            Console.ReadLine();

        }

        

        //bool tryParse = int.TryParse(Console.ReadLine(), out int menuOption);

        //if (tryParse)
        //{
        //    if (menuOption == 1)
        //    {
        //        PrintAll();
        //    }
        //    else if (menuOption == 2)
        //    {
        //        AddItem();
        //    }
        //   
        //    else if (menuOption == 4)
        //    {
        //        RemoveItem();
        //    }

        //    if (menuOption >= 1 && menuOption <= menuOptions.Length - 1)
        //    {
        //        Menu();
        //    }
        //}
        //else
        //{
        //    OutputMessage("Incorrect menu choice.");
        //    Menu();
        //}

        static string ReadString(string message)
        {
            Console.WriteLine("Enter " + message);
            return Console.ReadLine();
        }

        static DateTime ReadDateTime(string message)
        {
            Console.WriteLine($"Enter " + message);
            bool isDate = DateTime.TryParse(Console.ReadLine(), out DateTime result);
            while (isDate == false)
            {
                Console.WriteLine("Incorrect date, please enter valid date/time: ");
                isDate = DateTime.TryParse(Console.ReadLine(), out result);
            }
            return result;

        }
    }
}

