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
            Container.Bind<IController>().FromInstance(controller);
            Container.Bind<IRotateBehavior>().To<DOTweenRotation>().FromNew().AsTransient();
        }
    }
}
