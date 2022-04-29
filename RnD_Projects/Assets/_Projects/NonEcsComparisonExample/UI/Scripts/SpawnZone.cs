using RH.Utilities.Extensions;
using UnityEngine;

namespace NonEcsComparisonExample.UI
{
    public class SpawnZone : MonoBehaviour
    {
        public Vector3 _origin;
        public Vector3 _size;

        public Vector3 Position => _origin.AddRandomInBox(_size);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(_origin, _size * 2f);
        }
    }
}