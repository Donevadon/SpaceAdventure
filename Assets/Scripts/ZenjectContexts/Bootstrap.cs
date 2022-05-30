using UnityEngine;
using Zenject;

namespace ZenjectContexts
{
    public class Bootstrap : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            var controller = new GameObject("PlayerController").AddComponent<PlayerController>();
            var pool = new PrefabPool<Enemy>(Container);
            var bulletPool = new PrefabPool<Bullet>(Container);
            Container.Bind<IController>().FromInstance(controller);
            Container.Bind<IRotateBehavior>().To<DOTweenRotation>().FromNew().AsTransient();
            Container.Bind<IPoolGetter<Enemy>>().To<PrefabPool<Enemy>>().FromInstance(pool);
            Container.Bind<IPoolSetter<Enemy>>().To<PrefabPool<Enemy>>().FromInstance(pool);
            Container.Bind<IPoolGetter<Bullet>>().To<PrefabPool<Bullet>>().FromInstance(bulletPool);
        }
    }
}
