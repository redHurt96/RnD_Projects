using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.AI;

namespace MorpehEcs.Characters.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct MoveComponent : IComponent
    {
        public float Speed;
        public NavMeshAgent NavMeshAgent;
    }
}