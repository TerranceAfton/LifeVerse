using UnityEngine;

namespace LifeVerse.UI.Prompts
{
    /// <summary>
    /// Controls all interaction prompts.
    /// </summary>
    public class PromptManager : MonoBehaviour
    {
        [SerializeField]
        private InteractionPrompt _interactionPrompt;

        private void Awake()
        {
            HidePrompt();
        }

        /// <summary>
        /// Displays an interaction prompt.
        /// </summary>
        public void ShowPrompt(PromptData data)
        {
            if (_interactionPrompt == null)
                return;

            _interactionPrompt.Show(data);
        }

        /// <summary>
        /// Hides the current interaction prompt.
        /// </summary>
        public void HidePrompt()
        {
            if (_interactionPrompt == null)
                return;

            _interactionPrompt.Hide();
        }
    }
}