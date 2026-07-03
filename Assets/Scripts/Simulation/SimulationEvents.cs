namespace LifeVerse.Simulation
{
    public readonly struct SimulationStartedEvent
    {
    }

    public readonly struct SimulationStoppedEvent
    {
    }

    public readonly struct SimulationTickEvent
    {
        public readonly float DeltaTime;

        public SimulationTickEvent(float deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }
}