using System;
using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Features.Body;
using FFS.Libraries.StaticEcs;
using Unity.Cinemachine;
using VContainer.Unity;

namespace _Game.Scripts
{
public class CameraController : IInitializable, IDisposable
{
    private readonly CinemachineCamera _camera;
    private readonly UnitySpawner _spawner;
    
    public CameraController(CinemachineCamera camera, UnitySpawner spawner)
    {
        _camera = camera;
        _spawner = spawner;
    }

    public void Initialize()
    {
        _spawner.OnPlayerSpawned += AddPlayer;
    }

    private void AddPlayer(EntityGID player)
    {
         if(!player.TryUnpack<GameWorld>(out var entity)) return;
         ref var view = ref entity.Ref<CreatureViewComponent>();

         _camera.Target.TrackingTarget = view.View.transform;
    }

    public void Dispose()
    {
        _spawner.OnPlayerSpawned -= AddPlayer;
    }
}
}