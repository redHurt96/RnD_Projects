using Morpeh;
using Unity.IL2CPP.CompilerServices;
using HealthComponent = MorpehEcs.Characters.Components.HealthComponent;

namespace MorpehEcs.Characters.ComponentsProviders
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class HealthProvider : MonoProvider<HealthComponent> 
    {
    }
}