using UnityEngine;

using LifeVerse.Time;

namespace LifeVerse.Gameplay.Sleep
{
    /// <summary>
    /// Watches the in-game clock and wakes the player
    /// when the selected wake-up time is reached.
    /// </summary>
    public class WakeUpScheduler : MonoBehaviour
    {
        private SleepManager _sleepManager;

        private TimeService _timeService;

        private void Awake()
        {
            _sleepManager =
                FindFirstObjectByType<SleepManager>();
        }

        private void Start()
        {
            _timeService =
                Core.ServiceRegistry.Get<TimeService>();
        }

        private void Update()
        {
            if (_sleepManager == null)
                return;

            if (!_sleepManager.IsSleeping)
                return;

            GameClock clock = _timeService.Clock;

            SleepTime wakeTime =
                _sleepManager.WakeUpTime;

            if (clock.Hour == wakeTime.Hour &&
                clock.Minute >= wakeTime.Minute)
            {
                _sleepManager.WakeUp();
            }
        }
    }
}