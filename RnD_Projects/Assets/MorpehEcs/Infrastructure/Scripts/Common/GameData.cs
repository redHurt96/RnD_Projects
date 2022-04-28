using Morpeh;
using RH.Utilities.SingletonAccess;

namespace MorpehEcs.Infrastructure.Common
{
    public class GameData : Singleton<GameData>
    {
        public readonly World World;

        public GameData(World world)
        {
            World = world;
        }
    }
}
