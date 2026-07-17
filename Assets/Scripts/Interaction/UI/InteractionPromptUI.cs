using UnityEngine;
using LifeVerse.Interaction.Components;
using LifeVerse.Interaction.Interfaces;
using LifeVerse.UI.Prompts;

namespace LifeVerse.Interaction.UI
{
    /// <summary>
    /// Controls the interaction prompt based on the
    /// currently detected interactable.
    /// </summary>
    public class InteractionPromptUI : MonoBehaviour
    {
        [SerializeField]
        private InteractionDetector _detector;

        [SerializeField]
        private InteractionPrompt _interactionPrompt;

        private IInteractable _currentInteractable;
        private string _currentInteractionName;

        private void Awake()
        {
            if (_interactionPrompt != null)
            {
                _interactionPrompt.Hide();
            }
        }

        private void Update()
        {
            if (_detector == null || _interactionPrompt == null)
                return;

            IInteractable interactable = _detector.CurrentInteractable;

            // Nothing detected.
            if (interactable == null)
            {
                if (_currentInteractable != null)
                {
                    _currentInteractable = null;
                    _currentInteractionName = string.Empty;
                    _interactionPrompt.Hide();
                }

                return;
            }

            string interactionName = interactable.InteractionName;

            // Only update if the interactable OR its interaction name changed.
            if (interactable == _currentInteractable &&
                interactionName == _currentInteractionName)
            {
                return;
            }

            _currentInteractable = interactable;
            _currentInteractionName = interactionName;

            PromptData data = new PromptData(
                "E",
                interactionName);

            _interactionPrompt.Show(data);
        }
    }
}