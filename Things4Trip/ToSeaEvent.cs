namespace Things4Trip
{
    public class ToSeaEvent : Event
    {
        public ToSeaEvent(string userName, string eventName, DateTime startDateTime, DateTime endDateTime, bool isAbroad)
            : base(userName, eventName, startDateTime, endDateTime, isAbroad)
        {
        }

        public override void AddDefaultItems()
        {
            Items.Add("bathing suit");
            Items.Add("sunglasses");
        }
    }
}

