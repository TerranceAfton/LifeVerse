using TMPro;
using UnityEngine;

namespace LifeVerse.UI.Prompts
{
    /// <summary>
    /// Displays the current interaction prompt.
    /// </summary>
    public class InteractionPrompt : MonoBehaviour
    {
        [Header("UI")]

        [SerializeField]
        private TextMeshProUGUI _inputText;

        [SerializeField]
        private TextMeshProUGUI _actionText;

        private void Awake()
        {
            Hide();
        }

        /// <summary>
        /// Displays a prompt.
        /// </summary>
        public void Show(PromptData data)
        {
            if (_inputText != null)
                _inputText.text = data.Input;

            if (_actionText != null)
                _actionText.text = data.Action;

            gameObject.SetActive(true);
        }

        /// <summary>
        /// Hides the prompt.
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}