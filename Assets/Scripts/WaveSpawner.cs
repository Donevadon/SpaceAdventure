using System.Collections;
using UnityEngine;
using Zenject;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveOfEnemies[] waves;
    private IEnemyPoolGetter _enemyGetter;

    [Inject]
    private void Init(IEnemyPoolGetter enemyGetter)
    {
        _enemyGetter = enemyGetter;
    }
    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        foreach (var wave in waves)
        {
            yield return new WaitForSeconds(wave.TimeToStart);
            wave.Spawn(_enemyGetter);
        }
    }
}