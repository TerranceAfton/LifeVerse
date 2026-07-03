using UnityEngine;
using LifeVerse.Interaction.Interfaces;

namespace LifeVerse.Interaction.Components
{
    /// <summary>
    /// Detects interactable objects in front of the player.
    /// </summary>
    public class InteractionDetector : MonoBehaviour
    {
        [SerializeField]
        private float _interactionRadius = 1f;

        [SerializeField]
        private float _interactionOffset = 1.5f;

        public IInteractable CurrentInteractable { get; private set; }

        private void Update()
        {
            Detect();
        }

        private void Detect()
        {
            CurrentInteractable = null;

            Vector3 center =
                transform.position + transform.forward * _interactionOffset;

            Collider[] hits =
                Physics.OverlapSphere(center, _interactionRadius);

            foreach (Collider hit in hits)
            {
                if (hit.TryGetComponent<IInteractable>(out var interactable))
                {
                    CurrentInteractable = interactable;
                    return;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            Vector3 center =
                transform.position + transform.forward * _interactionOffset;

            Gizmos.DrawWireSphere(center, _interactionRadius);
        }
    }
}