namespace Things4Trip
{
    public class SocialEvent : Event
    {
        public SocialEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.Add(" ");
        }
    }
}

