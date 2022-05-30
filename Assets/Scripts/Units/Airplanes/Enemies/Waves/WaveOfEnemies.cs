using UnityEngine;

namespace Units.Airplanes.Enemies.Waves
{
    [CreateAssetMenu(fileName = "WaveOfEnemies", menuName = "Spawn/Enemies/Wave")]
    internal class WaveOfEnemies: ScriptableObject
    {
        [SerializeField] private SpawnPoint[] points;
        [SerializeField] private float timeToStart;
        public float TimeToStart => timeToStart;
    

        public void Spawn(IPoolGetter<Enemy> poolGetter)
        {
            foreach (var point in points)
            {
                poolGetter.Spawn(point.Enemy.GetType(), point.Position, Quaternion.identity);
            }
        }
    }
}