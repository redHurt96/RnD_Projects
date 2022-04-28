using Morpeh;
using MorpehEcs.Characters.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UpdateAttackAvailabilitySystem))]
    public sealed class UpdateAttackAvailabilitySystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake() =>
            _filter = World.Filter
                .With<PositionComponent>()
                .With<AttackSettingsComponent>()
                .With<EnemyTargetComponent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                float attackRadius = entity.GetComponent<AttackSettingsComponent>().Radius;
                Vector3 position = entity.GetComponent<PositionComponent>().Position;
                Vector3 targetPosition = entity.GetComponent<EnemyTargetComponent>().Target
                    .GetComponent<PositionComponent>().Position;

                bool canAttack = Mathf.Pow(attackRadius, 2) >= Vector3.SqrMagnitude(targetPosition - position);

                if (canAttack)
                    AddComponentIfDoesntExist(entity);
                else
                    RemoveComponentIfExist(entity);
            }
        }

        private void AddComponentIfDoesntExist(Entity entity)
        {
            if (!entity.Has<CanAttackComponent>())
                entity.AddComponent<CanAttackComponent>();
        }

        private void RemoveComponentIfExist(Entity entity)
        {
            if (entity.Has<CanAttackComponent>())
                entity.RemoveComponent<CanAttackComponent>();
        }
    }
}