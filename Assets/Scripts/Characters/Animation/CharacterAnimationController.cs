using UnityEngine;

namespace LifeVerse.Characters.Animation
{
    /// <summary>
    /// Controls character animations.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimationController : MonoBehaviour
    {
        private Animator _animator;

        private static readonly int SpeedHash =
            Animator.StringToHash("Speed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetMovementSpeed(float speed)
        {
            _animator.SetFloat(SpeedHash, speed);
        }

        public void PlaySit()
        {
            _animator.SetTrigger("Sit");
        }

        public void PlayStand()
        {
            _animator.SetTrigger("Stand");
        }
    }
}