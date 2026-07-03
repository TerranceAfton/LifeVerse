using UnityEngine;
using LifeVerse.Core.SceneManagement;
using LifeVerse.Core.Launch;

namespace LifeVerse.Core
{
    /// <summary>
    /// Entry point for the LifeVerse Engine.
    /// </summary>
    public sealed class Bootstrap : MonoBehaviour
    {
        private static Bootstrap _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);

            Debug.Log("======================================");
            Debug.Log("Starting LifeVerse Engine...");
            Debug.Log("======================================");

            GameManager.Initialize();

            ServiceInitializer.Initialize();

            GameManager.ChangeState(ApplicationState.Boot);

            Debug.Log("Bootstrap initialization complete.");
        }

        private void Start()
        {
            Debug.Log("LifeVerse is ready.");

            LaunchConfiguration config =
                FindAnyObjectByType<LaunchConfiguration>();

            if (config == null)
            {
                Debug.LogWarning(
                    "No LaunchConfiguration found.");

                return;
            }

            SceneService sceneService =
                ServiceRegistry.Get<SceneService>();

            if (sceneService == null)
                return;

            switch (config.LaunchScene)
            {
                case LaunchScene.MainMenu:
                    sceneService.LoadScene(SceneNames.MainMenu);
                    break;

                case LaunchScene.Testing:
                    sceneService.LoadScene("Testing");
                    break;

                case LaunchScene.Neighborhood:
                    sceneService.LoadScene(SceneNames.Neighborhood);
                    break;

                case LaunchScene.BuildMode:
                    sceneService.LoadScene(SceneNames.BuildMode);
                    break;

                case LaunchScene.CreateAVerse:
                    sceneService.LoadScene(SceneNames.CreateAVerse);
                    break;

                case LaunchScene.Bootstrap:
                    break;
            }
        }

        private void Update()
        {
            ServiceRegistry.UpdateServices(UnityEngine.Time.deltaTime);
        }

        private void FixedUpdate()
        {
            ServiceRegistry.FixedUpdateServices(UnityEngine.Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            ServiceRegistry.LateUpdateServices(UnityEngine.Time.deltaTime);
        }

        private void OnApplicationQuit()
        {
            Debug.Log("Shutting down LifeVerse...");

            GameManager.ChangeState(ApplicationState.Exiting);

            ServiceInitializer.Shutdown();

            EventBus.Clear();
            ServiceRegistry.Clear();
        }
    }
}