using System;
using System.Collections.Generic;
using UnityEngine;

namespace LifeVerse.Core
{
    /// <summary>
    /// Global event system.
    /// </summary>
    public static class EventBus
    {
        private static readonly Dictionary<Type, Delegate> Events = new();

        public static void Subscribe<T>(Action<T> listener)
        {
            Type type = typeof(T);

            if (Events.TryGetValue(type, out Delegate existing))
            {
                Events[type] = Delegate.Combine(existing, listener);
            }
            else
            {
                Events[type] = listener;
            }
        }

        public static void Unsubscribe<T>(Action<T> listener)
        {
            Type type = typeof(T);

            if (!Events.TryGetValue(type, out Delegate existing))
                return;

            Delegate current = Delegate.Remove(existing, listener);

            if (current == null)
                Events.Remove(type);
            else
                Events[type] = current;
        }

        public static void Publish<T>(T eventData)
        {
            Type type = typeof(T);

            if (Events.TryGetValue(type, out Delegate existing))
            {
                ((Action<T>)existing)?.Invoke(eventData);
            }
        }

        public static void Clear()
        {
            Events.Clear();

            Debug.Log("EventBus Cleared");
        }
    }
}