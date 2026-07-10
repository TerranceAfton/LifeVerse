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
        
        [SerializeField]
        [Range(0f, 180f)]
        private float _maxInteractionAngle = 60f;

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

            float closestDistance = float.MaxValue;

            foreach (Collider hit in hits)
            {
                if (hit.GetComponentInParent<IInteractable>() is not IInteractable interactable)
                    continue;

                // Add this section
                Vector3 directionToObject =
                    (hit.transform.position - transform.position).normalized;

                float angle =
                    Vector3.Angle(transform.forward, directionToObject);

                if (angle > _maxInteractionAngle)
                {
                    continue;
                }

                // Existing code
                float distance =
                    Vector3.Distance(transform.position, hit.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    CurrentInteractable = interactable;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Vector3 center =
                transform.position + transform.forward * _interactionOffset;

            // Interaction sphere
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(center, _interactionRadius);

            // Forward direction
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(
                transform.position,
                transform.position + transform.forward * (_interactionOffset + _interactionRadius));

            // Current interactable
            if (CurrentInteractable is MonoBehaviour interactable)
            {
                Gizmos.color = Color.yellow;

                Gizmos.DrawLine(
                    transform.position,
                    interactable.transform.position);

                Gizmos.DrawWireSphere(
                    interactable.transform.position,
                    0.15f);
            }
        }
    }
}