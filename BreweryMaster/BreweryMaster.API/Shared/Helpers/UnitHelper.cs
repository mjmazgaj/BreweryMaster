using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Shared.Helpers
{
    public static class UnitHelper
    {
        public static float ConvertToLitters(UnitEntity unitEntity, int capacity)
        {
            float result;
            switch (unitEntity.Name)
            {
                case "ml":
                    result = (float)capacity / 1000;
                    break;
                case "hl":
                    result = (float)capacity * 100;
                    break;
                case "l":
                    result = (float)capacity;
                    break;
                default:
                    throw new Exception("not supperted unit");
            }

            return result;
        }
    }
}
