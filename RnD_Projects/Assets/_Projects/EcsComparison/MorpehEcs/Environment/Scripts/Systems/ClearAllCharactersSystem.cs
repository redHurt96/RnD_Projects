using Morpeh;
using MorpehEcs.Characters.Components;
using MorpehEcs.UI.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Environment.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ClearAllCharactersSystem))]
    public sealed class ClearAllCharactersSystem : UpdateSystem
    {
        private Filter _filter;
        private Filter _charactersHealths;

        public override void OnAwake()
        {
            _filter = World.Filter.With<ClearAllCharactersComponent>();
            _charactersHealths = World.Filter.With<HealthComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            if (_filter.Length == 0)
                return;

            SetAllCharactersDeath();
            ClearAllIntents();
        }

        private void SetAllCharactersDeath()
        {
            var healthsBag = _charactersHealths.Select<HealthComponent>();

            for (int i = 0; i < _charactersHealths.Length; i++)
                healthsBag.GetComponent(i).Current = 0;
        }

        private void ClearAllIntents()
        {
            foreach (Entity entity in _filter)
                World.RemoveEntity(entity);
        }
    }
}