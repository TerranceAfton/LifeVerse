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
            Vector3 move = new Vector3(
                _input.MoveInput.x,
                0f,
                _input.MoveInput.y);

            move = transform.TransformDirection(move);

            float speed = _input.SprintHeld
                ? _settings.SprintSpeed
                : _settings.WalkSpeed;

            _controller.Move(move * speed * UnityEngine.Time.deltaTime);

            // Update animation speed
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