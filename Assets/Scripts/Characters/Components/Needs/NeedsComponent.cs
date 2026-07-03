using System.Collections.Generic;

namespace LifeVerse.Characters.Components.Needs
{
    /// <summary>
    /// Stores all of a character's needs.
    /// </summary>
    public class NeedsComponent
    {
        // Individual needs for easy access.
        public Need Hunger { get; }

        public Need Energy { get; }

        public Need Hygiene { get; }

        public Need Bladder { get; }

        public Need Fun { get; }

        public Need Social { get; }

        public Need Comfort { get; }

        public Need Environment { get; }

        // Internal lookup table.
        private readonly Dictionary<NeedType, Need> _needs;

        /// <summary>
        /// Read-only collection of all needs.
        /// </summary>
        public IReadOnlyDictionary<NeedType, Need> All => _needs;

        public NeedsComponent()
        {
            Hunger = new Need(NeedType.Hunger, 0.30f);
            Energy = new Need(NeedType.Energy, 0.20f);
            Hygiene = new Need(NeedType.Hygiene, 0.15f);
            Bladder = new Need(NeedType.Bladder, 0.40f);
            Fun = new Need(NeedType.Fun, 0.18f);
            Social = new Need(NeedType.Social, 0.12f);
            Comfort = new Need(NeedType.Comfort, 0.10f);
            Environment = new Need(NeedType.Environment, 0.08f);

            _needs = new Dictionary<NeedType, Need>
            {
                { NeedType.Hunger, Hunger },
                { NeedType.Energy, Energy },
                { NeedType.Hygiene, Hygiene },
                { NeedType.Bladder, Bladder },
                { NeedType.Fun, Fun },
                { NeedType.Social, Social },
                { NeedType.Comfort, Comfort },
                { NeedType.Environment, Environment }
            };
        }

        public Need Get(NeedType type)
        {
            return _needs[type];
        }

        public float GetValue(NeedType type)
        {
            return _needs[type].Value;
        }

        public void Increase(NeedType type, float amount)
        {
            _needs[type].Increase(amount);
        }

        public void Decrease(NeedType type, float amount)
        {
            _needs[type].Decrease(amount);
        }

        public void Tick(float deltaTime)
        {
            foreach (Need need in _needs.Values)
            {
                need.Tick(deltaTime);
            }
        }
    }
}