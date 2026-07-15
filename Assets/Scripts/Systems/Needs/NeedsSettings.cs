namespace LifeVerse.Simulation.Systems.Needs
{
    /// <summary>
    /// Global settings for the Needs simulation.
    /// </summary>
    public class NeedsSettings
    {
        /// <summary>
        /// Enables or disables the entire Needs system.
        /// </summary>
        public bool Enabled = true;

        /// <summary>
        /// Global multiplier applied to all need decay.
        /// </summary>
        public float GlobalDecayMultiplier = 1f;

        /// <summary>
        /// Amount of Energy restored per second while sleeping.
        /// </summary>
        public float SleepRecoveryRate = 5f;
    }
}