using System;
using UnityEngine;

namespace Units
{
    internal interface IPoolGetter<out T>
    {
        T Spawn(Type proto, Vector3 pointPosition, Quaternion identity);
    }
}