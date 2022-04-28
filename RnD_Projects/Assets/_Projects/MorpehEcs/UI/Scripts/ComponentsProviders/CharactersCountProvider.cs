using Morpeh;
using MorpehEcs.UI.Components;
using Unity.IL2CPP.CompilerServices;

namespace MorpehEcs.UI.ComponentsProviders
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class CharactersCountProvider : MonoProvider<CharactersCountsComponent> 
    {
    }
}