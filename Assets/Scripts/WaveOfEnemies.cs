using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "WaveOfEnemies", menuName = "Spawn/Enemies/Wave")]
internal class WaveOfEnemies: ScriptableObject
{
    [SerializeField] private SpawnPoint[] points;
    [SerializeField]private float timeToStart;
    public float TimeToStart => timeToStart;
    

    public void Spawn(IEnemyPoolGetter enemyPoolGetter)
    {
        foreach (var point in points)
        {
            enemyPoolGetter.Spawn(point.Enemy.GetType(), point.Position, Quaternion.identity);
        }
    }
}

internal interface IEnemyPoolGetter
{
    void Spawn(Type proto, Vector3 pointPosition, Quaternion identity);
}