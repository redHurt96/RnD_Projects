using Morpeh;
using MorpehEcs.Characters.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.AI;

namespace MorpehEcs.Characters.ComponentsProviders
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class MoveProvider : MonoProvider<MoveComponent> 
    {
        protected override void Initialize()
        {
            ref var component = ref GetSerializedData();
            component.NavMeshAgent = GetComponent<NavMeshAgent>();
            component.NavMeshAgent.speed = component.Speed;
        }
    }
}