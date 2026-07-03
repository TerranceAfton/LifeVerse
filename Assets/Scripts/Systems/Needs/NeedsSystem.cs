using LifeVerse.Characters;
using LifeVerse.Characters.Components.Needs;

namespace LifeVerse.Simulation.Systems.Needs
{
    /// <summary>
    /// Updates all character needs.
    /// </summary>
    public class NeedsSystem : ISimulationSystem
    {
        private readonly CharacterManager _characterManager;

        private readonly NeedsSettings _settings;

        public NeedsSystem(
            CharacterManager characterManager)
        {
            _characterManager = characterManager;

            _settings = new NeedsSettings();
        }

        public void Initialize()
        {
        }

        public void Shutdown()
        {
        }

        public void Tick(float deltaTime)
        {
            if (!_settings.Enabled)
                return;

            foreach (Character character in _characterManager.Characters)
            {
                character.Needs.Tick(
                    deltaTime *
                    _settings.GlobalDecayMultiplier);

                CheckCriticalNeeds(character);
            }
        }

        private void CheckCriticalNeeds(Character character)
        {
            foreach (Need need in character.Needs.All.Values)
            {
                if (need.IsCritical)
                {
                    // Future:
                    // Mood penalties
                    // AI priority changes
                    // Notifications
                }
            }
        }
    }
}