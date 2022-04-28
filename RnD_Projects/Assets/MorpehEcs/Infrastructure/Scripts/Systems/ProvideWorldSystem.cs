using Morpeh;
using MorpehEcs.Infrastructure.Common;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace MorpehEcs.Infrastructure.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(ProvideWorldSystem))]
    public sealed class ProvideWorldSystem : Initializer
    {
        public override void OnAwake() => 
            new GameData(World);

        public override void Dispose() => 
            GameData.DestroyInstance();
    }
}