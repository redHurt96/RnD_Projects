using System;
using UnityEngine;

namespace EcsComparison.LeoEcs.Characters.Components
{
    [Serializable]
    public struct TransformComponent
    {
        public Transform Transform;
        public Vector3 Position => Transform.position;
    }
}