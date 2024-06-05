namespace Things4Trip
{
    public class HikingEvent : Event
    {
        public HikingEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.Add("hiking gear");
        }
    }
}

