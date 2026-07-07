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

        public void Sit()
        {
            _stateController.SetState(CharacterState.Sitting);

            _animationController?.PlaySit();

            Debug.Log("Character is now sitting.");
        }

        public void Stand()
        {
            _stateController.SetState(CharacterState.Idle);

            _animationController?.PlayStand();

            Debug.Log("Character stood up.");
        }
    }
}