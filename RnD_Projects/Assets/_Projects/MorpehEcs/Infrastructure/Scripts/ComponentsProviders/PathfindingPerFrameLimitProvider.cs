using Morpeh;
using MorpehEcs.Infrastructure.Components;
using Unity.IL2CPP.CompilerServices;

namespace MorpehEcs.Infrastructure.ComponentsProviders
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class PathfindingPerFrameLimitProvider : MonoProvider<PathfindingPerFrameLimit> 
    {
    }
}