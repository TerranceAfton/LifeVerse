using UnityEngine;

using LifeVerse.Core;
using LifeVerse.UI.Core;
using LifeVerse.Input;

namespace LifeVerse.UI.Controllers
{
    /// <summary>
    /// Controls the Inventory window.
    /// </summary>
    public sealed class InventoryUIController : MonoBehaviour
    {
        [SerializeField]
        private UIManager _uiManager;

        private void OnEnable()
        {
            EventBus.Subscribe<InventoryPressedEvent>(OnInventoryPressed);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<InventoryPressedEvent>(OnInventoryPressed);
        }

        private void OnInventoryPressed(InventoryPressedEvent e)
        {
            _uiManager.Open(UIWindowType.Inventory);
        }
    }
}