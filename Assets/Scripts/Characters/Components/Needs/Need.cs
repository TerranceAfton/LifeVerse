using UnityEngine;

namespace LifeVerse.Characters.Components.Needs
{
    /// <summary>
    /// Represents one need.
    /// </summary>
    public class Need
    {
        public NeedType Type { get; }

        public float Value { get; private set; }

        public float DecayRate { get; set; }

        public Need(
            NeedType type,
            float decayRate)
        {
            Type = type;

            Value = NeedConstants.DefaultValue;

            DecayRate = decayRate;
        }

        public void Increase(float amount)
        {
            Value = Mathf.Clamp(
                Value + amount,
                NeedConstants.MinValue,
                NeedConstants.MaxValue);
        }

        public void Decrease(float amount)
        {
            Value = Mathf.Clamp(
                Value - amount,
                NeedConstants.MinValue,
                NeedConstants.MaxValue);
        }

        public void Tick(float deltaTime)
        {
            Decrease(DecayRate * deltaTime);
        }

        public bool IsLow => Value <= 30f;

        public bool IsCritical => Value <= 15f;

        public bool IsFull => Value >= 95f;
    }
}