using System;
using UnityEngine;

namespace ZenjectContexts
{
    internal class PlayerController : MonoBehaviour, IController
    {
        public event Func<Vector2> LeftPressed;
        public event Func<Vector2> RightPressed;
        public event Action RotationCanceled;
        public event Func<Vector2> UpPressed;
        public event Action UpCanceled;
        public event Func<Vector2> DownPressed;
        public event Action DownCanceled;

        private void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
                RightPressed?.Invoke();
            else if (Input.GetKey(KeyCode.LeftArrow))
                LeftPressed?.Invoke();
            else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                RotationCanceled?.Invoke();
            if (Input.GetKey(KeyCode.UpArrow))
                UpPressed?.Invoke();
            else if (Input.GetKey(KeyCode.DownArrow)) DownPressed?.Invoke();
        }
    }
}