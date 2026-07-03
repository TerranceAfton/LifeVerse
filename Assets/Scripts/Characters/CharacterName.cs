using System;

namespace LifeVerse.Characters
{
    [Serializable]
    public class CharacterName
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PreferredName { get; set; }

        public string FullName
        {
            get
            {
                string first = string.IsNullOrWhiteSpace(PreferredName)
                    ? FirstName
                    : PreferredName;

                if (string.IsNullOrWhiteSpace(MiddleName))
                    return $"{first} {LastName}";

                return $"{first} {MiddleName} {LastName}";
            }
        }

        public CharacterName()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
            PreferredName = "";
        }

        public CharacterName(string first, string last)
        {
            FirstName = first;
            LastName = last;

            MiddleName = "";
            PreferredName = "";
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}