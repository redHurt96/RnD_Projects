using Morpeh;
using MorpehEcs.Characters.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DestroyOnDeathSystem))]
    public sealed class DestroyOnDeathSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake() =>
            _filter = World.Filter
                .With<HealthComponent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref HealthComponent healthAuthoring = ref entity.GetComponent<HealthComponent>();

                if (healthAuthoring.Current <= 0) 
                    Destroy(entity);
            }
        }

        private void Destroy(Entity entity)
        {
            ref PositionComponent position = ref entity.GetComponent<PositionComponent>();

            Destroy(position.Transform.gameObject);
            World.RemoveEntity(entity);
        }
    }
}