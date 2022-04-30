using System.Linq;
using NonEcsComparisonExample.Character.Components;
using NonEcsComparisonExample.Character.Infrastructure;
using RH.Utilities.UI;

namespace NonEcsComparisonExample.UI
{
    public class ClearAllButton : BaseActionButton
    {
        protected override void PerformOnClick()
        {
            foreach (HealthComponent health in GameData.Instance.Characters.Select(x => x.GetComponent<HealthComponent>()))
                health.Die();
        }
    }
}