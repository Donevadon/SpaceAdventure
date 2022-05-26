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
            var pool = new EnemyPool(Container);
            Container.Bind<IController>().FromInstance(controller);
            Container.Bind<IRotateBehavior>().To<DOTweenRotation>().FromNew().AsTransient();
            Container.Bind<IEnemyPoolGetter>().To<EnemyPool>().FromInstance(pool);
            Container.Bind<IEnemyPoolSetter>().To<EnemyPool>().FromInstance(pool);
        }
    }
}
