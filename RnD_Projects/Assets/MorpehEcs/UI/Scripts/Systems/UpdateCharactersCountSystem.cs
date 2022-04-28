using System.Linq;
using Morpeh;
using MorpehEcs.Characters.Common;
using MorpehEcs.Characters.Components;
using MorpehEcs.UI.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.UI.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UpdateCharactersCountSystem))]
    public sealed class UpdateCharactersCountSystem : UpdateSystem
    {
        private Filter _charactersFilter;
        private Filter _countComponentFilter;

        public override void OnAwake()
        {
            _charactersFilter = World.Filter.With<TeamMemberComponent>();
            _countComponentFilter = World.Filter.With<CharactersCountsComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            var characters = _charactersFilter.Select(x => x.GetComponent<TeamMemberComponent>()).ToArray();
            int friends = characters.Count(x => x.Team == Team.Friends);
            int enemies = characters.Count(x => x.Team == Team.Enemies);

            var countsComponentsBag = _countComponentFilter.Select<CharactersCountsComponent>();

            for (int i = 0; i < _countComponentFilter.Length; i++)
            {
                ref var countComponent = ref countsComponentsBag.GetComponent(i);

                countComponent.Friends = friends;
                countComponent.Enemies = enemies;
            }
        }
    }
}