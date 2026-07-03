namespace LifeVerse.Characters.Components.Needs
{
    public readonly struct NeedChangedEvent
    {
        public readonly NeedType Need;

        public readonly float Value;

        public NeedChangedEvent(
            NeedType need,
            float value)
        {
            Need = need;
            Value = value;
        }
    }

    public readonly struct NeedCriticalEvent
    {
        public readonly NeedType Need;

        public NeedCriticalEvent(NeedType need)
        {
            Need = need;
        }
    }
}