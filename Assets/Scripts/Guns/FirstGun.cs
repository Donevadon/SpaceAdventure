using System.Collections;
using Guns.Bullets;
using Units;
using Units.Airplanes;
using UnityEngine;
using Zenject;

namespace Guns
{
    public class FirstGun : MonoBehaviour, IGun
    {
        [SerializeField] private Transform[] gunPositions;
    
        private Coroutine _coroutine;
        private IPoolGetter<Bullet> _pool;

        [Inject]
        private void Init(IPoolGetter<Bullet> pool)
        {
            _pool = pool;
        }
    
        public void StartFire()
        {
            _coroutine = StartCoroutine(StartFire(0.1f));
        }

        IEnumerator StartFire(float frequency)
        {
            while (true)
            {
                foreach (var gunPosition in gunPositions)
                {
                    var bullet = _pool.Spawn(typeof(Bullet), gunPosition.position, Quaternion.identity);
                    bullet.Direction = Vector2.down;
                }

                yield return new WaitForSeconds(frequency);
            }
        }
    }
}