using _Game.Scripts.Components;
using _Game.Scripts.Systems;
using VContainer;
using VContainer.Unity;

namespace _Game.Scripts
{
public class BootstrapScope: LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        W.Create();
        
        W.Types().RegisterAll(); 
            
        W.Initialize();

        builder.Register<EntitySpawner>(Lifetime.Singleton);

        builder.RegisterEntryPoint<DamageOverTimeSystem>().AsSelf();
        builder.RegisterEntryPoint<Ticker>().AsSelf();

        builder.RegisterEntryPoint<SpawnerTester>(Lifetime.Scoped);
        
        
    }
}
}