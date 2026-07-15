using UnityEngine;

using LifeVerse.Core;
using LifeVerse.Characters;
using LifeVerse.Characters.Components.Needs;

public class CharacterSimulationTest : MonoBehaviour
{
    private Character _character;

    private float _timer;

    private void Start()
    {
        CharacterManager manager =
            ServiceRegistry.Get<CharacterManager>();

        if (manager == null)
        {
            Debug.LogError("CharacterManager not found.");
            return;
        }

        CharacterProfile profile = new CharacterProfile(
            new CharacterName("Alex", "Walker"),
            CharacterAge.YoungAdult,
            CharacterGender.Male);

        _character = manager.CreateCharacter(profile);

        CharacterReference characterReference =
            FindFirstObjectByType<CharacterReference>();

        if (characterReference == null)
        {
            Debug.LogError("CharacterReference not found.");
            return;
        }

        characterReference.Initialize(_character);
    }

    private void Update()
    {
        if (_character == null)
            return;

        _timer += Time.deltaTime;

        if (_timer < 1f)
            return;

        _timer = 0f;

        Debug.Log(
            $"Energy: {_character.Needs.GetValue(NeedType.Energy):F1} | " +
            $"Hunger: {_character.Needs.GetValue(NeedType.Hunger):F1}");
    }
}