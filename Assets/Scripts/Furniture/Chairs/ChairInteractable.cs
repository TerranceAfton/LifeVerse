using UnityEngine;
using LifeVerse.Interaction.Interfaces;
using LifeVerse.Characters;

namespace LifeVerse.Furniture.Chairs
{
    /// <summary>
    /// Basic chair interaction.
    /// </summary>
    public class ChairInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Transform _seatPoint;

        public string InteractionName => "Sit";

        public bool CanInteract()
        {
            return true;
        }

        public void Interact(GameObject interactor)
        {
            Debug.Log("ChairInteractable.Interact() called.");

            CharacterInteractionController interaction =
                interactor.GetComponent<CharacterInteractionController>();

            if (interaction == null)
            {
                Debug.Log("CharacterInteractionController NOT FOUND!");
                return;
            }

            if (_seatPoint == null)
            {
                Debug.LogError("SeatPoint has not been assigned!");
                return;
            }

            Debug.Log("CharacterInteractionController found.");

            interaction.Sit(_seatPoint);
        }
    }
}