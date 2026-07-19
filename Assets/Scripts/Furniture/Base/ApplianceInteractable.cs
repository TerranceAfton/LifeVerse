using UnityEngine;
using LifeVerse.Interaction.Interfaces;

namespace LifeVerse.Furniture.Base
{
    /// <summary>
    /// Base class for interactive household appliances.
    /// </summary>
    public abstract class ApplianceInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        protected string interactionName = "Use";

        public virtual string InteractionName => interactionName;

        public virtual bool CanInteract()
        {
            return true;
        }

        public abstract void Interact(GameObject interactor);
    }
}