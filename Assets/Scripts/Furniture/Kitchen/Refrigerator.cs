using UnityEngine;
using LifeVerse.Furniture.Base;

namespace LifeVerse.Furniture.Kitchen
{
    /// <summary>
    /// Simple refrigerator interaction.
    /// </summary>
    public class Refrigerator : ApplianceInteractable
    {
        private bool _isOpen;

        private void Reset()
        {
            interactionName = "Open Refrigerator";
        }

        public override void Interact(GameObject interactor)
        {
            _isOpen = !_isOpen;

            if (_isOpen)
            {
                interactionName = "Close Refrigerator";
                Debug.Log("Refrigerator opened.");
            }
            else
            {
                interactionName = "Open Refrigerator";
                Debug.Log("Refrigerator closed.");
            }
        }
    }
}