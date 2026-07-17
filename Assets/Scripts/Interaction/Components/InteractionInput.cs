using UnityEngine;
using LifeVerse.Characters;
using LifeVerse.Interaction.Interfaces;
using LifeVerse.UI.Prompts;

namespace LifeVerse.Interaction.Components
{
    /// <summary>
    /// Handles player interaction input and interaction prompts.
    /// </summary>
    [RequireComponent(typeof(InteractionDetector))]
    public class InteractionInput : MonoBehaviour
    {
        [SerializeField]
        private PromptManager _promptManager;

        private InteractionDetector _detector;
        private CharacterInteractionController _interactionController;
        private CharacterStateController _stateController;

        private IInteractable _currentPromptInteractable;

        private void Awake()
        {
            _detector = GetComponent<InteractionDetector>();
            _interactionController = GetComponent<CharacterInteractionController>();
            _stateController = GetComponent<CharacterStateController>();

            if (_promptManager != null)
            {
                _promptManager.HidePrompt();
            }
        }

        private void Update()
        {
            UpdatePrompt();

            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                TryInteract();
            }
        }

        private void UpdatePrompt()
        {
            IInteractable interactable = _detector.CurrentInteractable;

            // Nothing changed.
            if (interactable == _currentPromptInteractable)
                return;

            _currentPromptInteractable = interactable;

            if (_currentPromptInteractable == null)
            {
                _promptManager?.HidePrompt();
                return;
            }

            _promptManager?.ShowPrompt(
                new PromptData(
                    "E",
                    _currentPromptInteractable.InteractionName));
        }

        private void TryInteract()
        {
            // Stand up if currently sitting.
            if (_stateController.CurrentState == CharacterState.Sitting)
            {
                _interactionController.Stand();
                return;
            }

            // Wake up if currently sleeping.
            if (_stateController.CurrentState == CharacterState.Sleeping)
            {
                _interactionController.WakeUp();
                return;
            }

            if (_detector.CurrentInteractable == null)
                return;

            if (!_detector.CurrentInteractable.CanInteract())
                return;

            _detector.CurrentInteractable.Interact(gameObject);
        }
    }
}