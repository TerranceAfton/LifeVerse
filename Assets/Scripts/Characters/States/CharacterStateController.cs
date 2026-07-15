using UnityEngine;

namespace LifeVerse.Characters
{
    /// <summary>
    /// Tracks and manages the character's current state.
    /// </summary>
    [RequireComponent(typeof(CharacterReference))]
    public class CharacterStateController : MonoBehaviour
    {
        private CharacterReference _characterReference;

        public CharacterState CurrentState { get; private set; }
            = CharacterState.Idle;

        public bool IsMovementLocked =>
            CurrentState == CharacterState.Sitting ||
            CurrentState == CharacterState.Sleeping;

        private void Awake()
        {
            _characterReference =
                GetComponent<CharacterReference>();
        }

        public void SetState(CharacterState state)
        {
            CurrentState = state;

            if (_characterReference != null &&
                _characterReference.HasCharacter)
            {
                _characterReference
                    .Character
                    .ChangeState(state);
            }

            Debug.Log($"Character State: {CurrentState}");
        }
    }
}