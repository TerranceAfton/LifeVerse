using UnityEngine;
using LifeVerse.Interaction.Interfaces;
using LifeVerse.Characters;

namespace LifeVerse.Furniture.Beds
{
    /// <summary>
    /// Allows the player to sleep in a bed.
    /// </summary>
    public class BedInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Transform _sleepPoint;

        private bool _isSleeping;

        public string InteractionName =>
            _isSleeping ? "Wake Up" : "Sleep";

        public bool CanInteract()
        {
            return true;
        }

        public void Interact(GameObject interactor)
        {
            if (_sleepPoint == null)
            {
                Debug.LogError("SleepPoint has not been assigned!");
                return;
            }

            CharacterInteractionController interaction =
                interactor.GetComponent<CharacterInteractionController>();

            if (interaction == null)
            {
                Debug.LogError("CharacterInteractionController not found!");
                return;
            }

            if (_isSleeping)
            {
                interaction.WakeUp();
            }
            else
            {
                interaction.Sleep(_sleepPoint);
            }

            _isSleeping = !_isSleeping;
        }
    }
}