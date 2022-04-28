using Morpeh;
using MorpehEcs.Infrastructure.Common;
using MorpehEcs.UI.Components;
using RH.Utilities.UI;

namespace MorpehEcs.UI.Buttons
{
    public class ClearAllCharactersButton : BaseActionButton
    {
        protected override void PerformOnClick() =>
            GameData.Instance.World
                .CreateEntity()
                .AddComponent<ClearAllCharactersComponent>();
    }
}