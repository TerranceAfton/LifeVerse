using UnityEngine;

namespace LifeVerse.Characters
{
    /// <summary>
    /// Links a Unity GameObject to its simulation Character.
    /// </summary>
    public class CharacterReference : MonoBehaviour
    {
        /// <summary>
        /// The simulation Character represented by this GameObject.
        /// </summary>
        public Character Character { get; private set; }

        /// <summary>
        /// Initializes the reference.
        /// </summary>
        public void Initialize(Character character)
        {
            Character = character;
        }

        /// <summary>
        /// True if a simulation Character has been assigned.
        /// </summary>
        public bool HasCharacter => Character != null;
    }
}