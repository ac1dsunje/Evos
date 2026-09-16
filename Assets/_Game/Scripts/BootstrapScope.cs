using VContainer;
using VContainer.Unity;
using _Game.Scripts.ECS;
using _Game.Scripts.UI;
using _Game.Scripts.UI.Bars;

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
        
        builder.RegisterComponentInHierarchy<UIManager>();
    }
}
}