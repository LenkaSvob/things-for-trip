using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Things4Trip
{
    public abstract class Event
    {
        public string UserName { get; private set; }
        public string EventName { get; private set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Duration { get; set; }
        public bool IsAbroad { get; set; }

        public Event(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, string duration, bool isAbroad)
        {
            UserName = userName;
            EventName = eventName;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Duration = duration;
            IsAbroad = isAbroad;
            string[] itemsForAllEvents = new string[] { "keys", "phone", "money", "ID Card", "basic hygiene items", "glasses" };
            Items.AddRange(itemsForAllEvents);
            AddDefaultItems();
            if (isAbroad)
            {
                string[] itemsForAbroadEvent = new string[] { "passport", "travel insurance", "vaccinations", "foreign currency" };
                Items.AddRange(itemsForAbroadEvent);
            }

        }

        public abstract void AddDefaultItems();
        public List<string> Items { get; set; } = new List<string>();



        public override string ToString()
        {
            return $"Traveler: {UserName}\tEvent: {EventName}\nWhen: {StartDateTime}\t{EndDateTime}\n{Duration}\t{IsAbroad}";
        }
    }

    public class SkiEvent : Event
    {
        public SkiEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, string duration, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, duration, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.AddRange(new string[] { "helmet", "poles", "skis" });
        }
    }
    public class CyclingEvent : Event
    {
        public CyclingEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, string duration, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, duration, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.AddRange(new string[] { "helmet", "bike" });
        }
    }
    public class ToSeaEvent : Event
    {
        public ToSeaEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, string duration, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, duration, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.Add("bathing suit");
            Items.Add("sunglasses");
        }
    }

    public class HikingEvent : Event
    {
        public HikingEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, string duration, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, duration, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.Add("hiking gear");
        }
    }

    public class SocialEvent : Event
    {
        public SocialEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, string duration, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, duration, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.Add(" ");
        }
    }
    public class FitnessEvent : Event
    {
        public FitnessEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, string duration, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, duration, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.Add("fitness gear");
        }
    }

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

            string duration = ReadString("duration time in days: ");

            string isItAbroad = ReadString("'yes' for event abroad and 'no' for domestic event.  ");
            bool isAbroad = isItAbroad.ToLower() == "yes" ? true : false;


            Console.WriteLine("Enter the number of chosen event: 1.Hiking ,2. Cycling, 3. Fitness/other sport, 4. Social, 5. Ski, 6. To Sea. ");

            var input = Convert.ToInt32(Console.ReadLine());
            Event newEvent = null;
            switch (input)
            {
                case 1:
                    newEvent = new HikingEvent(userName, eventName, startDateTime, endDateTime, duration, isAbroad);
                    break;
                case 2:
                    newEvent = new CyclingEvent(userName, eventName, startDateTime, endDateTime, duration, isAbroad);
                    break;
                case 3:
                    newEvent = new FitnessEvent(userName, eventName, startDateTime, endDateTime, duration, isAbroad);
                    break;
                case 4:
                    newEvent = new SocialEvent(userName, eventName, startDateTime, endDateTime, duration, isAbroad);
                    break;
                case 5:
                    newEvent = new SkiEvent(userName, eventName, startDateTime, endDateTime, duration, isAbroad);
                    break;
                case 6:
                    newEvent = new ToSeaEvent(userName, eventName, startDateTime, endDateTime, duration, isAbroad);
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



            //        if (!string.IsNullOrWhiteSpace(input)) 
            //        { 
            //        }


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

