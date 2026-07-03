using UnityEngine;

namespace LifeVerse.Characters.Controllers
{
    /// <summary>
    /// Reads player input.
    /// </summary>
    public class CharacterInput : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; }

        public bool SprintHeld { get; private set; }

        private void Update()
        {
            MoveInput = new Vector2(
                UnityEngine.Input.GetAxisRaw("Horizontal"),
                UnityEngine.Input.GetAxisRaw("Vertical"));

            SprintHeld =
                UnityEngine.Input.GetKey(KeyCode.LeftShift);
        }
    }
}