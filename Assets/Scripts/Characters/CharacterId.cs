using System;

namespace LifeVerse.Characters
{
    /// <summary>
    /// Unique identifier for every character.
    /// </summary>
    [Serializable]
    public readonly struct CharacterId : IEquatable<CharacterId>
    {
        public Guid Value { get; }

        public CharacterId(Guid value)
        {
            Value = value;
        }

        public static CharacterId Create()
        {
            return new CharacterId(Guid.NewGuid());
        }

        public bool Equals(CharacterId other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is CharacterId other &&
                   Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static bool operator ==(
            CharacterId left,
            CharacterId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            CharacterId left,
            CharacterId right)
        {
            return !left.Equals(right);
        }
    }
}