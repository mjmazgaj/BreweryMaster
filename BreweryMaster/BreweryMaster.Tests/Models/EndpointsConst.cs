namespace BreweryMaster.Tests.Models
{
    public static class EndpointsConst
    {
        public static readonly string Base = "/Api";

        public static readonly string Task = $"{Base}/Task";
        public static readonly string TaskTemplate = $"{Task}/Template";
        public static readonly string TaskStatus = $"{Task}/Status";
        public static readonly string TaskDelete = $"{Task}/Delete";

        public static readonly string User = $"{Base}/User";
        public static readonly string UserDropDown = $"{User}/DropDown";
        public static readonly string UserRole = $"{User}/Role";
        public static readonly string UserRegister = $"{User}/Register";
        public static readonly string UserPassword = $"{User}/Password";
        public static readonly string UserRoles = $"{User}/Roles";
        public static readonly string UserInfo = $"{User}/Info";
        public static readonly string UserDetails = $"{User}/Details";
        public static readonly string UserLogout = $"{User}/Logout";
        public static readonly string UserAddTestUsers = $"{User}/AddTestUsers";

        public static readonly string Address = $"{Base}/Address";
    }
}
