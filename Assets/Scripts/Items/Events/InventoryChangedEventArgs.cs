using System;

namespace LifeVerse.Items.Events
{
    /// <summary>
    /// Provides data for inventory change events.
    /// </summary>
    public sealed class InventoryChangedEventArgs : EventArgs
    {
        public static readonly InventoryChangedEventArgs Empty = new();

        private InventoryChangedEventArgs()
        {
        }
    }
}