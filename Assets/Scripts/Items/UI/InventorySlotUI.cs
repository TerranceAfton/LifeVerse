using TMPro;
using UnityEngine;
using UnityEngine.UI;
using LifeVerse.Items.Inventory;

namespace LifeVerse.Items.UI
{
    /// <summary>
    /// Displays a single inventory slot.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class InventorySlotUI : MonoBehaviour
    {
        [Header("UI")]

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _quantityText;

        /// <summary>
        /// Updates the UI using the supplied inventory slot.
        /// </summary>
        public void Bind(InventorySlot slot)
        {
            if (slot == null || slot.IsEmpty)
            {
                ShowEmpty();
                return;
            }

            _icon.enabled = true;
            _icon.sprite = slot.Item.Definition.Icon;

            _quantityText.text =
                slot.Item.Quantity > 1
                    ? slot.Item.Quantity.ToString()
                    : string.Empty;
        }

        /// <summary>
        /// Displays an empty inventory slot.
        /// </summary>
        public void ShowEmpty()
        {
            _icon.enabled = false;
            _icon.sprite = null;

            _quantityText.text = string.Empty;
        }
    }
}