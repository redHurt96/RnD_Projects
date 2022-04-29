using System.Collections.Generic;
using NonEcsComparisonExample.Character.Components;
using RH.Utilities.SingletonAccess;

namespace NonEcsComparisonExample.Character.Infrastructure
{
    public class GameData : Singleton<GameData>
    {
        public List<TeamComponent> Characters = new List<TeamComponent>();
    }
}