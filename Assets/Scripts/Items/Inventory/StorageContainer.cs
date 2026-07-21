using System;
using UnityEngine;

namespace LifeVerse.Items.Inventory
{
    /// <summary>
    /// Represents a world object capable of storing items.
    /// </summary>
    public class StorageContainer : MonoBehaviour
    {
        [Header("Storage")]

        [SerializeField]
        [Min(1)]
        private int _capacity = 20;

        /// <summary>
        /// Gets the inventory owned by this container.
        /// </summary>
        public Inventory Inventory { get; private set; }

        /// <summary>
        /// Gets the maximum number of slots.
        /// </summary>
        public int Capacity => _capacity;

        /// <summary>
        /// Raised when the container is opened.
        /// </summary>
        public event Action Opened;

        /// <summary>
        /// Raised when the container is closed.
        /// </summary>
        public event Action Closed;

        /// <summary>
        /// Returns whether this container is currently open.
        /// </summary>
        public bool IsOpen { get; private set; }

        private void Awake()
        {
            Inventory = new Inventory(_capacity);
        }

        /// <summary>
        /// Opens the container.
        /// </summary>
        public virtual void Open()
        {
            if (IsOpen)
            {
                return;
            }

            IsOpen = true;
            Opened?.Invoke();
        }

        /// <summary>
        /// Closes the container.
        /// </summary>
        public virtual void Close()
        {
            if (!IsOpen)
            {
                return;
            }

            IsOpen = false;
            Closed?.Invoke();
        }
    }
}