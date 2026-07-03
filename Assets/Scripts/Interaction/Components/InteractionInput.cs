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
                TryInteract();
            }
        }

        private void TryInteract()
        {
            if (_detector.CurrentInteractable == null)
                return;

            if (!_detector.CurrentInteractable.CanInteract())
                return;

            _detector.CurrentInteractable.Interact();
        }
    }
}