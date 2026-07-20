using UnityEngine;
using LifeVerse.Interaction.Interfaces;
using LifeVerse.Characters;

namespace LifeVerse.Interaction.Components
{
    /// <summary>
    /// Detects interactable objects near the player.
    /// </summary>
    [RequireComponent(typeof(CharacterStateController))]
    public class InteractionDetector : MonoBehaviour
    {
        [SerializeField]
        private float _interactionRadius = 1f;

        [SerializeField]
        private float _interactionOffset = 1.5f;

        [SerializeField]
        [Range(0f, 180f)]
        private float _maxInteractionAngle = 60f;

        private CharacterStateController _stateController;

        public IInteractable CurrentInteractable { get; private set; }

        private void Awake()
        {
            _stateController = GetComponent<CharacterStateController>();
        }

        private void Update()
        {
            Detect();
        }

        private void Detect()
        {
            CurrentInteractable = null;

            Vector3 center;

            // If movement is locked (sitting/sleeping),
            // search around the player instead of in front.
            if (_stateController.IsMovementLocked)
            {
                center = transform.position;
            }
            else
            {
                center =
                    transform.position + transform.forward * _interactionOffset;
            }

            Collider[] hits =
                Physics.OverlapSphere(center, _interactionRadius);

            float closestDistance = float.MaxValue;

            foreach (Collider hit in hits)
            {
                if (hit.GetComponentInParent<IInteractable>() is not IInteractable interactable)
                    continue;

                // Only use the angle check while standing.
                if (!_stateController.IsMovementLocked)
                {
                    Vector3 directionToObject =
                        (hit.transform.position - transform.position).normalized;

                    float angle =
                        Vector3.Angle(transform.forward, directionToObject);

                    if (angle > _maxInteractionAngle)
                        continue;
                }

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
            Vector3 center;

            if (Application.isPlaying &&
                _stateController != null &&
                _stateController.IsMovementLocked)
            {
                center = transform.position;
            }
            else
            {
                center =
                    transform.position + transform.forward * _interactionOffset;
            }

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(center, _interactionRadius);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(
                transform.position,
                center);

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