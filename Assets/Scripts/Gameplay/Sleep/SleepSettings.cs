namespace LifeVerse.Gameplay.Sleep
{
    /// <summary>
    /// Global settings for the Sleep System.
    /// </summary>
    public class SleepSettings
    {
        /// <summary>
        /// Default wake-up time.
        /// </summary>
        public SleepTime DefaultWakeTime =
            new SleepTime(7, 0);

        /// <summary>
        /// Maximum number of hours a character can sleep.
        /// </summary>
        public int MaxSleepHours = 12;

        /// <summary>
        /// Simulation speed while sleeping.
        /// </summary>
        public float SleepSpeedMultiplier = 10f;

        /// <summary>
        /// Restore Energy while sleeping.
        /// </summary>
        public bool RecoverEnergy = true;

        /// <summary>
        /// Restore Comfort while sleeping.
        /// (Will be implemented later.)
        /// </summary>
        public bool RecoverComfort = false;
    }
}