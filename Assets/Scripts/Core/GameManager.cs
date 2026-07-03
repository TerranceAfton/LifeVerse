using UnityEngine;
using LifeVerse.Core.Events;

namespace LifeVerse.Core
{
    /// <summary>
    /// Central application manager.
    /// </summary>
    public static class GameManager
    {
        public static bool IsInitialized { get; private set; }

        public static ApplicationState CurrentState { get; private set; }
            = ApplicationState.Unknown;

        public static void Initialize()
        {
            if (IsInitialized)
            {
                Debug.LogWarning("GameManager already initialized.");
                return;
            }

            Debug.Log("Initializing GameManager...");

            IsInitialized = true;

            Debug.Log("GameManager Initialized");
        }

        public static void ChangeState(ApplicationState newState)
        {
            if (CurrentState == newState)
                return;

            ApplicationState previous = CurrentState;

            CurrentState = newState;

            Debug.Log(
                $"Application State Changed: {previous} → {CurrentState}");

            EventBus.Publish(
                new ApplicationStateChangedEvent(
                    previous,
                    CurrentState));
        }

        public static bool IsGameplay =>
            CurrentState == ApplicationState.Gameplay;

        public static bool IsPaused =>
            CurrentState == ApplicationState.Paused;
    }
}