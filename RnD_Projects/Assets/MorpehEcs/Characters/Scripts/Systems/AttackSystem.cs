using Morpeh;
using MorpehEcs.Characters.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AttackSystem))]
    public sealed class AttackSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake() =>
            _filter = World.Filter
                .With<AttackSettingsComponent>()
                .With<CanAttackComponent>()
                .With<EnemyTargetComponent>()
                .Without<AttackCooldownComponent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref HealthComponent targetHealth = ref entity.GetComponent<EnemyTargetComponent>()
                    .Target.GetComponent<HealthComponent>();
                ref AttackSettingsComponent attackSettings = ref entity.GetComponent<AttackSettingsComponent>();

                targetHealth.Current = Mathf.Max(0f, targetHealth.Current - attackSettings.Damage);
                entity.AddComponent<AttackCooldownComponent>().Time = attackSettings.Cooldown;
            }
        }
    }
}