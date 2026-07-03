using UnityEngine;

namespace LifeVerse.Input
{
    public readonly struct MoveInputEvent
    {
        public readonly Vector2 Value;

        public MoveInputEvent(Vector2 value)
        {
            Value = value;
        }
    }

    public readonly struct PausePressedEvent
    {
    }

    public readonly struct InteractPressedEvent
    {
    }
}