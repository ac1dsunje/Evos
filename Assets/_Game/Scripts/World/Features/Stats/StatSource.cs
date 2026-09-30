using System;
using System.Collections.Generic;
using FFS.Libraries.StaticEcs;

namespace _Game.Scripts.World.Features.Stats
{
[Serializable]
public struct StatSource : IMultiComponent
{
    public List<Stat> Stats;
}
}
