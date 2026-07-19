using System;
using UnityEngine;
using LifeVerse.Items.Data;
using LifeVerse.Items.Inventory;

namespace LifeVerse.Characters.Components
{
    /// <summary>
    /// Represents the player's inventory component.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class PlayerInventory : MonoBehaviour
    {
        [Header("Inventory")]

        [SerializeField]
        [Min(1)]
        private int _slotCount = 24;

        /// <summary>
        /// Gets the player's inventory container.
        /// </summary>
        public InventoryContainer Inventory { get; private set; }

        private void Awake()
        {
            Inventory = new InventoryContainer(_slotCount);
        }

        /// <summary>
        /// Attempts to add an item to the inventory.
        /// </summary>
        /// <param name="definition">The item to add.</param>
        /// <param name="quantity">The quantity to add.</param>
        /// <returns>The quantity that could not be added.</returns>
        public int AddItem(ItemDefinition definition, int quantity)
        {
            if (Inventory == null)
            {
                throw new InvalidOperationException("Inventory has not been initialized.");
            }

            return Inventory.AddItem(definition, quantity);
        }

        /// <summary>
        /// Attempts to remove an item from the inventory.
        /// </summary>
        /// <param name="definition">The item to remove.</param>
        /// <param name="quantity">The quantity to remove.</param>
        /// <returns>The quantity that could not be removed.</returns>
        public int RemoveItem(ItemDefinition definition, int quantity)
        {
            if (Inventory == null)
            {
                throw new InvalidOperationException("Inventory has not been initialized.");
            }

            return Inventory.RemoveItem(definition, quantity);
        }

        /// <summary>
        /// Returns true if the inventory contains the specified item.
        /// </summary>
        public bool Contains(ItemDefinition definition)
        {
            return Inventory.Contains(definition);
        }

        /// <summary>
        /// Gets the total quantity of the specified item.
        /// </summary>
        public int GetItemCount(ItemDefinition definition)
        {
            return Inventory.GetItemCount(definition);
        }

        /// <summary>
        /// Returns true if the inventory has room for the specified quantity.
        /// </summary>
        public bool HasSpaceFor(ItemDefinition definition, int quantity)
        {
            return Inventory.HasSpaceFor(definition, quantity);
        }

        /// <summary>
        /// Removes every item from the inventory.
        /// </summary>
        public void Clear()
        {
            Inventory.Clear();
        }
    }
}