using VRage.Game;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{
    public static class ObjectBuilderExtensions
    {

        public static UniqueEntityId GetUniqueId(this MyObjectBuilder_Base self)
        {
            return new UniqueEntityId(self.GetId());
        }

    }

}