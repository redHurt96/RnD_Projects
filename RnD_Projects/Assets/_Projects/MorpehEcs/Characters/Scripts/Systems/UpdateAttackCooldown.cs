using Morpeh;
using MorpehEcs.Characters.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UpdateAttackCooldown))]
    public sealed class UpdateAttackCooldown : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake() =>
            _filter = World.Filter
                .With<AttackCooldownComponent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref AttackCooldownComponent cooldown = ref entity.GetComponent<AttackCooldownComponent>();
                cooldown.Time -= deltaTime;

                if (cooldown.Time < 0)
                    entity.RemoveComponent<AttackCooldownComponent>();
            }
        }
    }
}