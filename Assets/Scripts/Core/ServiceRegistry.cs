using System;
using System.Collections.Generic;
using UnityEngine;
using LifeVerse.Core.Services;

namespace LifeVerse.Core
{
    /// <summary>
    /// Stores and manages engine services.
    /// </summary>
    public static class ServiceRegistry
    {
        private static readonly Dictionary<Type, object> Services = new();

        private static readonly List<IUpdatableService> UpdatableServices = new();

        private static readonly List<IFixedUpdatableService> FixedUpdatableServices = new();

        private static readonly List<ILateUpdatableService> LateUpdatableServices = new();

        public static void Register<T>(T service)
            where T : class
        {
            Type type = typeof(T);

            if (Services.ContainsKey(type))
            {
                Debug.LogWarning($"Service already registered: {type.Name}");
                return;
            }

            Services.Add(type, service);

            if (service is IUpdatableService update)
                UpdatableServices.Add(update);

            if (service is IFixedUpdatableService fixedUpdate)
                FixedUpdatableServices.Add(fixedUpdate);

            if (service is ILateUpdatableService lateUpdate)
                LateUpdatableServices.Add(lateUpdate);

            Debug.Log($"Registered Service: {type.Name}");
        }

        public static T Get<T>()
            where T : class
        {
            if (Services.TryGetValue(typeof(T), out object service))
                return service as T;

            Debug.LogError($"Service not found: {typeof(T).Name}");
            return null;
        }

        public static bool Has<T>()
            where T : class
        {
            return Services.ContainsKey(typeof(T));
        }

        public static void UpdateServices(float deltaTime)
        {
            foreach (IUpdatableService service in UpdatableServices)
            {
                service.Update(deltaTime);
            }
        }

        public static void FixedUpdateServices(float fixedDeltaTime)
        {
            foreach (IFixedUpdatableService service in FixedUpdatableServices)
            {
                service.FixedUpdate(fixedDeltaTime);
            }
        }

        public static void LateUpdateServices(float deltaTime)
        {
            foreach (ILateUpdatableService service in LateUpdatableServices)
            {
                service.LateUpdate(deltaTime);
            }
        }

        public static void Clear()
        {
            Services.Clear();
            UpdatableServices.Clear();
            FixedUpdatableServices.Clear();
            LateUpdatableServices.Clear();

            Debug.Log("Service Registry Cleared");
        }
    }
}