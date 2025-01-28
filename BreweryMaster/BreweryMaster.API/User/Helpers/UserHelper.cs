using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Users.DB;

namespace BreweryMaster.API.UserModule.Helpers
{
    static public class UserHelper
    {
        static public string GetFullName(string forename, string surname) => $"{forename} {surname}";

        static public UserResponse ToUserResponse(this ApplicationUser user)
        {
            if (user is CompanyUser companyUser)
            {
                return new UserResponse()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = companyUser.CompanyName,
                    IsCompany = true
                };
            } 
            else if (user is IndividualUser individualUser)
            {
                return new UserResponse()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = $"{individualUser.Forename} {individualUser.Surname}",
                    IsCompany = false
                };
            }
            else
            {
                return new UserResponse()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName,
                    IsCompany = false
                };
            }
        }
    }
}