using Morpeh;
using MorpehEcs.Environment.Components;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace MorpehEcs.UI.ComponentsProviders
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class IntentToCreateCharacterProvider : MonoProvider<IntentToCreateCharacterComponent>
    {
        [SerializeField] private Text _label;
        [SerializeField] private Button _button;
        [SerializeField] private int _addCount;

        protected override void Initialize()
        {
            _label.text = $"+{_addCount}";

            _button.onClick.AddListener(AddIntent);
        }

        private void AddIntent()
        {
            Entity.GetComponent<IntentToCreateCharacterComponent>().Count += _addCount;
            //GetSerializedData().Count += _addCount;
        }
    }
}