using UnityEngine;
using LifeVerse.Characters;

namespace LifeVerse.Interaction.Components
{
    /// <summary>
    /// Handles player interaction input.
    /// </summary>
    [RequireComponent(typeof(InteractionDetector))]
    public class InteractionInput : MonoBehaviour
    {
        private InteractionDetector _detector;
        private CharacterInteractionController _interactionController;
        private CharacterStateController _stateController;

        private void Awake()
        {
            _detector = GetComponent<InteractionDetector>();
            _interactionController = GetComponent<CharacterInteractionController>();
            _stateController = GetComponent<CharacterStateController>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E Pressed");

                TryInteract();
            }
        }

        private void TryInteract()
        {
            Debug.Log("TryInteract");

            // Stand up if currently sitting.
            if (_stateController.CurrentState == CharacterState.Sitting)
            {
                Debug.Log("Standing up.");

                _interactionController.Stand();

                return;
            }

            // Wake up if currently sleeping.
            if (_stateController.CurrentState == CharacterState.Sleeping)
            {
                Debug.Log("Waking up.");

                _interactionController.WakeUp();

                return;
            }

            if (_detector.CurrentInteractable == null)
            {
                Debug.Log("No interactable found.");
                return;
            }

            Debug.Log("Found: " + _detector.CurrentInteractable.InteractionName);

            if (!_detector.CurrentInteractable.CanInteract())
            {
                Debug.Log("Interactable cannot be used.");
                return;
            }

            Debug.Log("Calling Interact()");

            _detector.CurrentInteractable.Interact(gameObject);
        }
    }
}