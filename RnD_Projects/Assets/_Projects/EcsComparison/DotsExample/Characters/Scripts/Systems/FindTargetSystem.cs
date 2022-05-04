using System;
using EcsComparison.DotsExample.Characters.Components;
using Unity.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace EcsComparison.DotsExample.Characters.Systems
{
    public partial class FindTargetSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .ForEach((Entity entity, ref EnemyTargetComponent targetComponent, ref TeamMemberComponent teamMemberComponent) =>
                {
                    if (targetComponent.Target == null)
                        FindTarget(ref entity, ref targetComponent, ref teamMemberComponent);
                })
                .Run();
        }

        private void FindTarget(ref Entity entity, ref EnemyTargetComponent targetComponent, ref TeamMemberComponent teamMemberComponent)
        {
            var currentTeam = teamMemberComponent.Team;
            (Entity, float) closestEnemy = (default, float.MaxValue);
            Vector3 sqrDistance = default;
            
            Entities.ForEach((Entity otherEntity, ref TeamMemberComponent otherTeam) =>
            {
                sqrDistance = 
                if (otherTeam.Team != currentTeam)

            });
        }
    }
}