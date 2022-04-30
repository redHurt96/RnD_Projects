using System;
using System.Linq;
using Morpeh;
using MorpehEcs.Characters.Components;
using MorpehEcs.Infrastructure.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MorpehEcs.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(FindTargetSystem))]
    public sealed class FindTargetSystem : UpdateSystem
    {
        private Filter _filter;
        private Filter _limitFilter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<TeamMemberComponent>();
            _limitFilter = World.Filter.With<PathfindingPerFrameLimit>();
        }

        public override void OnUpdate(float deltaTime)
        {
            int limit = _limitFilter.First().GetComponent<PathfindingPerFrameLimit>().Limit;

            foreach (Entity entity in _filter)
            {
                if (entity.Has<EnemyTargetComponent>())
                {
                    ref EnemyTargetComponent targetComponent = ref entity.GetComponent<EnemyTargetComponent>();

                    if (!targetComponent.Target.IsNullOrDisposed())
                        continue;

                    entity.RemoveComponent<EnemyTargetComponent>();
                }

                if (limit <= 0) 
                    continue;

                AssignTarget(entity);
                limit--;
            }
        }

        private void AssignTarget(Entity to)
        {
            ref var teamComponent = ref to.GetComponent<TeamMemberComponent>();
            var closestTarget = FindClosestTarget(to, teamComponent);

            AddComponentIfHasTarget(to, closestTarget);
        }

        private Tuple<Entity, float> FindClosestTarget(Entity to,
            TeamMemberComponent teamComponent)
        {
            var closestTarget = new Tuple<Entity, float>(null, float.MaxValue);

            foreach (Entity entity in _filter)
            {
                ref var otherTeamComponent = ref entity.GetComponent<TeamMemberComponent>();

                if (teamComponent.Team != otherTeamComponent.Team && entity != to)
                {
                    float sqrDistance = Vector3.SqrMagnitude(to.GetComponent<PositionComponent>().Position
                                                             - entity.GetComponent<PositionComponent>().Position);

                    if (closestTarget.Item2 > sqrDistance)
                        closestTarget = new Tuple<Entity, float>(entity, sqrDistance);
                }
            }

            return closestTarget;
        }

        private void AddComponentIfHasTarget(Entity to, Tuple<Entity, float> closestTarget)
        {
            if (closestTarget.Item1 != null)
            {
                ref EnemyTargetComponent targetComponent = ref to.AddComponent<EnemyTargetComponent>();
                targetComponent.Target = closestTarget.Item1;
            }
        }
    }
}