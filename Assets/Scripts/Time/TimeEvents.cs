namespace LifeVerse.Time
{
    public readonly struct HourChangedEvent
    {
        public readonly int Hour;

        public HourChangedEvent(int hour)
        {
            Hour = hour;
        }
    }

    public readonly struct DayChangedEvent
    {
    }
}