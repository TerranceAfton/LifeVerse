using System;
using System.Collections.Generic;
using LifeVerse.Items.Data;
using LifeVerse.Items.Events;

namespace LifeVerse.Items.Inventory
{
    /// <summary>
    /// Represents a container that stores inventory slots.
    /// </summary>
    public class InventoryContainer
    {
        private readonly List<InventorySlot> _slots;

        #region Events

        /// <summary>
        /// Raised whenever the contents of the inventory change.
        /// </summary>
        public event EventHandler<InventoryChangedEventArgs> InventoryChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the collection of inventory slots.
        /// </summary>
        public IReadOnlyList<InventorySlot> Slots => _slots;

        /// <summary>
        /// Gets the total number of slots in the inventory.
        /// </summary>
        public int SlotCount => _slots.Count;

        /// <summary>
        /// Returns true if every slot is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                foreach (InventorySlot slot in _slots)
                {
                    if (!slot.IsEmpty)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new inventory container with the specified number of slots.
        /// </summary>
        /// <param name="slotCount">The number of inventory slots.</param>
        public InventoryContainer(int slotCount)
        {
            if (slotCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(slotCount));
            }

            _slots = new List<InventorySlot>(slotCount);

            for (int i = 0; i < slotCount; i++)
            {
                _slots.Add(new InventorySlot());
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// Finds the first empty inventory slot.
        /// </summary>
        public InventorySlot FindFirstEmptySlot()
        {
            foreach (InventorySlot slot in _slots)
            {
                if (slot.IsEmpty)
                {
                    return slot;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds the first inventory slot that can stack more of the specified item.
        /// </summary>
        public InventorySlot FindStack(ItemDefinition definition)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            foreach (InventorySlot slot in _slots)
            {
                if (slot.CanStack(definition))
                {
                    return slot;
                }
            }

            return null;
        }

        #endregion

        #region Modification Methods

        /// <summary>
        /// Attempts to add the specified quantity of an item.
        /// Returns the quantity that could not be added.
        /// </summary>
        public int AddItem(ItemDefinition definition, int quantity)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            if (quantity <= 0)
            {
                return quantity;
            }

            int remaining = quantity;

            while (remaining > 0)
            {
                InventorySlot slot = FindStack(definition);

                if (slot != null)
                {
                    int amountToAdd = Math.Min(slot.RemainingCapacity, remaining);

                    slot.Item.Add(amountToAdd);

                    remaining -= amountToAdd;
                }
                else
                {
                    slot = FindFirstEmptySlot();

                    if (slot == null)
                    {
                        break;
                    }

                    int newStackAmount = Math.Min(definition.MaxStackSize, remaining);

                    slot.SetItem(new InventoryItem(definition, newStackAmount));

                    remaining -= newStackAmount;
                }
            }

            if (remaining != quantity)
            {
                OnInventoryChanged();
            }

            return remaining;
        }

        /// <summary>
        /// Attempts to remove the specified quantity of an item.
        /// Returns the quantity that could not be removed.
        /// </summary>
        public int RemoveItem(ItemDefinition definition, int quantity)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            if (quantity <= 0)
            {
                return quantity;
            }

            int remaining = quantity;

            foreach (InventorySlot slot in _slots)
            {
                if (!slot.Contains(definition))
                {
                    continue;
                }

                int amountToRemove = Math.Min(slot.Item.Quantity, remaining);

                slot.Item.Remove(amountToRemove);

                remaining -= amountToRemove;

                if (slot.Item.IsEmpty)
                {
                    slot.Clear();
                }

                if (remaining == 0)
                {
                    break;
                }
            }

            if (remaining != quantity)
            {
                OnInventoryChanged();
            }

            return remaining;
        }

        /// <summary>
        /// Removes all items from the inventory.
        /// </summary>
        public void Clear()
        {
            if (IsEmpty)
            {
                return;
            }

            foreach (InventorySlot slot in _slots)
            {
                slot.Clear();
            }

            OnInventoryChanged();
        }

        #endregion

        #region Query Methods

        /// <summary>
        /// Returns true if the inventory contains at least one of the specified item.
        /// </summary>
        public bool Contains(ItemDefinition definition)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

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
        /// Gets the total quantity of the specified item.
        /// </summary>
        public int GetItemCount(ItemDefinition definition)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            int count = 0;

            foreach (InventorySlot slot in _slots)
            {
                if (slot.Contains(definition))
                {
                    count += slot.Item.Quantity;
                }
            }

            return count;
        }

        /// <summary>
        /// Determines whether the inventory has enough space for the specified quantity.
        /// </summary>
        public bool HasSpaceFor(ItemDefinition definition, int quantity)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            if (quantity <= 0)
            {
                return true;
            }

            int remaining = quantity;

            foreach (InventorySlot slot in _slots)
            {
                if (slot.CanStack(definition))
                {
                    remaining -= slot.RemainingCapacity;
                }
                else if (slot.IsEmpty)
                {
                    remaining -= definition.MaxStackSize;
                }

                if (remaining <= 0)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region State Methods

        /// <summary>
        /// Returns true if the inventory contains no empty slots.
        /// </summary>
        public bool IsFull()
        {
            return FindFirstEmptySlot() == null;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Raises the InventoryChanged event.
        /// </summary>
        protected virtual void OnInventoryChanged()
        {
            InventoryChanged?.Invoke(this, InventoryChangedEventArgs.Empty);
        }

        #endregion
    }
}