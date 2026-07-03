using LifeVerse.Core.Configuration;
using LifeVerse.Core.Logging;
using LifeVerse.Core.SceneManagement;
using LifeVerse.Core.Services;
using LifeVerse.Input;
using LifeVerse.Time;
using LifeVerse.Simulation;
using LifeVerse.Characters;

namespace LifeVerse.Core
{
    /// <summary>
    /// Creates and registers all engine services.
    /// </summary>
    public static class ServiceInitializer
    {
        public static void Initialize()
        {
            RegisterService(new LoggingManager());

            RegisterService(new ConfigurationManager());

            RegisterService(new SceneService());

            RegisterService(new InputService());

            RegisterService(new TimeService());

            // Register CharacterManager FIRST
            RegisterService(new CharacterManager());

            // Then SimulationManager
            RegisterService(new SimulationManager());

            ServiceRegistry
                .Get<LoggingManager>()
                .Log("Core services initialized.");
        }

        private static void RegisterService<T>(T service)
            where T : class, IGameService
        {
            service.Initialize();
            ServiceRegistry.Register(service);
        }

        public static void Shutdown()
        {
            if (ServiceRegistry.Has<CharacterManager>())
            {
                ServiceRegistry.Get<CharacterManager>().Shutdown();
            }

            if (ServiceRegistry.Has<SimulationManager>())
            {
                ServiceRegistry.Get<SimulationManager>().Shutdown();
            }

            if (ServiceRegistry.Has<TimeService>())
            {
                ServiceRegistry.Get<TimeService>().Shutdown();
            }

            if (ServiceRegistry.Has<InputService>())
            {
                ServiceRegistry.Get<InputService>().Shutdown();
            }

            if (ServiceRegistry.Has<SceneService>())
            {
                ServiceRegistry.Get<SceneService>().Shutdown();
            }

            if (ServiceRegistry.Has<ConfigurationManager>())
            {
                ServiceRegistry.Get<ConfigurationManager>().Shutdown();
            }

            if (ServiceRegistry.Has<LoggingManager>())
            {
                ServiceRegistry.Get<LoggingManager>().Shutdown();
            }
        }
    }
}