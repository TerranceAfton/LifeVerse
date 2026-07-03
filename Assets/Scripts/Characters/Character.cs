using LifeVerse.Characters.Components.Needs;
using System;

namespace LifeVerse.Characters
{
    /// <summary>
    /// Represents a character in the simulation.
    /// </summary>
    [Serializable]
    public class Character
    {
        public CharacterId Id { get; }

        public CharacterProfile Profile { get; }

        public CharacterState State { get; private set; }

        public Household Household { get; internal set; }

        public NeedsComponent Needs { get; }

        public Character(CharacterProfile profile)
        {
            Id = CharacterId.Create();

            Profile = profile;

            Needs = new NeedsComponent();

            State = CharacterState.Idle;
        }

        public void ChangeState(
            CharacterState newState)
        {
            State = newState;
        }

        public override string ToString()
        {
            return Profile.Name.FullName;
        }
    }
}