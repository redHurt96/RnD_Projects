using Morpeh;
using MorpehEcs.Environment.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Environment.ComponentsProviders
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class SpawnZoneComponentProvider : MonoProvider<SpawnZoneComponent>
    {
        protected override void Initialize()
        {
            ref var component = ref Entity.GetComponent<SpawnZoneComponent>(); 
            component.Origin = transform.position;
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
                return;

            ref var component = ref Entity.GetComponent<SpawnZoneComponent>();
            Gizmos.color = Color.cyan;

            Gizmos.DrawCube(component.Origin, component.Size * 2f);
        }
    }
}