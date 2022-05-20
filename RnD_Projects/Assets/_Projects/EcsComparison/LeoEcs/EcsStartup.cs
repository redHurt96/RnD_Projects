using Leopotam.EcsLite;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace EcsComparison.LeoEcs 
{
    sealed class EcsStartup : MonoBehaviour 
    {
        private EcsSystems _systems;

        private void Start () 
        {
            // register your shared data here, for example:
            // var shared = new Shared ();
            // systems = new EcsSystems (new EcsWorld (), shared);
            _systems = new EcsSystems(new EcsWorld());
            _systems
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .ConvertScene()

                .Init();
        }

        private void Update () => _systems?.Run ();

        private void OnDestroy () 
        {
            if (_systems != null) 
            {
                _systems.Destroy ();
                _systems.GetWorld().Destroy();
                _systems = null;
            }
        }
    }
}