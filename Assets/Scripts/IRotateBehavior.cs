using UnityEngine;

public interface IRotateBehavior
{
    void Rotate(float direction, float duration);
    Transform Transform { set; }
}