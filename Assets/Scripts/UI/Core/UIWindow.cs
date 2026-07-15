using UnityEngine;

namespace LifeVerse.UI.Core
{
    /// <summary>
    /// Base class for all game windows.
    /// </summary>
    public abstract class UIWindow : UIElement
    {
        [SerializeField]
        private UIWindowType _windowType;

        public UIWindowType WindowType => _windowType;

        public virtual void Open()
        {
            Show();
        }

        public virtual void Close()
        {
            Hide();
        }

        public virtual void Refresh()
        {
        }
    }
}