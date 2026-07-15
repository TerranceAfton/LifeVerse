using System.Collections.Generic;
using UnityEngine;

namespace LifeVerse.UI.Core
{
    /// <summary>
    /// Controls all UI windows.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private List<UIWindow> _windows = new();

        private readonly Dictionary<UIWindowType, UIWindow> _windowLookup = new();

        private void Awake()
        {
            foreach (UIWindow window in _windows)
            {
                if (window == null)
                    continue;

                _windowLookup[window.WindowType] = window;

                window.Close();
            }
        }

        public void Open(UIWindowType type)
        {
            if (_windowLookup.TryGetValue(type, out UIWindow window))
            {
                window.Open();
            }
        }

        public void Close(UIWindowType type)
        {
            if (_windowLookup.TryGetValue(type, out UIWindow window))
            {
                window.Close();
            }
        }

        public void CloseAll()
        {
            foreach (UIWindow window in _windowLookup.Values)
            {
                window.Close();
            }
        }
    }
}