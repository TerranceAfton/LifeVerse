using UnityEngine;
using LifeVerse.Characters.Controllers;
using LifeVerse.UI.Prompts;

namespace LifeVerse.Interaction.Components
{
    /// <summary>
    /// Handles interaction input and interaction prompts.
    /// </summary>
    [RequireComponent(typeof(CharacterInput))]
    [RequireComponent(typeof(InteractionDetector))]
    public sealed class InteractionController : MonoBehaviour
    {
        [SerializeField]
        private PromptManager _promptManager;

        private CharacterInput _characterInput;
        private InteractionDetector _interactionDetector;

        private void Awake()
        {
            _characterInput = GetComponent<CharacterInput>();
            _interactionDetector = GetComponent<InteractionDetector>();
        }

        private void Update()
        {
            HandleInteraction();
            UpdatePrompt();
        }

        private void UpdatePrompt()
        {
            if (_promptManager == null)
                return;

            var interactable = _interactionDetector.CurrentInteractable;

            if (interactable == null || !interactable.CanInteract())
            {
                _promptManager.HidePrompt();
                return;
            }

            _promptManager.ShowPrompt(
                new PromptData(
                    "E",
                    interactable.InteractionName));
        }

        private void HandleInteraction()
        {
            if (_characterInput.InteractPressed)
            {
                Debug.Log("Interact key pressed.");
            }

            if (!_characterInput.InteractPressed)
                return;

            var interactable = _interactionDetector.CurrentInteractable;

            if (interactable == null)
            {
                Debug.Log("No interactable.");
                return;
            }

            Debug.Log($"Interacting with: {interactable.InteractionName}");

            if (!interactable.CanInteract())
            {
                Debug.Log("Cannot interact.");
                return;
            }

            interactable.Interact(gameObject);
        }
    }
}