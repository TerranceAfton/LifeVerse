using LifeVerse.Characters;
using LifeVerse.Simulation.Systems.Needs;

using System.Collections.Generic;
using UnityEngine;

using LifeVerse.Core;
using LifeVerse.Core.Services;

namespace LifeVerse.Simulation
{
    /// <summary>
    /// Controls all gameplay simulation systems.
    /// </summary>
    public class SimulationManager :
        IGameService,
        IUpdatableService
    {
        private readonly List<ISimulationSystem> _systems = new();

        private readonly SimulationSettings _settings = new();

        private float _accumulator;

        public bool IsRunning => _settings.Enabled;

        public void Initialize()
        {
            CharacterManager characterManager =
                ServiceRegistry.Get<CharacterManager>();

            RegisterSystem(
                new NeedsSystem(characterManager));

            Debug.Log("SimulationManager Initialized");
        }

        public void Shutdown()
        {
            foreach (ISimulationSystem system in _systems)
            {
                system.Shutdown();
            }

            _systems.Clear();

            Debug.Log("SimulationManager Shutdown");
        }

        public void RegisterSystem(ISimulationSystem system)
        {
            if (_systems.Contains(system))
                return;

            system.Initialize();

            _systems.Add(system);

            Debug.Log($"Simulation System Registered: {system.GetType().Name}");
        }

        public void RemoveSystem(ISimulationSystem system)
        {
            if (!_systems.Contains(system))
                return;

            system.Shutdown();

            _systems.Remove(system);
        }

        public void Update(float deltaTime)
        {
            if (!_settings.Enabled)
                return;

            _accumulator += deltaTime * _settings.SpeedMultiplier;

            while (_accumulator >= SimulationTick.TickInterval)
            {
                _accumulator -= SimulationTick.TickInterval;

                TickSimulation();
            }
        }

        private void TickSimulation()
        {
            foreach (ISimulationSystem system in _systems)
            {
                system.Tick(SimulationTick.TickInterval);
            }

            EventBus.Publish(
                new SimulationTickEvent(
                    SimulationTick.TickInterval));
        }

        public void StartSimulation()
        {
            if (_settings.Enabled)
                return;

            _settings.Enabled = true;

            EventBus.Publish(
                new SimulationStartedEvent());
        }

        public void StopSimulation()
        {
            if (!_settings.Enabled)
                return;

            _settings.Enabled = false;

            EventBus.Publish(
                new SimulationStoppedEvent());
        }

        public void SetSpeed(float speed)
        {
            _settings.SpeedMultiplier = Mathf.Max(0f, speed);
        }
    }
}