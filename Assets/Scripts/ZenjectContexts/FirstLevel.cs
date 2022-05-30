using Units.Airplanes.Enemies.Waves;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace ZenjectContexts
{
    public class FirstLevel : MonoInstaller
    {
        [SerializeField] private WaveSpawner spawner;
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.InstantiatePrefab(spawner);
        }
    }
}
