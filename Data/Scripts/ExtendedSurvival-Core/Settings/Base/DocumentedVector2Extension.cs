using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class DocumentedVector2Extension
    {

        public static Vector2 ToVector2(this DocumentedVector2 self)
        {
            return new Vector2(self.X, self.Y);
        }

        public static Vector2I ToVector2I(this DocumentedVector2 self)
        {
            return new Vector2I((int)self.X, (int)self.Y);
        }

    }

}
