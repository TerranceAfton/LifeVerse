namespace LifeVerse.Simulation
{
    /// <summary>
    /// Defines how often the gameplay simulation updates.
    /// </summary>
    public static class SimulationTick
    {
        /// <summary>
        /// Twenty simulation updates per second.
        /// </summary>
        public const float TickRate = 20f;

        /// <summary>
        /// Time between simulation updates.
        /// </summary>
        public const float TickInterval = 1f / TickRate;
    }
}