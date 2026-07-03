namespace LifeVerse.Simulation
{
    /// <summary>
    /// Base interface for every gameplay simulation system.
    /// </summary>
    public interface ISimulationSystem
    {
        /// <summary>
        /// Called once when the simulation starts.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Called every simulation tick.
        /// </summary>
        void Tick(float deltaTime);

        /// <summary>
        /// Called when the simulation shuts down.
        /// </summary>
        void Shutdown();
    }
}