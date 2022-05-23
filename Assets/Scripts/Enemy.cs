using System.Linq;
using UnityEngine;

internal class Enemy : Airplane
{
    [SerializeField] private Transform[] positions;

    private EnemyController _control;

    protected override void Start()
    {
        base.Start();
        _control.Start();
    }

    protected override IController GetController()
    {
        _control = new EnemyController(this, transform.position,
            positions.Select(item => (Vector2) item.position)
                .ToArray(),
            () => Debug.Log("Дошёл"));

        return _control;
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