using UnityEngine;
using LifeVerse.Items.UI;
using LifeVerse.UI.Core;

namespace LifeVerse.UI.Windows
{
    /// <summary>
    /// Controls the Inventory window.
    /// </summary>
    public sealed class InventoryWindow : UIWindow
    {
        [SerializeField]
        private InventoryUI _inventoryUI;

        public override void Open()
        {
            base.Open();

            if (_inventoryUI != null)
            {
                _inventoryUI.Refresh();
            }
        }
    }
}