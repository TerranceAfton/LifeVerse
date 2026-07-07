using UnityEngine;

namespace LifeVerse.Interaction.Components
{
    /// <summary>
    /// Handles player interaction input.
    /// </summary>
    [RequireComponent(typeof(InteractionDetector))]
    public class InteractionInput : MonoBehaviour
    {
        private InteractionDetector _detector;

        private void Awake()
        {
            _detector = GetComponent<InteractionDetector>();
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