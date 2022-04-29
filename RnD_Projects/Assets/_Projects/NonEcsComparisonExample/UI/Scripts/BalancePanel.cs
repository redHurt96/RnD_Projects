using UnityEngine;
using UnityEngine.UI;

namespace NonEcsComparisonExample.UI
{
    public class BalancePanel : MonoBehaviour
    {
        [SerializeField] private Text _friendsCountLabel;
        [SerializeField] private Text _enemiesCountLabel;
        [SerializeField] private Slider _balance;

        [Space]
        [SerializeField] private Transform _friendsParent;
        [SerializeField] private Transform _enemiesParent;

        private void Update()
        {
            int friendsCount = _friendsParent.childCount;
            int enemiesCount = _enemiesParent.childCount;

            var totalCount = friendsCount + enemiesCount;

            if (totalCount == 0)
                return;

            _friendsCountLabel.text = friendsCount.ToString();
            _enemiesCountLabel.text = enemiesCount.ToString();

            _balance.value = (float)friendsCount / totalCount;
        }
    }
}