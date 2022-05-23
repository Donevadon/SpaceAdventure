using System;
using System.Collections;
using UnityEngine;

internal class EnemyController : IController
{
    private const float Error = 0.4f;

    private readonly MonoBehaviour _monoBehaviour;
    private readonly Vector2 _from;
    private readonly Vector2[] _to;
    private readonly Action _callback;
    public event Func<Vector2> LeftPressed;
    public event Func<Vector2> RightPressed;
    public event Action RotationCanceled;
    public event Func<Vector2> UpPressed;
    public event Action UpCanceled;
    public event Func<Vector2> DownPressed;
    public event Action DownCanceled;

    public EnemyController(MonoBehaviour monoBehaviour, Vector2 from, Vector2[] to, Action callback)
    {
        _monoBehaviour = monoBehaviour;
        _from = from;
        _to = to;
        _callback = callback;
    }

    private bool IsLeft(Vector2 from, Vector2 to) => (from.x < to.x + Error) && (from.x < to.x - Error) ;
    private bool IsRight(Vector2 from, Vector2 to) => (from.x > to.x + Error) && (from.x > to.x - Error);
    private bool IsDown(Vector2 from, Vector2 to) => (from.y > to.y + Error) && (from.y > to.y - Error);
    private bool IsUp(Vector2 from, Vector2 to) => (from.y < to.y + Error) && (from.y < to.y - Error);

    private IEnumerator StartMove()
    {
        var current = _from;
        foreach (var to in _to)
        {
            while (!current.Equals(to, Error))
            {
                if (IsLeft(current, to))
                {
                    current = LeftPressed!.Invoke();
                }else if (IsRight(current, to))
                {
                    current = RightPressed!.Invoke();
                }

                if (IsDown(current, to))
                {
                    current = DownPressed!.Invoke();
                }else if(IsUp(current, to))
                {
                    current = UpPressed!.Invoke();
                }

                yield return new WaitForFixedUpdate();
            }
            UpCanceled!.Invoke();
            DownCanceled!.Invoke();
            RotationCanceled!.Invoke();
        }

        _callback?.Invoke();
    }

    public void Start()
    {
        _monoBehaviour.StartCoroutine(StartMove());
    }
}