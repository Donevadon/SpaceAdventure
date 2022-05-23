using System;
using UnityEngine;

public interface IController
{
    event Func<Vector2> LeftPressed;
    event Func<Vector2> RightPressed;
    event Action RotationCanceled;
    event Func<Vector2> UpPressed;
    event Action UpCanceled;
    event Func<Vector2> DownPressed;
    event Action DownCanceled;
}