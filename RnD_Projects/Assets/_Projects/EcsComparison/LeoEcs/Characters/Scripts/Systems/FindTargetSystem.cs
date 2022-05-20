using EcsComparison.LeoEcs.Characters.Components;
using Leopotam.EcsLite;

namespace EcsComparison.LeoEcs.Characters.Systems
{
    sealed class FindTargetSystem : IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsWorld _world;
        private EcsPool<TargetComponent> _findTargetPool;

        public void Run(EcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<TeamMemberComponent>().End();
            _findTargetPool = _world.GetPool<TargetComponent>();

            foreach (int i in _filter)
            {
                AssignTargetIfHasnt(i);
            }
        }

        private void AssignTargetIfHasnt(int i)
        {
            
        }
    }
}