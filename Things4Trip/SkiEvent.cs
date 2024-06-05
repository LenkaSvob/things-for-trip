namespace Things4Trip
{
    public class SkiEvent : Event
    {
        public SkiEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime,  isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.AddRange(new string[] { "helmet", "poles", "skis" });
        }
    }
}

