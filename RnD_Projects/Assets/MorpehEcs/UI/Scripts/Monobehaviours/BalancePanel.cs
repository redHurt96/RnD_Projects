using Morpeh;
using MorpehEcs.UI.Components;
using MorpehEcs.UI.ComponentsProviders;
using UnityEngine;
using UnityEngine.UI;

namespace MorpehEcs.UI.Monobehaviours
{
    public class BalancePanel : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _friendsCount;
        [SerializeField] private Text _enemiesCount;

        [Space]
        [SerializeField] private CharactersCountProvider _charactersCountProvider;

        private void Update()
        {
            ref var component = ref _charactersCountProvider.Entity.GetComponent<CharactersCountsComponent>();
            int totalCharactersCount = component.Enemies + component.Friends;

            if (totalCharactersCount == 0)
                return;

            _slider.value = component.Friends / (float)totalCharactersCount;
            _friendsCount.text = component.Friends.ToString();
            _enemiesCount.text = component.Enemies.ToString();
        }
    }
}
