using UnityEngine;

namespace LifeVerse.Camera
{
    /// <summary>
    /// Rotates the player and camera target from look input.
    /// </summary>
    public class LifeVerseCameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform _cameraTarget;

        [SerializeField]
        private LifeVerse.Characters.Controllers.CharacterInput _characterInput;

        [Header("Settings")]
        [SerializeField]
        private float _mouseSensitivity = 0.15f;

        [SerializeField]
        private float _minPitch = -35f;

        [SerializeField]
        private float _maxPitch = 70f;

        private float _pitch;

        private void Awake()
        {
            if (_characterInput == null)
                _characterInput = GetComponent<LifeVerse.Characters.Controllers.CharacterInput>();
        }

        private void Update()
        {
            Vector2 look = _characterInput.LookInput;

            // Rotate player (yaw)
            transform.Rotate(Vector3.up * look.x * _mouseSensitivity);

            // Rotate camera target (pitch)
            _pitch -= look.y * _mouseSensitivity;
            _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

            _cameraTarget.localRotation =
                Quaternion.Euler(_pitch, 0f, 0f);
        }
    }
}