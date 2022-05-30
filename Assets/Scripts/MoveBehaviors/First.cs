using Units.Airplanes;
using UnityEngine;

namespace MoveBehaviors
{
    public class First : IMoveBehavior
    {
        private readonly Transform _transform;

        public First(Transform transform)
        {
            _transform = transform;
        }

        public void Up(float speed)
        {
            var position = _transform.position;
            position = new Vector3(position.x, position.y + Time.deltaTime * speed);
            _transform.position = position;
        }

        public void Down(float speed)
        {
            var position = _transform.position;
            position = new Vector3(position.x, position.y - Time.deltaTime * speed);
            _transform.position = position;
        }

        public void Right(float speed)
        {
            var position = _transform.position;
            position = new Vector3(position.x - Time.deltaTime * speed, position.y);
            _transform.position = position;
        }

        public void Left(float speed)
        {
            var position = _transform.position;
            position = new Vector3(position.x + Time.deltaTime * speed, position.y);
            _transform.position = position;
        }

        public void RotationCanceled()
        {
        }
    }
}