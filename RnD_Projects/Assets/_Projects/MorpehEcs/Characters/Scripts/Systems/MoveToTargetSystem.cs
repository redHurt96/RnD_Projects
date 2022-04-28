using Morpeh;
using MorpehEcs.Characters.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MoveToTargetSystem))]
    public sealed class MoveToTargetSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake() =>
            _filter = World.Filter
                .With<EnemyTargetComponent>()
                .With<PositionComponent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                if (!entity.Has<PathComponent>())
                    entity.AddComponent<PathComponent>();

                ref PathComponent pathComponent = ref entity.GetComponent<PathComponent>();

                if (pathComponent.UpdateCooldown <= 0)
                    RecalculatePath(entity, ref pathComponent);
                else
                    UpdatePathUpdateTime(ref pathComponent, deltaTime);
            }
        }

        private void UpdatePathUpdateTime(ref PathComponent pathComponent, float deltaTime) => 
            pathComponent.UpdateCooldown -= deltaTime;

        private static void RecalculatePath(Entity entity, ref PathComponent pathComponent)
        {
            ref MoveComponent moveComponent = ref entity.GetComponent<MoveComponent>();

            ref PositionComponent targetPositionComponent = ref entity.GetComponent<EnemyTargetComponent>()
                .Target
                .GetComponent<PositionComponent>();
            Vector3 position = targetPositionComponent.Position;

            if (!entity.Has<PathComponent>())
                entity.AddComponent<PathComponent>();

            moveComponent.NavMeshAgent.SetDestination(position);
            pathComponent.UpdateCooldown = .5f;
        }
    }
}