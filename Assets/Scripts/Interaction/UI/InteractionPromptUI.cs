using TMPro;
using UnityEngine;
using LifeVerse.Interaction.Components;

namespace LifeVerse.Interaction.UI
{
    /// <summary>
    /// Displays the interaction prompt when the player
    /// is near an interactable object.
    /// </summary>
    public class InteractionPromptUI : MonoBehaviour
    {
        [SerializeField]
        private InteractionDetector _detector;

        [SerializeField]
        private GameObject _promptRoot;

        [SerializeField]
        private TMP_Text _promptText;

        private void Update()
        {
            if (_detector == null)
                return;

            if (_detector.CurrentInteractable == null)
            {
                _promptRoot.SetActive(false);
                return;
            }

            _promptRoot.SetActive(true);

            _promptText.text =
                $"[E] {_detector.CurrentInteractable.InteractionName}";
        }
    }
}