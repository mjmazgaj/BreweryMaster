using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.Tests.Models;

namespace BreweryMaster.Tests.Helpers
{
    public static class UserDataProvider
    {
        public static List<ApplicationUser> GetUsers()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = TestConst.User1,
                    UserName = TestConst.User1
                },
                new ApplicationUser
                {
                    Id = TestConst.User2,
                    UserName = TestConst.User2
                }
            };
        }
    }
}
