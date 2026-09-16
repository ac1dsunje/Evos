using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.ECS.WorldResources
{
public struct DeltaTimeResource : IResource
{
    public float Value;
}

public struct FixedDeltaTimeResource : IResource
{
    public float Value;
}
}