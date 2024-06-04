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
            string[] itemsForAllEvents = new string[] { "keys", "phone", "money", "ID Card" };
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
            Items.Add("ski");
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
            Items.Add("bike");
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
            Items.Add("bathingSuit");
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
            Items.Add("hikingGear");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Things4Trip01");


            //string travelerName = ReadString("your name: ");
            //Console.Write($"Welcome {travelerName} to program Things4Trip. ");

            //string eventName = ReadString("your event name: ");

            //DateTime startDateTime = ReadDateTime("start day/time of your event (mm/dd/yyy): ");
            //DateTime endDateTime = ReadDateTime("end day/time of your event (mm/dd/yyy): ");

            SkiEvent firstEvent = new SkiEvent("Lenka", "Snezka", new DateTime(2024, 6, 2), DateTime.Today, "15", true);

            HikingEvent secondEvent = new HikingEvent("Lenka", "prochazka", DateTime.Today, DateTime.Today, "1", false);

            //Console.WriteLine($"Your event {eventName} starts {startDateTime} and ends {endDateTime}.");


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

