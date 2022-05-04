using EcsComparison.DotsExample.Characters.Components;
using Unity.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace EcsComparison.DotsExample.Characters.Systems
{
    public partial class RandomDestinationNavigationSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity entity, in NavigationComponent navigationComponent) =>
            {
                var navMeshAgent = EntityManager.GetComponentObject<NavMeshAgent>(entity);
                navMeshAgent.SetDestination(new Vector3(0, 0, 20));
            }).WithoutBurst().Run();
        }
    }
}
