using System;
using System.Collections.Generic;
using System.Linq;
using Units;
using Units.Airplanes.Enemies;
using UnityEngine;
using Zenject;

namespace Pool
{
    public class PrefabPool<T> : IPoolGetter<T>, IPoolSetter<T> where T : MonoBehaviour
    {
        private readonly DiContainer _container;
        private Dictionary<Type, Queue<GameObject>> _queue;
        private Dictionary<Type, GameObject> _proto;

        public PrefabPool(DiContainer container)
        {
            _container = container;

            var objects = Resources.LoadAll<T>(typeof(T).Name);
            _proto = objects.ToDictionary(item => item.GetType(), item => item.gameObject);
            _queue = objects.ToDictionary(item => item.GetType(), _ => new Queue<GameObject>());
        }
    
        public T Spawn(Type proto, Vector3 pointPosition, Quaternion identity)
        {
            if (_queue[proto].TryDequeue(out var gm))
            {
                gm.transform.position = pointPosition;
                gm.transform.rotation = identity;
                gm.SetActive(true);
            }
            else
            {
                gm = _container.InstantiatePrefab(_proto[proto], pointPosition, identity, null);
            }

            return gm.GetComponent<T>();
        }

        public void Set(T enemy)
        {
            _queue[enemy.GetType()].Enqueue(enemy.gameObject);
        }
    }
}