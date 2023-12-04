using System;

namespace ExtendedSurvival.Core
{
    public static class UniqueNameIdExtension
    {

        public static bool IsNull(this UniqueNameId id)
        {
            try
            {
                id.GetHashCode();
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static bool IsNotNull(this UniqueNameId id)
        {
            try
            {
                id.GetHashCode();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}
