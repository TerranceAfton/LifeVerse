using UnityEngine;
using UnityEngine.InputSystem;

namespace LifeVerse.Characters.Controllers
{
    /// <summary>
    /// Reads player input using the Unity Input System.
    /// </summary>
    public class CharacterInput : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; }
        public Vector2 LookInput { get; private set; }

        public bool SprintHeld { get; private set; }
        public bool InteractPressed { get; private set; }

        private LifeVerseInputActions _inputActions;

        private void Awake()
        {
            _inputActions = new LifeVerseInputActions();
        }

        private void OnEnable()
        {
            _inputActions.Gameplay.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Gameplay.Disable();
        }

        private void Update()
        {
            MoveInput = _inputActions.Gameplay.Move.ReadValue<Vector2>();
            LookInput = _inputActions.Gameplay.Look.ReadValue<Vector2>();

            SprintHeld = _inputActions.Gameplay.Sprint.IsPressed();

            InteractPressed =
                _inputActions.Gameplay.Interact.WasPressedThisFrame();
        }
    }
}