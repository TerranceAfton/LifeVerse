using UnityEngine;
using LifeVerse.Furniture.Base;

namespace LifeVerse.Furniture.Chairs
{
    /// <summary>
    /// Standard chair interaction.
    /// </summary>
    public class ChairInteractable : SeatingInteractable
    {
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();

            if (_collider == null)
            {
                Debug.LogError("ChairInteractable requires a Collider!");
            }
        }

        private void Update()
        {
            if (_collider != null)
            {
                Debug.Log($"Chair collider enabled: {_collider.enabled}");
            }
        }
    }
}