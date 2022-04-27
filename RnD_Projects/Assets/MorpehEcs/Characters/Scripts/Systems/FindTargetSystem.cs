using System;
using System.Linq;
using Morpeh;
using MorpehEcs.Characters.Components;
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

        public override void OnAwake() => 
            _filter = World.Filter
                .With<TeamMemberComponent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                if (entity.Has<EnemyTargetComponent>())
                {
                    ref EnemyTargetComponent targetComponent = ref entity.GetComponent<EnemyTargetComponent>();

                    if (!targetComponent.Target.IsNullOrDisposed())
                        continue;

                    entity.RemoveComponent<EnemyTargetComponent>();
                }

                AssignTarget(entity);
            }
        }

        private void AssignTarget(Entity to)
        {
            ref var teamComponent = ref to.GetComponent<TeamMemberComponent>();

            IOrderedEnumerable<Entity> randomListOfCharacters
                = from x in _filter orderby Random.value select x;

            foreach (Entity entity in randomListOfCharacters)
            {
                ref var otherTeamComponent = ref entity.GetComponent<TeamMemberComponent>();

                if (teamComponent.Team != otherTeamComponent.Team && entity != to)
                {
                    ref EnemyTargetComponent targetComponent = ref to.AddComponent<EnemyTargetComponent>();
                    targetComponent.Target = entity;

                    break;
                }
            }
        }
    }
}