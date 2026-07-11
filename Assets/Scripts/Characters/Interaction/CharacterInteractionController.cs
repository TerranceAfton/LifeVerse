using UnityEngine;

namespace LifeVerse.Characters
{
    /// <summary>
    /// Handles interactions performed by the player.
    /// </summary>
    [RequireComponent(typeof(CharacterStateController))]
    public class CharacterInteractionController : MonoBehaviour
    {
        private CharacterStateController _stateController;
        private Characters.Animation.CharacterAnimationController _animationController;

        private void Awake()
        {
            _stateController = GetComponent<CharacterStateController>();

            _animationController =
                GetComponentInChildren<Characters.Animation.CharacterAnimationController>();
        }

        public void Sit(Transform seatPoint)
        {
            // Move player to the chair.
            transform.position = seatPoint.position;

            // Face the same direction as the chair.
            transform.rotation = seatPoint.rotation;

            // Update character state.
            _stateController.SetState(CharacterState.Sitting);

            // Play animation.
            _animationController?.PlaySit();

            Debug.Log("Character is now sitting.");
        }

        public void Stand()
        {
            _animationController?.PlayStand();

            Invoke(nameof(FinishStanding), 1.0f);
        }

        public void Sleep(Transform sleepPoint)
        {
            // Move player onto the bed.
            transform.position = sleepPoint.position;

            // Face the correct direction.
            transform.rotation = sleepPoint.rotation;

            // Change state.
            _stateController.SetState(CharacterState.Sleeping);

            Debug.Log("Character started sleeping.");
        }

        private void FinishStanding()
        {
            _stateController.SetState(CharacterState.Idle);

            Debug.Log("Character stood up.");
        }
        public void WakeUp()
        {
            _stateController.SetState(CharacterState.Idle);

            Debug.Log("Character woke up.");
        }
    }
}