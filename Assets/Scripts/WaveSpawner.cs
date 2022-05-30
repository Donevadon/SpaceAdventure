using System.Collections;
using UnityEngine;
using Zenject;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveOfEnemies[] waves;
    private IPoolGetter<Enemy> _getter;

    [Inject]
    private void Init(IPoolGetter<Enemy> getter)
    {
        _getter = getter;
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
            wave.Spawn(_getter);
        }
    }
}