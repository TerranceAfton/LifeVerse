using UnityEngine;

namespace LifeVerse.UI.Core
{
    /// <summary>
    /// Base class for reusable UI elements.
    /// </summary>
    public abstract class UIElement : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public bool IsVisible => gameObject.activeSelf;
    }
}