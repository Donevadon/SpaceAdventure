using System;
using UnityEngine;

internal class Bullet : MonoBehaviour
{
    public Transform IgnoreTransform { get; set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == IgnoreTransform)
            return;
        
        if (other.TryGetComponent<ITakingDamage>(out var item))
        {
            item.ToDamage(14.5f);
        }
        Destroy(gameObject);
    }
}

internal interface ITakingDamage
{
    void ToDamage(float f);
}