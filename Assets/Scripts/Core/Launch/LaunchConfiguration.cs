using UnityEngine;

namespace LifeVerse.Core.Launch
{
    public class LaunchConfiguration : MonoBehaviour
    {
        [Header("Development")]

        [SerializeField]
        private LaunchScene launchScene = LaunchScene.MainMenu;

        public LaunchScene LaunchScene => launchScene;
    }
}