using System;

namespace LifeVerse.UI.Prompts
{
    /// <summary>
    /// Data displayed by an interaction prompt.
    /// </summary>
    [Serializable]
    public class PromptData
    {
        /// <summary>
        /// Button the player should press.
        /// </summary>
        public string Input = "E";

        /// <summary>
        /// Action being performed.
        /// </summary>
        public string Action = "Interact";

        public PromptData()
        {
        }

        public PromptData(string input, string action)
        {
            Input = input;
            Action = action;
        }
    }
}