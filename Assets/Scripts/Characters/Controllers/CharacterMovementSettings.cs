using UnityEngine;

namespace LifeVerse.Characters.Controllers
{
    /// <summary>
    /// Stores movement configuration.
    /// </summary>
    [System.Serializable]
    public class CharacterMovementSettings
    {
        [Header("Movement")]
        public float WalkSpeed = 4f;

        public float SprintSpeed = 7f;

        [Header("Gravity")]
        public float Gravity = -20f;

        public float GroundedGravity = -2f;

        [Header("Jump")]
        public float JumpHeight = 1.2f;

        [Header("Rotation")]
        public float RotationSpeed = 10f;
    }
}