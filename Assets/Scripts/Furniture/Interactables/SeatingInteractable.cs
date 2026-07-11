using UnityEngine;
using LifeVerse.Interaction.Interfaces;
using LifeVerse.Characters;

namespace LifeVerse.Furniture.Base
{
    /// <summary>
    /// Base class for furniture that allows characters to sit.
    /// </summary>
    public abstract class SeatingInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        protected Transform _seatPoint;

        public virtual string InteractionName => "Sit";

        public virtual bool CanInteract()
        {
            return true;
        }

        public virtual void Interact(GameObject interactor)
        {
            if (_seatPoint == null)
            {
                Debug.LogError("SeatPoint has not been assigned!");
                return;
            }

            CharacterInteractionController interaction =
                interactor.GetComponent<CharacterInteractionController>();

            if (interaction == null)
            {
                Debug.LogError("CharacterInteractionController not found!");
                return;
            }

            interaction.Sit(_seatPoint);
        }
    }
}