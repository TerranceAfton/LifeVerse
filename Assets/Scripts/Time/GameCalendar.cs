namespace LifeVerse.Time
{
    /// <summary>
    /// Tracks the in-game calendar.
    /// </summary>
    public class GameCalendar
    {
        public int Day { get; private set; } = 1;

        public int Month { get; private set; } = 1;

        public int Year { get; private set; } = 1;

        public Season CurrentSeason => (Season)((Month - 1) / 3);

        public void AdvanceDay()
        {
            Day++;

            if (Day > 30)
            {
                Day = 1;
                Month++;

                if (Month > 12)
                {
                    Month = 1;
                    Year++;
                }
            }
        }
    }
}