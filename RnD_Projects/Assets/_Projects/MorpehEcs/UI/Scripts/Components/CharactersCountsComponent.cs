using Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace MorpehEcs.UI.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct CharactersCountsComponent : IComponent
    {
        public int Friends;
        public int Enemies;
    }
}