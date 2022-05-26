using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class Enemy : Airplane
{
    [SerializeField] private Vector2[] positions;

    private EnemyController _control;
    private IEnemyPoolSetter _poolSetter;

    [Inject]
    private void Init(IEnemyPoolSetter poolSetter)
    {
        _poolSetter = poolSetter;
    }

    protected override IController GetController()
    {
        _control = new EnemyController(this, transform.position,
            positions.Select(item => item)
                .ToArray(),
            () =>
            {
                gameObject.SetActive(false);
                _poolSetter.Set(this);
            });

        return _control;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _control.Start();
    }

    public void StartMove()
    {
        _control.Start();
    }

    protected override IGunBehavior GetStartGunBehavior()
    {
        return new DisabledWeapon();
    }

    protected override IMoveBehavior GetStartMoveBehavior()
    {
        return new First(transform);
    }
}

internal interface IEnemyPoolSetter
{
    void Set<T>(T enemy) where T: Enemy;
}

public static class Extentions
{
    public static bool Equals(this Vector2 vector, Vector2 vector2, float error)
    {
        var x = vector.x;
        var y = vector.y;
        var x2 = vector2.x;
        var y2 = vector2.y;
        return x > x2 - error 
               && x < x2 + error 
               && y > y2 - error 
               && y < y2 + error;
    }
}