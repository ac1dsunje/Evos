using VContainer;
using VContainer.Unity;
using _Game.Scripts.ECS;
using _Game.Scripts.UI;
using Unity.Cinemachine;

namespace _Game.Scripts
{
public class BootstrapScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<EcsWorldManager>();
        builder.RegisterEntryPoint<WorldUpdater>().AsSelf();

        builder.RegisterComponentInHierarchy<CinemachineCamera>();
        builder.RegisterEntryPoint<CameraController>(Lifetime.Scoped).AsSelf();
        
        builder.Register<EntitySpawner>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<UnitySpawner>();
        
        builder.RegisterComponentInHierarchy<UIManager>();
    }
}
}