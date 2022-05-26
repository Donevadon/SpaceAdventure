using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class EnemyPool : IEnemyPoolGetter, IEnemyPoolSetter
{
    private readonly DiContainer _container;
    private Dictionary<Type, Queue<GameObject>> _queue;
    private Dictionary<Type, Enemy> _proto;

    public EnemyPool(DiContainer container)
    {
        _container = container;
        _queue = new Dictionary<Type, Queue<GameObject>>();
        _proto = new Dictionary<Type, Enemy>();
        var enemies = Resources.LoadAll<Enemy>("Enemies");
        foreach (var enemy in enemies)
        {
            var type = enemy.GetType();
            _queue.Add(type, new Queue<GameObject>());
            _proto.Add(type, enemy);
        }
    }
    
    public void Spawn(Type proto, Vector3 pointPosition, Quaternion identity)
    {
        
        if (_queue[proto].TryDequeue(out var enemy))
        {
            enemy.transform.position = pointPosition;
            enemy.transform.rotation = identity;
            enemy.SetActive(true);
        }
        else
        {
            _container.InstantiatePrefab(_proto[proto], pointPosition, identity, null);
        }
    }

    public void Set<T>(T enemy) where T : Enemy
    {
        _queue[enemy.GetType()].Enqueue(enemy.gameObject);
    }
}