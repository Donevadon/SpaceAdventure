using System;
using System.Data;
using DG.Tweening;
using Units.Airplanes;
using UnityEngine;

namespace RotateBehaviors
{
    public class DOTweenRotation : IRotateBehavior
    {
        private Tween _tween;

        private Transform _transform;
        public void Rotate(float direction, float duration)
        {
            if (!_tween?.active ?? true)
            {
                _tween = GetTweenRotate(Transform, direction, duration);
            }
            else
            {
                _tween.onComplete = () => _tween = GetTweenRotate(Transform, direction, duration);
            }
        }

        public Transform Transform
        {
            private get
            {
                if (!_transform)
                {
                    throw new NoNullAllowedException("Set transform");
                }

                return _transform;
            }
            set
            {
                if (_transform)
                {
                    throw new ArgumentException();
                }

                _transform = value;
            }
        }

        private Tween GetTweenRotate(Transform transform, float direction, float duration)
        {
            var position = _transform.position;
            var tween = transform.DORotate(new Vector3(position.x, position.y, direction), duration);
            return tween;
        }
    }
}