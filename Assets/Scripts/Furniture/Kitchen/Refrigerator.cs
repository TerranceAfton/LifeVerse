using UnityEngine;
using LifeVerse.Interaction.Interfaces;

namespace LifeVerse.Furniture.Kitchen
{
    /// <summary>
    /// A refrigerator that can be opened by the player.
    /// </summary>
    public class Refrigerator : MonoBehaviour, IInteractable
    {
        public string InteractionName => "Open Refrigerator";

        public bool CanInteract()
        {
            return true;
        }

        public void Interact(GameObject interactor)
        {
            Debug.Log("Refrigerator opened.");

            // Future:
            // RefrigeratorUI.Instance.Open(this);
        }
    }
}