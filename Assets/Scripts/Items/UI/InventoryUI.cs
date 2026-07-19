using System.Collections.Generic;
using UnityEngine;
using LifeVerse.Characters.Components;
using LifeVerse.Items.Events;

namespace LifeVerse.Items.UI
{
    /// <summary>
    /// Displays the player's inventory.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class InventoryUI : MonoBehaviour
    {
        [Header("References")]

        [SerializeField]
        private PlayerInventory _playerInventory;

        [SerializeField]
        private InventorySlotUI _slotPrefab;

        [SerializeField]
        private Transform _slotContainer;

        private readonly List<InventorySlotUI> _slotUIs = new();

        private void Awake()
        {
            CreateSlots();
        }

        private void OnEnable()
        {
            if (_playerInventory != null)
            {
                _playerInventory.Inventory.InventoryChanged += OnInventoryChanged;
            }

            Refresh();
        }

        private void OnDisable()
        {
            if (_playerInventory != null)
            {
                _playerInventory.Inventory.InventoryChanged -= OnInventoryChanged;
            }
        }

        private void OnInventoryChanged(
            object sender,
            InventoryChangedEventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// Creates the slot UI objects.
        /// </summary>
        private void CreateSlots()
        {
            if (_playerInventory == null ||
                _slotPrefab == null ||
                _slotContainer == null)
            {
                return;
            }

            foreach (InventorySlotUI slotUI in _slotUIs)
            {
                if (slotUI != null)
                {
                    Destroy(slotUI.gameObject);
                }
            }

            _slotUIs.Clear();

            for (int i = 0; i < _playerInventory.Inventory.SlotCount; i++)
            {
                InventorySlotUI slot =
                    Instantiate(_slotPrefab, _slotContainer);

                _slotUIs.Add(slot);
            }
        }

        /// <summary>
        /// Refreshes the inventory display.
        /// </summary>
        public void Refresh()
        {
            if (_playerInventory == null)
            {
                return;
            }

            for (int i = 0; i < _slotUIs.Count; i++)
            {
                _slotUIs[i].Bind(
                    _playerInventory.Inventory.Slots[i]);
            }
        }
    }
}