using UnityEngine;
using UnityEngine.UI;

namespace EcsComparison.MorpehEcs.UI.Scripts.Monobehaviours
{
    public class BalancePanel : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _friendsCount;
        [SerializeField] private Text _enemiesCount;

        [Space] 
        [SerializeField] private Transform _friendsParent;
        [SerializeField] private Transform _enemiesParent;

        private int _friendsCountValue => _friendsParent.childCount;
        private int _enemiesCountValue => _enemiesParent.childCount;
        private int _totalCountValue => _friendsCountValue + _enemiesCountValue;

        private void Update()
        {
            if (_totalCountValue == 0)
                return;

            _slider.value = _friendsCountValue / (float)_totalCountValue;
            _friendsCount.text = _friendsCountValue.ToString();
            _enemiesCount.text = _enemiesCountValue.ToString();
        }
    }
}
