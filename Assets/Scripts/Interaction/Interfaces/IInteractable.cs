using UnityEngine;

namespace LifeVerse.Interaction.Interfaces
{
    public interface IInteractable
    {
        string InteractionName { get; }

        bool CanInteract();

        void Interact(GameObject interactor);
    }
}