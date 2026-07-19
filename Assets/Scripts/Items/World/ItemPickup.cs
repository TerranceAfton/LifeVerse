using UnityEngine;
using LifeVerse.Characters.Components;
using LifeVerse.Interaction.Interfaces;

namespace LifeVerse.Items.World
{
    [RequireComponent(typeof(WorldItem))]
    [DisallowMultipleComponent]
    public sealed class ItemPickup : MonoBehaviour, IInteractable
    {
        private WorldItem _worldItem;

        public string InteractionName => "Pick Up";

        private void Awake()
        {
            _worldItem = GetComponent<WorldItem>();
        }

        public bool CanInteract()
        {
            return _worldItem != null;
        }

        public void Interact(GameObject interactor)
        {
            PlayerInventory inventory =
                interactor.GetComponent<PlayerInventory>();

            if (inventory == null)
            {
                return;
            }

            int remaining = inventory.AddItem(
                _worldItem.Definition,
                _worldItem.Quantity);

            if (remaining == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}