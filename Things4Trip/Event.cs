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

        public Event(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, bool isAbroad)
        {
            UserName = userName;
            EventName = eventName;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            //Duration = duration;
            IsAbroad = isAbroad;
            if ((EndDateTime - StartDateTime).TotalDays > 1)
            {
                Items.Add("basic hygiene items (toothbrush, pyjamas ...)");
            }
            string[] itemsForAllEvents = new string[] { "keys", "phone", "money", "ID Card", "glasses" };
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
}

