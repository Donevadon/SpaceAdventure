using UnityEngine;

namespace Units.Airplanes
{
    public interface IRotateBehavior
    {
        void Rotate(float direction, float duration);
        Transform Transform { set; }
    }
}