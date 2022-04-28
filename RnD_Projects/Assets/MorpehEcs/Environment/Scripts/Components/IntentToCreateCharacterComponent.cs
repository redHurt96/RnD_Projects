using Morpeh;
using MorpehEcs.Characters.Common;
using Unity.IL2CPP.CompilerServices;

namespace MorpehEcs.Environment.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct IntentToCreateCharacterComponent : IComponent
    {
        public Team Team;
        public int Count;
    }
}