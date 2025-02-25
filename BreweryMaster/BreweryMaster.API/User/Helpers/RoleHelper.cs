using Microsoft.AspNetCore.Identity;

namespace BreweryMaster.API.User.Helpers
{
    public static class RoleHelper
    {
        public static IEnumerable<string> GetRoles(this IEnumerable<IdentityRole> roles, string? identityRole)
        {
            if (identityRole == null)
                return Enumerable.Empty<string>();

            var rolesNames = roles.Select(roles => roles.Name ?? string.Empty).ToList();

            switch (identityRole)
            {
                case "manager":
                    return ["manager", "brewer", "supervisor", "employee"];
                case "brewer":
                    return ["brewer", "supervisor", "employee"];
                case "supervisor":
                    return ["supervisor", "employee"];
                case "employee":
                    return ["employee"];
                case "employeeNotMobile":
                    return ["employeeNotMobile"];
                case "customer":
                    return ["customer"];
                default:
                    return [identityRole];
            }
        }
    }
}
