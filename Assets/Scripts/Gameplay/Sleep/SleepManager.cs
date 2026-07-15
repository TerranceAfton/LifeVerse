using UnityEngine;

using LifeVerse.Characters;

namespace LifeVerse.Gameplay.Sleep
{
    /// <summary>
    /// Coordinates the Sleep System.
    /// </summary>
    public class SleepManager : MonoBehaviour
    {
        private CharacterInteractionController _interactionController;

        private SleepSettings _settings;

        public bool IsSleeping { get; private set; }

        public SleepTime WakeUpTime { get; private set; }

        private void Awake()
        {
            _interactionController =
                FindFirstObjectByType<CharacterInteractionController>();

            _settings = new SleepSettings();

            WakeUpTime = _settings.DefaultWakeTime;
        }

        /// <summary>
        /// Starts sleeping until the selected time.
        /// </summary>
        public void StartSleep(SleepTime wakeUpTime)
        {
            if (IsSleeping)
                return;

            IsSleeping = true;

            WakeUpTime = wakeUpTime;

            Debug.Log($"Sleeping until {WakeUpTime}");
        }

        /// <summary>
        /// Wakes the player.
        /// </summary>
        public void WakeUp()
        {
            if (!IsSleeping)
                return;

            IsSleeping = false;

            _interactionController?.WakeUp();

            Debug.Log("Sleep complete.");
        }
    }
}