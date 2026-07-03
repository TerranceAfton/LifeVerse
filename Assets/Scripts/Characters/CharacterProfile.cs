using System;

namespace LifeVerse.Characters
{
    /// <summary>
    /// Stores a character's identity information.
    /// </summary>
    [Serializable]
    public class CharacterProfile
    {
        public CharacterName Name { get; set; }

        public CharacterAge Age { get; set; }

        public CharacterGender Gender { get; set; }

        public DateTime Birthday { get; set; }

        public string Biography { get; set; }

        public CharacterProfile()
        {
            Name = new CharacterName();
            Age = CharacterAge.YoungAdult;
            Gender = CharacterGender.Custom;
            Birthday = DateTime.Today;
            Biography = string.Empty;
        }

        public CharacterProfile(
            CharacterName name,
            CharacterAge age,
            CharacterGender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Birthday = DateTime.Today;
            Biography = string.Empty;
        }
    }
}