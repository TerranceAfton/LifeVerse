using System;

namespace LifeVerse.Items.Data
{
    /// <summary>
    /// Additional descriptors that define item behavior.
    /// </summary>
    [Flags]
    public enum ItemTag
    {
        None = 0,

        Consumable = 1 << 0,

        Stackable = 1 << 1,

        Readable = 1 << 2,

        Equipable = 1 << 3,

        Cookable = 1 << 4,

        Craftable = 1 << 5,

        Sellable = 1 << 6,

        Tradable = 1 << 7,

        Placeable = 1 << 8,

        QuestItem = 1 << 9,

        Perishable = 1 << 10
    }
}