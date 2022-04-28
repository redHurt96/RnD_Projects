using Morpeh;
using MorpehEcs.Environment.Components;
using RH.Utilities.Extensions;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Environment.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CreateCharactersSystem))]
    public sealed class CreateCharactersSystem : UpdateSystem
    {
        private Filter _intentsFilter;
        private Filter _spawnZonesFilter;

        public override void OnAwake()
        {
            _intentsFilter = World.Filter.With<IntentToCreateCharacterComponent>();
            _spawnZonesFilter = World.Filter.With<SpawnZoneComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _intentsFilter)
            {
                ref var intent = ref entity.GetComponent<IntentToCreateCharacterComponent>();

                if (intent.Count == 0)
                    continue;

                foreach (Entity createEntity in _spawnZonesFilter)
                {
                    ref var zone = ref createEntity.GetComponent<SpawnZoneComponent>();

                    if (zone.Team == intent.Team)
                    {
                        while (intent.Count > 0)
                        {
                            Vector3 position = zone.Origin.AddRandomInBox(zone.Size);
                            Instantiate(zone.Prefab, position, Quaternion.identity, zone.SpawnParent);

                            intent.Count--;    
                        }
                    }
                }
            }
        }
    }
}