namespace BreweryMaster.Tests.Models
{
    public static class EndpointsConst
    {
        public static readonly string Base = "/Api";

        public static readonly string Task = $"{Base}/Task";
        public static readonly string TaskTemplate = $"{Task}/Template";
        public static readonly string TaskStatus = $"{Task}/Status";
        public static readonly string TaskDelete = $"{Task}/Delete";
    }
}
