using UnityEngine;
using LifeVerse.Core.Services;

namespace LifeVerse.Core.Configuration
{
    /// <summary>
    /// Stores engine configuration.
    /// </summary>
    public class ConfigurationManager : IGameService
    {
        public float MasterVolume { get; private set; } = 1f;

        public float MusicVolume { get; private set; } = 1f;

        public float SfxVolume { get; private set; } = 1f;

        public int TargetFrameRate { get; private set; } = 120;

        public bool Fullscreen { get; private set; } = true;

        public string Language { get; private set; } = "en";

        public void Initialize()
        {
            Debug.Log("ConfigurationManager Initialized");

            Application.targetFrameRate = TargetFrameRate;

            Screen.fullScreen = Fullscreen;
        }

        public void Shutdown()
        {
            Debug.Log("ConfigurationManager Shutdown");
        }

        public void SetMasterVolume(float value)
        {
            MasterVolume = Mathf.Clamp01(value);
        }

        public void SetMusicVolume(float value)
        {
            MusicVolume = Mathf.Clamp01(value);
        }

        public void SetSfxVolume(float value)
        {
            SfxVolume = Mathf.Clamp01(value);
        }

        public void SetLanguage(string language)
        {
            Language = language;
        }

        public void SetFullscreen(bool fullscreen)
        {
            Fullscreen = fullscreen;

            Screen.fullScreen = fullscreen;
        }

        public void SetTargetFrameRate(int fps)
        {
            TargetFrameRate = Mathf.Max(30, fps);

            Application.targetFrameRate = TargetFrameRate;
        }
    }
}