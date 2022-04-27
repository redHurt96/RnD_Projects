using Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace MorpehEcs.Characters.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct PathComponent : IComponent
    {
        public float UpdateCooldown;
    }
}