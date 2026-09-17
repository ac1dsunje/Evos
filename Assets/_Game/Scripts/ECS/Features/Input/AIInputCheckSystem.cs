using _Game.Scripts.ECS.Core.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.ECS.Features.Input
{
public struct AIInputCheckSystem : ISystem
{
    private float _timer;
    
    public void Update()
    {
        _timer += W.GetResource<DeltaTimeResource>().Value;

        if (_timer < 1f) return;
        
        _timer = 0f;
        
        foreach (var entity in W.Query<All<
                     InputComponent, 
                     AIControlledTag
                 >>().Entities())
        {
            ref var input = ref entity.Ref<InputComponent>();
            
            input.Direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
    }
}
}