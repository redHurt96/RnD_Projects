using Unity.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace EcsComparison.DotsExample.Characters.Components
{
    [DisallowMultipleComponent]
    public class AuthoringNavigationComponent : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var navMeshAgent = GetComponent<NavMeshAgent>();
            dstManager.AddComponentObject(entity, navMeshAgent);
            dstManager.AddComponent<NavigationComponent>(entity);
        }
    }
}