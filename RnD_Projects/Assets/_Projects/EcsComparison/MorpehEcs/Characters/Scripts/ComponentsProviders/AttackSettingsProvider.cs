using Morpeh;
using MorpehEcs.Characters.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Characters.ComponentsProviders
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class AttackSettingsProvider : MonoProvider<AttackSettingsComponent> 
    {
        private void OnDrawGizmosSelected()
        {
            if (!Application.isPlaying)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, GetSerializedData().Radius);
        }
    }
}