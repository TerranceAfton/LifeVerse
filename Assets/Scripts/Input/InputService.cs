using UnityEngine;
using UnityEngine.InputSystem;

using LifeVerse.Core;
using LifeVerse.Core.Services;

namespace LifeVerse.Input
{
    /// <summary>
    /// Handles all player input.
    /// </summary>
    public class InputService :
        IGameService,
        IUpdatableService
    {
        private LifeVerseInputActions _actions;

        private InputDeviceType _device =
            InputDeviceType.Unknown;

        public InputDeviceType CurrentDevice =>
            _device;

        public void Initialize()
        {
            _actions = new LifeVerseInputActions();

            SwitchActionMap(InputActionMaps.Gameplay);

            RegisterCallbacks();

            Debug.Log("InputService Initialized");
        }

        public void Shutdown()
        {
            UnregisterCallbacks();

            _actions.Disable();

            Debug.Log("InputService Shutdown");
        }

        public void Update(float deltaTime)
        {
            DetectCurrentDevice();

            Vector2 move =
                _actions.Gameplay.Move.ReadValue<Vector2>();

            if (move != Vector2.zero)
            {
                EventBus.Publish(
                    new MoveInputEvent(move));
            }
        }

        #region Gameplay

        public Vector2 Move =>
            _actions.Gameplay.Move.ReadValue<Vector2>();

        public Vector2 Look =>
            _actions.Gameplay.Look.ReadValue<Vector2>();

        public float Zoom =>
            _actions.Gameplay.ZoomCamera.ReadValue<float>();

        public bool Sprint =>
            _actions.Gameplay.Sprint.IsPressed();

        public bool Interact =>
            _actions.Gameplay.Interact.IsPressed();

        #endregion

        #region Action Maps

        public void SwitchActionMap(InputActionMaps map)
        {
            DisableAll();

            switch (map)
            {
                case InputActionMaps.Gameplay:
                    _actions.Gameplay.Enable();
                    break;

                case InputActionMaps.UI:
                    _actions.UI.Enable();
                    break;

                case InputActionMaps.BuildMode:
                    _actions.BuildMode.Enable();
                    break;

                case InputActionMaps.CreateAVerse:
                    _actions.CreateAVerse.Enable();
                    break;

                case InputActionMaps.PhotoMode:
                    _actions.PhotoMode.Enable();
                    break;

                case InputActionMaps.Debug:
                    _actions.Debug.Enable();
                    break;
            }
        }

        private void DisableAll()
        {
            _actions.Disable();
        }

        #endregion

        #region Callbacks

        private void RegisterCallbacks()
        {
            _actions.Gameplay.Pause.performed += OnPause;

            _actions.Gameplay.Interact.performed += OnInteract;
        }

        private void UnregisterCallbacks()
        {
            _actions.Gameplay.Pause.performed -= OnPause;

            _actions.Gameplay.Interact.performed -= OnInteract;
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            EventBus.Publish(
                new PausePressedEvent());
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            EventBus.Publish(
                new InteractPressedEvent());
        }

        #endregion

        #region Device Detection

        private void DetectCurrentDevice()
        {
            InputDevice device =
                Keyboard.current != null &&
                Keyboard.current.anyKey.isPressed
                    ? Keyboard.current
                    : Gamepad.current;

            if (device == null)
                return;

            if (device is Keyboard ||
                device is Mouse)
            {
                _device =
                    InputDeviceType.KeyboardMouse;
            }
            else if (device is Gamepad)
            {
                _device =
                    InputDeviceType.Gamepad;
            }
        }

        #endregion
    }
}