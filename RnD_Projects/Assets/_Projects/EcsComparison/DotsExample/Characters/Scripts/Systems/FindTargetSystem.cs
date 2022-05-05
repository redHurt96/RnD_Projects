using EcsComparison.DotsExample.Characters.Components;
using RH.Utilities.Extensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace EcsComparison.DotsExample.Characters.Systems
{
    public partial class FindTargetSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<EnemyTargetComponent>()
                .ForEach((Entity entity, ref EnemyTargetComponent targetComponent, in TeamMemberComponent teamMemberComponent) =>
                {
                    if (targetComponent.Target == null)
                        FindTarget(ref entity, ref targetComponent, in teamMemberComponent);
                })
                .WithoutBurst()
                .Run();
        }

        private void FindTarget(ref Entity entity, ref EnemyTargetComponent targetComponent, in TeamMemberComponent teamMemberComponent)
        {
            float3 currentPosition = EntityManager.GetComponentObject<Transform>(entity).position;
            var currentTeam = teamMemberComponent.Team;
            (Entity entity, float distance) closestEnemy = (default, distance: float.MaxValue);
            float sqrDistance = default;
            float3 otherPosition = default;

            Entities.ForEach((Entity otherEntity, ref TeamMemberComponent otherTeam) =>
            {
                otherPosition = EntityManager.GetComponentObject<Transform>(otherEntity).position;
                sqrDistance = math.distancesq(currentPosition, otherPosition);

                if (currentTeam != otherTeam.Team && sqrDistance < closestEnemy.distance)
                    closestEnemy = (otherEntity, sqrDistance);
            }).WithoutBurst().Run();

            if (!closestEnemy.distance.Approximately(float.MaxValue))
                targetComponent.Target = closestEnemy.entity;
        }
    }
}