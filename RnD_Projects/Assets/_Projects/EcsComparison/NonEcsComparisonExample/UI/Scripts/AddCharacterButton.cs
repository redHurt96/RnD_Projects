using RH.Utilities.UI;
using UnityEngine;
using UnityEngine.UI;

namespace NonEcsComparisonExample.UI
{
    public class AddCharacterButton : BaseActionButton
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private SpawnZone _spawnZone;
        [SerializeField] private Transform _parent;
        
        [Space]
        [SerializeField] private int _count;

        [Space] 
        [SerializeField] private Text _label;

        private void Awake() => 
            _label.text = $"+{_count}";

        protected override void PerformOnClick()
        {
            for (int i = 0; i < _count; i++) 
                Instantiate(_prefab, _spawnZone.Position, Quaternion.identity, _parent);
        }
    }
}