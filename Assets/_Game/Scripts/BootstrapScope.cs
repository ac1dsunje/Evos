using VContainer;
using VContainer.Unity;
using _Game.Scripts.ECS;

namespace _Game.Scripts
{
public class BootstrapScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<EcsWorldManager>();
        builder.RegisterEntryPoint<WorldUpdater>().AsSelf();
        builder.Register<EntitySpawner>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<UnitySpawner>();
    }
}
}