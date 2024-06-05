namespace Things4Trip
{
    public class FitnessEvent : Event
    {
        public FitnessEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.Add("fitness gear");
        }
    }
}

