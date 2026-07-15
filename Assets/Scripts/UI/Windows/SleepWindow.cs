using UnityEngine;

using LifeVerse.UI.Core;

namespace LifeVerse.UI.Windows
{
    /// <summary>
    /// The Sleep menu window.
    /// </summary>
    public class SleepWindow : UIWindow
    {
        public override void Open()
        {
            base.Open();

            Debug.Log("Sleep Window Opened");
        }

        public override void Close()
        {
            base.Close();

            Debug.Log("Sleep Window Closed");
        }

        public override void Refresh()
        {
            Debug.Log("Sleep Window Refreshed");
        }
    }
}