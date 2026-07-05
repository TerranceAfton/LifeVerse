using UnityEngine;
using LifeVerse.Characters.Animation;

namespace LifeVerse.Characters.Controllers
{
    /// <summary>
    /// Moves the player using Unity's CharacterController.
    /// </summary>
    [RequireComponent(typeof(UnityEngine.CharacterController))]
    [RequireComponent(typeof(CharacterInput))]
    public class CharacterMotor : MonoBehaviour
    {
        [SerializeField]
        private CharacterMovementSettings _settings = new();

        [SerializeField]
        private CharacterAnimationController _animationController;

        private UnityEngine.CharacterController _controller;
        private CharacterInput _input;

        private Vector3 _velocity;

        private void Awake()
        {
            _controller = GetComponent<UnityEngine.CharacterController>();
            _input = GetComponent<CharacterInput>();

            if (_animationController == null)
            {
                _animationController =
                    GetComponentInChildren<CharacterAnimationController>();
            }
        }

        private void Update()
        {
            Move();
            ApplyGravity();
        }

        private void Move()
        {
            // Get camera-relative directions
            Transform cameraTransform = UnityEngine.Camera.main.transform;

            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // Ignore vertical component
            cameraForward.y = 0f;
            cameraRight.y = 0f;

            cameraForward.Normalize();
            cameraRight.Normalize();

            // Calculate movement direction relative to camera
            Vector3 move =
                cameraForward * -_input.MoveInput.y +
                cameraRight * _input.MoveInput.x;

            Debug.DrawRay(transform.position, move, Color.green);
            Debug.DrawRay(transform.position, transform.forward, Color.blue);

            // Rotate player toward movement direction
            /*
            if (move.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move);

                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    _settings.RotationSpeed * UnityEngine.Time.deltaTime);
             }
             */

            float speed = _input.SprintHeld
                ? _settings.SprintSpeed
                : _settings.WalkSpeed;

            _controller.Move(move * speed * UnityEngine.Time.deltaTime);

            if (_animationController != null)
            {
                _animationController.SetMovementSpeed(
                    move.magnitude * speed);
            }
        }

        private void ApplyGravity()
        {
            if (_controller.isGrounded && _velocity.y < 0f)
            {
                _velocity.y = _settings.GroundedGravity;
            }

            _velocity.y += _settings.Gravity * UnityEngine.Time.deltaTime;

            _controller.Move(_velocity * UnityEngine.Time.deltaTime);
        }
    }
}