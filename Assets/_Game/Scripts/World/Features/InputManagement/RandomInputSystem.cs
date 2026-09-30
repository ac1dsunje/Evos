using _Game.Scripts.World.Tags;
using _Game.Scripts.World.WorldResources;
using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace _Game.Scripts.World.Features.InputManagement
{
public struct RandomInputSystem : ISystem
{
    private float _timer;
    
    public void Update()
    {
        var deltaTime = W.GetResource<DeltaTimeResource>().Value;
        _timer += deltaTime;
        if (_timer < 1f) return;
        _timer = 0f;

        foreach (var entity in W.Query<All<InputComponent, RandomInputTag>>().Entities())
        {
            ref var input = ref entity.Ref<InputComponent>();
            
            input.Direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
    }
}
}