using System;

namespace EcsComparison.LeoEcs.Characters.Components 
{
    [Serializable]
    public struct TeamMemberComponent
    {
        public Team Team;
    }

    public enum Team
    {
        Blue,
        Red
    }
}