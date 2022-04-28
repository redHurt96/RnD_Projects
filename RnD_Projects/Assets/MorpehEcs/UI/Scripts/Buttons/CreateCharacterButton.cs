using Morpeh;
using MorpehEcs.Characters.Common;
using MorpehEcs.Environment.Components;
using MorpehEcs.Infrastructure.Common;
using RH.Utilities.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MorpehEcs.UI.Buttons
{
    public class CreateCharacterButton : BaseActionButton
    {
        [SerializeField] private Text _label;

        [Space]
        [SerializeField] private int _count;
        [SerializeField] private Team _team;

        private void Awake() => 
            _label.text = $"+{_count}";

        protected override void PerformOnClick()
        {
            Entity newEntity = GameData.Instance.World.CreateEntity();
            ref var component = ref newEntity.AddComponent<IntentToCreateCharacterComponent>();

            component.Count = _count;
            component.Team = _team;
        }
    }
}