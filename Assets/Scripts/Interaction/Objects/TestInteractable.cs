using UnityEngine;
using LifeVerse.Interaction.Interfaces;

namespace LifeVerse.Interaction.Objects
{
    /// <summary>
    /// Simple interactable object for testing.
    /// </summary>
    public class TestInteractable : MonoBehaviour, IInteractable
    {
        public string InteractionName => "Interact";

        public bool CanInteract()
        {
            return true;
        }

        public void Interact()
        {
            Debug.Log("Interacted with Test Cube!");
        }
    }
}