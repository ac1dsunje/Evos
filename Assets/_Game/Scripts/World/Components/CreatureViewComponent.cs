using System;
using _Game.Scripts.World.View;
using FFS.Libraries.StaticEcs;
using FFS.Libraries.StaticEcs.Unity;

namespace _Game.Scripts.World.Components
{
[Serializable]
public struct CreatureViewComponent : IComponent
{
    [StaticEcsEditorTableValue] public CreatureView View;
}
}