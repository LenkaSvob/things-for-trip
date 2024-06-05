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

            DateTime startDateTime = ReadDateTime("start day/time of your event (mm/dd/yyy): ");
            DateTime endDateTime = ReadDateTime("end day/time of your event (mm/dd/yyy): ");

            while (startDateTime > endDateTime)
            {
                Console.WriteLine("End date must be higher than Start date. Enter again.");
                startDateTime = ReadDateTime("start day/time of your event (mm/dd/yyy): ");
                endDateTime = ReadDateTime("end day/time of your event (mm/dd/yyy): ");
            }

            Console.WriteLine($"Your event {eventName} starts {startDateTime} and ends {endDateTime}.");

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





            //        Console.WriteLine("Current items in the list: ");

            //        Event.
            //                    var Items = new List<string>();
            //string input = Console.ReadLine();
            //        while (true)
            //        {
            //            if(Items.Contains(input))
            //            Console.WriteLine("Enter item to the list or hit Enter to exit Item list.");
            //        }


        }

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

