using UnityEngine;

namespace LifeVerse.Characters.States
{
    /// <summary>
    /// Tracks and manages the character's current state.
    /// </summary>
    public class CharacterStateController : MonoBehaviour
    {
        public CharacterState CurrentState { get; private set; }
            = CharacterState.Idle;

        public bool IsMovementLocked =>
            CurrentState == CharacterState.Sitting ||
            CurrentState == CharacterState.Sleeping;

        public void SetState(CharacterState state)
        {
            CurrentState = state;

            Debug.Log($"Character State: {state}");
        }
    }
}