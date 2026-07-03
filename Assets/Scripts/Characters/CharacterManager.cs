using System.Collections.Generic;
using UnityEngine;

using LifeVerse.Core.Services;

namespace LifeVerse.Characters
{
    /// <summary>
    /// Creates and manages all characters.
    /// </summary>
    public class CharacterManager : IGameService
    {
        private readonly Dictionary<CharacterId, Character> _characters = new();

        public IReadOnlyCollection<Character> Characters =>
            _characters.Values;

        public void Initialize()
        {
            Debug.Log("CharacterManager Initialized");
        }

        public void Shutdown()
        {
            _characters.Clear();

            Debug.Log("CharacterManager Shutdown");
        }

        public Character CreateCharacter(
            CharacterProfile profile)
        {
            Character character = new(profile);

            _characters.Add(character.Id, character);

            Debug.Log($"Created Character: {character.Profile.Name.FullName}");
            Debug.Log($"Total Characters: {_characters.Count}");

            return character;
        }

        public bool RemoveCharacter(CharacterId id)
        {
            return _characters.Remove(id);
        }

        public Character GetCharacter(CharacterId id)
        {
            _characters.TryGetValue(id, out Character character);

            return character;
        }

        public int CharacterCount => _characters.Count;
    }
}