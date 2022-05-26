using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SpawnPoint", menuName = "Spawn/SpawnPoint")]
internal class SpawnPoint : ScriptableObject
{
    [FormerlySerializedAs("GameObject")] public Enemy Enemy;
    public Vector3 Position;
}