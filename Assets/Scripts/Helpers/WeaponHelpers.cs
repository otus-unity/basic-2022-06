using Characters;

namespace Helpers
{
    public static class WeaponHelpers
    {
        public static string GetAnimationNameFor(WeaponType weaponType)
        {
            string result;
            switch (weaponType)
            {
                case WeaponType.Gun:
                    result = "shoot";
                    break;
                case WeaponType.BaseballBat:
                    result = "melee";
                    break;
                default:
                    result = "";
                    break;
            }

            return result;
        }
    }
}