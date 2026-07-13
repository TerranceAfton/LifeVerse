using UnityEngine;

using LifeVerse.Core;
using LifeVerse.Core.Services;

namespace LifeVerse.Time
{
    /// <summary>
    /// Controls the progression of simulation time.
    /// </summary>
    public class TimeService :
        IGameService,
        IUpdatableService
    {
        /// <summary>
        /// One real second equals one in-game minute.
        /// Change this value later to rebalance the game.
        /// </summary>
        private const float RealSecondsPerGameMinute = 1f;

        private float _accumulator;

        private int _lastHour;

        public GameClock Clock { get; }

        public GameCalendar Calendar { get; }

        public TimeScale CurrentTimeScale { get; private set; }

        public bool IsPaused =>
            CurrentTimeScale == TimeScale.Paused;

        public TimeService()
        {
            Clock = new GameClock();

            Calendar = new GameCalendar();

            CurrentTimeScale = TimeScale.Normal;

            _lastHour = Clock.Hour;
        }

        public void Initialize()
        {
            Debug.Log("TimeService Initialized");
        }

        public void Shutdown()
        {
            Debug.Log("TimeService Shutdown");
        }

        public void Update(float deltaTime)
        {
            if (CurrentTimeScale == TimeScale.Paused)
                return;

            _accumulator += deltaTime * (int)CurrentTimeScale;

            while (_accumulator >= RealSecondsPerGameMinute)
            {
                _accumulator -= RealSecondsPerGameMinute;

                AdvanceOneGameMinute();
            }
        }

        private void AdvanceOneGameMinute()
        {
            Clock.AdvanceSeconds(60);

            if (Clock.Hour != _lastHour)
            {
                _lastHour = Clock.Hour;

                EventBus.Publish(
                    new HourChangedEvent(Clock.Hour));
            }

            if (Clock.IsMidnight)
            {
                Calendar.AdvanceDay();

                EventBus.Publish(
                    new DayChangedEvent());
            }
        }

        #region Controls

        public void Pause()
        {
            CurrentTimeScale = TimeScale.Paused;
        }

        public void Resume()
        {
            CurrentTimeScale = TimeScale.Normal;
        }

        public void SetTimeScale(TimeScale scale)
        {
            Debug.Log($"Changing Time Scale from {CurrentTimeScale} to {scale}");

            CurrentTimeScale = scale;
        }

        #endregion

        #region Utility

        public string GetTimeString()
        {
            return Clock.ToString();
        }

        public string GetDateString()
        {
            return Calendar.ToString();
        }

        #endregion
    }
}