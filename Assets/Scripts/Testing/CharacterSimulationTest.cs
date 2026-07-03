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
    }

    private void Update()
    {
        if (_character == null)
            return;

        _timer += Time.deltaTime;

        if (_timer < 1f)
            return;

        _timer = 0f;

        Debug.Log("--------------------------------");

        // Debug.Log($"Hunger: {_character.Needs.GetValue(NeedType.Hunger):F1}");
        // Debug.Log($"Energy: {_character.Needs.GetValue(NeedType.Energy):F1}");
        // Debug.Log($"Fun: {_character.Needs.GetValue(NeedType.Fun):F1}");
        // Debug.Log($"Social: {_character.Needs.GetValue(NeedType.Social):F1}");
    }
}
// Debug.Log($"Created Character: {_character.Profile.Name.FullName}");