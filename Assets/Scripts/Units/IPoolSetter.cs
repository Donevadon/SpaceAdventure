using UnityEngine;

namespace Units
{
    internal interface IPoolSetter<in T> where T : MonoBehaviour
    {
        void Set(T enemy);
    }
}