using UnityEngine;
using LifeVerse.Interaction.Interfaces;

namespace LifeVerse.Furniture.Doors
{
    /// <summary>
    /// Basic door interaction.
    /// </summary>
    public class DoorInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Transform _door;

        [SerializeField]
        private float _openAngle = 90f;

        [SerializeField]
        private float _openSpeed = 3f;

        private bool _isOpen;

        private Quaternion _targetRotation;

        public string InteractionName =>
            _isOpen ? "Close Door" : "Open Door";

        public bool CanInteract()
        {
            return true;
        }

        private void Start()
        {
            if (_door != null)
            {
                _targetRotation = _door.localRotation;
            }
        }

        private void Update()
        {
            if (_door == null)
                return;

            _door.localRotation = Quaternion.Slerp(
                _door.localRotation,
                _targetRotation,
                _openSpeed * UnityEngine.Time.deltaTime);
        }

        public void Interact(GameObject interactor)
        {
            if (_door == null)
            {
                Debug.LogError("Door Transform not assigned.");
                return;
            }

            if (_isOpen)
            {
                _targetRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                _targetRotation = Quaternion.Euler(0f, _openAngle, 0f);
            }

            _isOpen = !_isOpen;
        }
    }
}