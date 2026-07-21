using System;
using System.Collections.Generic;
using LifeVerse.Items.Data;

namespace LifeVerse.Items.Inventory
{
    /// <summary>
    /// Represents a fixed-size inventory containing item slots.
    /// </summary>
    public class Inventory
    {
        private readonly List<InventorySlot> _slots;

        /// <summary>
        /// Gets the maximum number of slots in this inventory.
        /// </summary>
        public int Capacity => _slots.Count;

        /// <summary>
        /// Gets a read-only list of inventory slots.
        /// </summary>
        public IReadOnlyList<InventorySlot> Slots => _slots;

        /// <summary>
        /// Raised whenever the inventory contents change.
        /// </summary>
        public event Action InventoryChanged;

        /// <summary>
        /// Creates a new inventory with the specified number of slots.
        /// </summary>
        public Inventory(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _slots = new List<InventorySlot>(capacity);

            for (int i = 0; i < capacity; i++)
            {
                _slots.Add(new InventorySlot());
            }
        }

        /// <summary>
        /// Attempts to add the specified quantity of an item.
        /// Returns true if the entire quantity was added.
        /// </summary>
        public int AddItem(ItemDefinition definition, int quantity)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            if (quantity <= 0)
            {
                return 0;
            }

            int remaining = quantity;

            // Fill existing stacks first.
            foreach (InventorySlot slot in _slots)
            {
                if (!slot.CanStack(definition))
                {
                    continue;
                }

                int amountToAdd = Math.Min(
                    remaining,
                    slot.RemainingCapacity);

                slot.Item.Add(amountToAdd);

                remaining -= amountToAdd;

                if (remaining <= 0)
                {
                    InventoryChanged?.Invoke();
                    return 0;
                }
            }

            // Fill empty slots.
            foreach (InventorySlot slot in _slots)
            {
                if (!slot.IsEmpty)
                {
                    continue;
                }

                int amountToAdd = Math.Min(
                    remaining,
                    definition.MaxStackSize);

                slot.SetItem(new InventoryItem(
                    definition,
                    amountToAdd));

                remaining -= amountToAdd;

                if (remaining <= 0)
                {
                    InventoryChanged?.Invoke();
                    return 0;
                }
            }

            if (remaining != quantity)
            {
                InventoryChanged?.Invoke();
            }

            return remaining;
        }

        /// <summary>
        /// Attempts to remove the specified quantity of an item.
        /// Returns true if the entire quantity was removed.
        /// </summary>
        public int RemoveItem(ItemDefinition definition, int quantity)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            if (quantity <= 0)
            {
                return 0;
            }

            int remaining = quantity;

            foreach (InventorySlot slot in _slots)
            {
                if (!slot.Contains(definition))
                {
                    continue;
                }

                int amountToRemove = Math.Min(
                    remaining,
                    slot.Item.Quantity);

                slot.Item.Remove(amountToRemove);

                if (slot.Item.IsEmpty)
                {
                    slot.Clear();
                }

                remaining -= amountToRemove;

                if (remaining <= 0)
                {
                    InventoryChanged?.Invoke();
                    return 0;
                }
            }

            if (remaining != quantity)
            {
                InventoryChanged?.Invoke();
            }

            return remaining;
        }

        /// <summary>
        /// Returns true if the inventory contains at least one of the specified item.
        /// </summary>
        public bool Contains(ItemDefinition definition)
        {
            foreach (InventorySlot slot in _slots)
            {
                if (slot.Contains(definition))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the total quantity of the specified item.
        /// </summary>
        public int Count(ItemDefinition definition)
        {
            int total = 0;

            foreach (InventorySlot slot in _slots)
            {
                if (slot.Contains(definition))
                {
                    total += slot.Item.Quantity;
                }
            }

            return total;
        }

        /// <summary>
        /// Returns true if there are no available slots and no partially filled stacks.
        /// </summary>
        public bool IsFull()
        {
            foreach (InventorySlot slot in _slots)
            {
                if (slot.IsEmpty)
                {
                    return false;
                }

                if (slot.RemainingCapacity > 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Removes every item from the inventory.
        /// </summary>
        public void Clear()
        {
            foreach (InventorySlot slot in _slots)
            {
                slot.Clear();
            }

            InventoryChanged?.Invoke();
        }

        /// <summary>
        /// Returns the number of empty slots.
        /// </summary>
        public int EmptySlotCount
        {
            get
            {
                int count = 0;

                foreach (InventorySlot slot in _slots)
                {
                    if (slot.IsEmpty)
                    {
                        count++;
                    }
                }

                return count;
            }
        }
    }
}