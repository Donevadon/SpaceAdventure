using System;
using System.Linq;
using Controllers;
using MoveBehaviors;
using UnityEngine;
using Zenject;

namespace Units.Airplanes.Enemies
{
    public abstract class Enemy : Airplane
    {
        [SerializeField] private Vector2[] positions;

        private EnemyController _control;
        private IPoolSetter<Enemy> _poolSetter;

        [Inject]
        private void Init(IPoolSetter<Enemy> poolSetter)
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

        protected override IMoveBehavior GetStartMoveBehavior()
        {
            return new First(transform);
        }
    }
}