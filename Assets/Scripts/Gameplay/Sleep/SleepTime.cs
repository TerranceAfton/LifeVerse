using System;

namespace LifeVerse.Gameplay.Sleep
{
    /// <summary>
    /// Represents a wake-up time selected by the player.
    /// </summary>
    [Serializable]
    public struct SleepTime
    {
        public int Hour;

        public int Minute;

        public SleepTime(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public override string ToString()
        {
            return $"{Hour:D2}:{Minute:D2}";
        }
    }
}