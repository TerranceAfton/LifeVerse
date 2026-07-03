namespace LifeVerse.Core.Events
{
    /// <summary>
    /// Fired whenever the application changes state.
    /// </summary>
    public readonly struct ApplicationStateChangedEvent
    {
        public ApplicationState PreviousState { get; }

        public ApplicationState CurrentState { get; }

        public ApplicationStateChangedEvent(
            ApplicationState previousState,
            ApplicationState currentState)
        {
            PreviousState = previousState;
            CurrentState = currentState;
        }
    }
}