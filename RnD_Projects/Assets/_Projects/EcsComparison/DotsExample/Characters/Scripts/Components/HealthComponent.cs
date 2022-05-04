using System;
using Unity.Entities;

namespace EcsComparison.DotsExample.Characters.Components
{
    [Serializable, GenerateAuthoringComponent]
    public struct HealthComponent : IComponentData
    {
        public float Current;
    }
}
