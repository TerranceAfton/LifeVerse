using UnityEngine;

using LifeVerse.UI.Core;

public class UITest : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            _uiManager.Open(UIWindowType.Sleep);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            _uiManager.Close(UIWindowType.Sleep);
        }
    }
}