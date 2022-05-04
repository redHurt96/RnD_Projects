using System;
using EcsComparison.DotsExample.Characters.Common;
using Unity.Entities;

namespace EcsComparison.DotsExample.Characters.Components
{
    [Serializable, GenerateAuthoringComponent]
    public struct TeamMemberComponent : IComponentData
    {
        public Team Team;
    }
}
