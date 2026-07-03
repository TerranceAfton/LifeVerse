using UnityEngine;
using LifeVerse.Core.Services;

namespace LifeVerse.Core.Logging
{
    /// <summary>
    /// Central logging service.
    /// </summary>
    public class LoggingManager : IGameService
    {
        public void Initialize()
        {
            Log("LoggingManager Initialized");
        }

        public void Shutdown()
        {
            Log("LoggingManager Shutdown");
        }

        public void Log(string message)
        {
            Debug.Log($"[LifeVerse] {message}");
        }

        public void LogWarning(string message)
        {
            Debug.LogWarning($"[LifeVerse] {message}");
        }

        public void LogError(string message)
        {
            Debug.LogError($"[LifeVerse] {message}");
        }

        public void Log(string message, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Info:
                    Log(message);
                    break;

                case LogLevel.Warning:
                    LogWarning(message);
                    break;

                case LogLevel.Error:
                    LogError(message);
                    break;
            }
        }
    }
}