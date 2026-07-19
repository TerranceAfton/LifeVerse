using UnityEngine;

namespace LifeVerse.Items.Data
{
    /// <summary>
    /// Defines an item that can exist in the world or an inventory.
    /// </summary>
    [CreateAssetMenu(
        fileName = "New Item",
        menuName = "LifeVerse/Items/Item Definition")]
    public class ItemDefinition : ScriptableObject
    {
        [Header("Identification")]

        [SerializeField]
        private string _id;

        [SerializeField]
        private string _displayName;

        [SerializeField]
        [TextArea]
        private string _description;

        [Header("Classification")]

        [SerializeField]
        private ItemCategory _category;

        [SerializeField]
        private ItemTag _tags;

        [Header("Appearance")]

        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private GameObject _worldPrefab;

        [Header("Gameplay")]

        [SerializeField]
        [Min(1)]
        private int _maxStackSize = 1;

        [SerializeField]
        [Min(0)]
        private int _value = 0;

        [SerializeField]
        [Min(0f)]
        private float _weight = 0f;

        public string Id => _id;
        public string DisplayName => _displayName;
        public string Description => _description;

        public ItemCategory Category => _category;
        public ItemTag Tags => _tags;

        public Sprite Icon => _icon;
        public GameObject WorldPrefab => _worldPrefab;

        public int MaxStackSize => _maxStackSize;
        public int Value => _value;
        public float Weight => _weight;
    }
}