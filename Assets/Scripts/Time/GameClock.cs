namespace LifeVerse.Time
{
    public class GameClock
    {
        public int Hour { get; private set; } = 8;

        public int Minute { get; private set; }

        public int Second { get; private set; }

        public bool IsMidnight =>
            Hour == 0 &&
            Minute == 0 &&
            Second == 0;

        public void AdvanceSeconds(int seconds)
        {
            Second += seconds;

            while (Second >= 60)
            {
                Second -= 60;
                Minute++;
            }

            while (Minute >= 60)
            {
                Minute -= 60;
                Hour++;
            }

            while (Hour >= 24)
            {
                Hour -= 24;
            }
        }

        public override string ToString()
        {
            return $"{Hour:00}:{Minute:00}:{Second:00}";
        }
    }
}