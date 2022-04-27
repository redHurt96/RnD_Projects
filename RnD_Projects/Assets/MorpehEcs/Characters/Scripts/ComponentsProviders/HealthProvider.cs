using Morpeh;
using MorpehEcs.Characters.Components;
using Unity.IL2CPP.CompilerServices;

namespace MorpehEcs.Characters.ComponentsProviders
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class HealthProvider : MonoProvider<HealthComponent> 
    {
    }
}