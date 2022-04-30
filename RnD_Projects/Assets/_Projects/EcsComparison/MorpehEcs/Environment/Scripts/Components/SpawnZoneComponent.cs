using Morpeh;
using MorpehEcs.Characters.Common;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Environment.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct SpawnZoneComponent : IComponent
    {
        public Team Team;
        public GameObject Prefab;
        public Transform SpawnParent;
        public Vector3 Origin;
        public Vector3 Size;
    }
}