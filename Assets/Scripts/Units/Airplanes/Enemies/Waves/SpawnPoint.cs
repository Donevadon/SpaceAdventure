using UnityEngine;

namespace Units.Airplanes.Enemies.Waves
{
    [CreateAssetMenu(fileName = "SpawnPoint", menuName = "Spawn/SpawnPoint")]
    internal class SpawnPoint : ScriptableObject
    {
        public Enemy Enemy;
        public Vector3 Position;
    }
}