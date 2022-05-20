using System;

namespace EcsComparison.LeoEcs.Characters.Components
{
    [Serializable]
    public struct AttackSettingsComponent
    {
        public float Damage;
        public float Radius;
        public float Cooldown;
    }
}