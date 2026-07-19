using System;
using UnityEngine;
using LifeVerse.Items.Data;

namespace LifeVerse.Items.World
{
    /// <summary>
    /// Represents a physical item that exists in the game world.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class WorldItem : MonoBehaviour
    {
        [Header("Item")]

        [SerializeField]
        private ItemDefinition _definition;

        [SerializeField]
        [Min(1)]
        private int _quantity = 1;

        /// <summary>
        /// Gets the item's definition.
        /// </summary>
        public ItemDefinition Definition => _definition;

        /// <summary>
        /// Gets the quantity represented by this world item.
        /// </summary>
        public int Quantity => _quantity;

        /// <summary>
        /// Initializes this world item.
        /// Useful when spawning items at runtime.
        /// </summary>
        public void Initialize(ItemDefinition definition, int quantity)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            _definition = definition;
            _quantity = Mathf.Max(1, quantity);
        }
    }
}