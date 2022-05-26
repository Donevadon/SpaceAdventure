using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public abstract class Airplane : MonoBehaviour, ITakingDamage
{
    [SerializeField] private float hp;
    [SerializeField] private float speed;
    private IMoveBehavior _moveBehavior;
    private IGunBehavior _gunBehavior;
    private IRotateBehavior _rotateBehavior;
    private IController _controller;

    private float Hp
    {
        get => hp;
        set
        {
            hp = value;
            if (hp <= 0)
            {
                Dead();
            }
        }
    }

    private void ControllerSubscribe()
    {
        _controller.LeftPressed += OnLeftPressed;
        _controller.RightPressed += OnRightPressed;
        _controller.RotationCanceled += OnRotationCanceled;
        _controller.UpPressed += OnUpPressed;
        _controller.UpCanceled += OnUpCanceled;
        _controller.DownPressed += OnDownPressed;
        _controller.DownCanceled += OnDownCanceled;
    }
    
    private void Dead()
    {
        Destroy(gameObject);
    }

    [Inject]
    private void Init(IRotateBehavior rotateBehavior)
    {
        _rotateBehavior = rotateBehavior;
    }

    private void Awake()
    {
        _moveBehavior = GetStartMoveBehavior();
        _gunBehavior = GetStartGunBehavior();
        _controller = GetController();
        if(_controller != null)
            ControllerSubscribe();
        if(_rotateBehavior != null)
            _rotateBehavior.Transform = transform;
    }


    protected abstract IController GetController();

    protected abstract IGunBehavior GetStartGunBehavior();

    protected abstract IMoveBehavior GetStartMoveBehavior();

    protected virtual void OnEnable()
    {
        _gunBehavior?.Start(0.1f);
    }

    private void OnDisable()
    {
        
    }


    private void OnRotationCanceled()
    {
        _moveBehavior.RotationCanceled();
        //_rotateBehavior.Rotate(0, 0.5f);
    }

    private void OnDownCanceled()
    {
        
    }

    private Vector2 OnDownPressed()
    {
        _moveBehavior.Down(speed);
        return transform.position;
    }

    private void OnUpCanceled()
    {
        
    }

    private Vector2 OnUpPressed()
    {
        _moveBehavior.Up(speed);
        return transform.position;
    }

    private Vector2 OnRightPressed()
    {
        _moveBehavior.Right(speed);
        //_rotateBehavior.Rotate(40, 0.5f);
        return transform.position;
    }

    private Vector2 OnLeftPressed()
    {
        _moveBehavior.Left(speed);
        //_rotateBehavior.Rotate(-40, 0.5f);
        return transform.position;
    }

    public virtual void ToDamage(float d)
    {
        Hp -= d;
    }
}

public class FirstGun : IGunBehavior
{
    private readonly MonoBehaviour _monoBehaviour;
    private Coroutine _coroutine;
    public FirstGun(MonoBehaviour monoBehaviour)
    {
        _monoBehaviour = monoBehaviour;
    }
    public void Start(float frequency)
    {
        _coroutine = _monoBehaviour.StartCoroutine(StartFire(frequency));
    }

    IEnumerator StartFire(float frequency)
    {
        var proto = Resources.Load<Bullet>(nameof(Bullet));
        while (true)
        {
            var position = _monoBehaviour.transform.position;
            var bullet = Object.Instantiate(proto, position, Quaternion.identity);
            bullet.IgnoreTransform = _monoBehaviour.transform;
            bullet.transform.DOMove(new Vector3()
            {
                x = position.x,
                y = 30,
                z = position.z
            }, 2)
                .onComplete += () => Object.Destroy(bullet.gameObject);
            yield return new WaitForSeconds(frequency);
        }
    }
}

public interface IGunBehavior
{
    void Start(float frequency);
}