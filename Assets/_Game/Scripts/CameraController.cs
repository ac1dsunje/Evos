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
    
    public CameraController(CinemachineCamera camera)
    {
        _camera = camera;
    }

    public void Initialize()
    {
    }

    private void AddPlayer(EntityGID player)
    {
         if(!player.TryUnpack<GameWorld>(out var entity)) return;
         ref var view = ref entity.Ref<CreatureViewComponent>();

         _camera.Target.TrackingTarget = view.View.transform;
    }

    public void Dispose()
    {
    }
}
}