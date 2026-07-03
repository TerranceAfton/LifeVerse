using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

using LifeVerse.Core.Services;

namespace LifeVerse.Core.SceneManagement
{
    /// <summary>
    /// Handles scene transitions.
    /// </summary>
    public class SceneService : IGameService
    {
        public void Initialize()
        {
            Debug.Log("SceneService Initialized");
        }

        public void Shutdown()
        {
            Debug.Log("SceneService Shutdown");
        }

        public string CurrentScene =>
            UnitySceneManager.GetActiveScene().name;

        public void LoadScene(string sceneName)
        {
            Debug.Log($"Loading Scene: {sceneName}");

            GameManager.ChangeState(ApplicationState.Loading);

            UnitySceneManager.LoadScene(sceneName);
        }

        public AsyncOperation LoadSceneAsync(string sceneName)
        {
            Debug.Log($"Loading Scene Async: {sceneName}");

            GameManager.ChangeState(ApplicationState.Loading);

            return UnitySceneManager.LoadSceneAsync(sceneName);
        }

        public void ReloadCurrentScene()
        {
            LoadScene(CurrentScene);
        }
    }
}