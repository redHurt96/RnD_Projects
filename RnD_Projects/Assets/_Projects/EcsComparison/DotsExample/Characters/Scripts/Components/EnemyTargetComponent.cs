using System;
using Unity.Entities;

namespace EcsComparison.DotsExample.Characters.Components
{
    [Serializable, GenerateAuthoringComponent]
    public struct EnemyTargetComponent : IComponentData
    {
        public Entity Target;
    }
}
