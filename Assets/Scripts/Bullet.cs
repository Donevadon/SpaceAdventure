using UnityEngine;

internal class Bullet : MonoBehaviour
{
    private Vector2 _direction = Vector2.zero;
    public Vector2 Direction
    {
        set => _direction = value.normalized;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
            return;
        
        if (other.TryGetComponent<ITakingDamage>(out var item))
        {
            item.ToDamage(14.5f);
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = transform.position + (Vector3)(_direction * Time.deltaTime * 100f);
    }
}

internal interface ITakingDamage
{
    void ToDamage(float f);
}