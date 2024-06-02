using System.Globalization;

namespace Things4Trip
{
    class Event
    {
        public string TravelerName { get; set; }
        public string EventName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public Event(string travelerName, string eventName, DateTime startDateTime, DateTime endDateTime)
        {
            TravelerName = travelerName;
            EventName = eventName;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public override string ToString()
        {
            return $"Traveler: {TravelerName}\tEvent: {EventName}\nWhen: {StartDateTime}\t{EndDateTime}";

        }
    }
    class ActivityType
    {
        public string Name { get; private set; }
        public ActivityType(string name)
        {
            Name = name;
        }
    }


    class ItemToPack
    {
        public string Name { get; set; }

        public ItemToPack(string name)
        {
            Name = name;
        }
    }

    class ItemList
    {
        public string Name { get; set; }
        public List<ItemToPack> Items { get; set; } = new List<ItemToPack>();
    }

    enum ActivityLength { Day, Weekend, MoreDays }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Things4Trip01");

            //MyEventSpecification myEventSpecification = new MyEventSpecification(traveventName, );


            string travelerName = ReadString("your name: ");
            Console.Write($"Welcome {travelerName} to program Things4Trip. ");

            string eventName = ReadString("your event name: ");

            DateTime startDateTime = ReadDateTime("start day/time of your event: ");
            DateTime endDateTime = ReadDateTime("end day/time of your event: ");

            Console.WriteLine($"You even {eventName} starts {startDateTime} and ends {endDateTime}");

            static string ReadString(string message)
            {
                Console.WriteLine("Enter " + message);
                return Console.ReadLine();
            }

            static DateTime ReadDateTime(string message)
            {
                Console.WriteLine($"Enter" + message);
                bool isDate = DateTime.TryParse(Console.ReadLine(),out DateTime result);
                while (isDate == false)
                { 
                    Console.WriteLine("Incorrect date, please enter valid date/time: ");
                    isDate = DateTime.TryParse(Console.ReadLine(), out result);
                }
                return result;

            }
        }
    }
}

