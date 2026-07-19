using System;

namespace LifeVerse.Items.Data
{
    /// <summary>
    /// Represents a runtime stack of items.
    /// </summary>
    [Serializable]
    public class InventoryItem
    {
        /// <summary>
        /// Gets the item definition for this stack.
        /// </summary>
        public ItemDefinition Definition { get; }

        /// <summary>
        /// Gets the current quantity in the stack.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Returns true if this stack contains no items.
        /// </summary>
        public bool IsEmpty => Quantity <= 0;

        /// <summary>
        /// Creates a new inventory item stack.
        /// </summary>
        public InventoryItem(ItemDefinition definition, int quantity)
        {
            Definition = definition ?? throw new ArgumentNullException(nameof(definition));

            Quantity = Math.Clamp(
                quantity,
                0,
                definition.MaxStackSize);
        }

        /// <summary>
        /// Adds items to the stack.
        /// </summary>
        public void Add(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            Quantity = Math.Min(
                Quantity + amount,
                Definition.MaxStackSize);
        }

        /// <summary>
        /// Removes items from the stack.
        /// </summary>
        public void Remove(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            Quantity = Math.Max(
                Quantity - amount,
                0);
        }
    }
}