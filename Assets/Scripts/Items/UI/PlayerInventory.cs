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
        private int _capacity = 24;

        /// <summary>
        /// Gets the player's inventory.
        /// </summary>
        public Inventory Inventory { get; private set; }

        private void Awake()
        {
            Inventory = new Inventory(_capacity);
        }

        /// <summary>
        /// Attempts to add items to the inventory.
        /// </summary>
        public int AddItem(ItemDefinition definition, int quantity)
        {
            EnsureInitialized();
            return Inventory.AddItem(definition, quantity);
        }

        /// <summary>
        /// Attempts to remove items from the inventory.
        /// </summary>
        public int RemoveItem(ItemDefinition definition, int quantity)
        {
            EnsureInitialized();
            return Inventory.RemoveItem(definition, quantity);
        }

        /// <summary>
        /// Returns true if the inventory contains the specified item.
        /// </summary>
        public bool Contains(ItemDefinition definition)
        {
            EnsureInitialized();
            return Inventory.Contains(definition);
        }

        /// <summary>
        /// Gets the total quantity of the specified item.
        /// </summary>
        public int GetItemCount(ItemDefinition definition)
        {
            EnsureInitialized();
            return Inventory.Count(definition);
        }

        /// <summary>
        /// Returns true if the inventory is full.
        /// </summary>
        public bool IsFull()
        {
            EnsureInitialized();
            return Inventory.IsFull();
        }

        /// <summary>
        /// Gets the number of empty inventory slots.
        /// </summary>
        public int EmptySlotCount
        {
            get
            {
                EnsureInitialized();
                return Inventory.EmptySlotCount;
            }
        }

        /// <summary>
        /// Removes every item from the inventory.
        /// </summary>
        public void Clear()
        {
            EnsureInitialized();
            Inventory.Clear();
        }

        /// <summary>
        /// Ensures the inventory has been initialized.
        /// </summary>
        private void EnsureInitialized()
        {
            if (Inventory == null)
            {
                throw new InvalidOperationException(
                    "Inventory has not been initialized.");
            }
        }
    }
}