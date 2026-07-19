using System;
using LifeVerse.Items.Data;

namespace LifeVerse.Items.Inventory
{
    /// <summary>
    /// Represents a single slot within an inventory container.
    /// </summary>
    [Serializable]
    public class InventorySlot
    {
        /// <summary>
        /// Gets the item stored in this slot.
        /// </summary>
        public InventoryItem Item { get; private set; }

        /// <summary>
        /// Returns true if this slot contains no item.
        /// </summary>
        public bool IsEmpty => Item == null || Item.IsEmpty;

        /// <summary>
        /// Gets the remaining capacity of this slot.
        /// </summary>
        public int RemainingCapacity
        {
            get
            {
                if (IsEmpty)
                {
                    return 0;
                }

                return Item.Definition.MaxStackSize - Item.Quantity;
            }
        }

        public InventorySlot()
        {
            Item = null;
        }

        /// <summary>
        /// Places an item into this slot.
        /// </summary>
        public void SetItem(InventoryItem item)
        {
            Item = item;
        }

        /// <summary>
        /// Removes the item from this slot.
        /// </summary>
        public void Clear()
        {
            Item = null;
        }

        /// <summary>
        /// Returns true if this slot contains the specified item definition.
        /// </summary>
        public bool Contains(ItemDefinition definition)
        {
            return !IsEmpty &&
                   Item.Definition == definition;
        }

        /// <summary>
        /// Returns true if this slot can stack more of the specified item.
        /// </summary>
        public bool CanStack(ItemDefinition definition)
        {
            return Contains(definition) &&
                   RemainingCapacity > 0;
        }

        /// <summary>
        /// Returns true if this slot can accept the specified item.
        /// </summary>
        public bool CanAccept(ItemDefinition definition)
        {
            return IsEmpty || CanStack(definition);
        }
    }
}