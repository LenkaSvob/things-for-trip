namespace Things4Trip
{
    public class CyclingEvent : Event
    {
        public CyclingEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.AddRange(new string[] { "helmet", "bike" });
        }
    }
}

