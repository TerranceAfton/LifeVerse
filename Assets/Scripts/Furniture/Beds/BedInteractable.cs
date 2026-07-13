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

        public string InteractionName => "Sleep";

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

            CharacterStateController stateController =
                interactor.GetComponent<CharacterStateController>();

            if (interaction == null || stateController == null)
            {
                Debug.LogError("Required character components not found!");
                return;
            }

            if (stateController.CurrentState == CharacterState.Sleeping)
            {
                interaction.WakeUp();
            }
            else
            {
                interaction.Sleep(_sleepPoint);
            }
        }
    }
}