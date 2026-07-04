using UnityEngine;
using LifeVerse.Interaction.Interfaces;

namespace LifeVerse.Furniture.Chairs
{
    /// <summary>
    /// Basic chair interaction.
    /// </summary>
    public class ChairInteractable : MonoBehaviour, IInteractable
    {
        public string InteractionName => "Sit";

        public bool CanInteract()
        {
            return true;
        }

        public void Interact()
        {
            Debug.Log("Player sat on the chair.");
        }
    }
}