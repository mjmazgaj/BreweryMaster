using BreweryMaster.API.User.Mappers;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Responses;
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
                    Name = user.UserName ?? string.Empty,
                    IsCompany = false
                };
            }
        }

        static public void SetDetailResponse(this ApplicationUser user, UserDetailsResponse detailsResponse)
        {
            if (user is CompanyUser companyUser)
            {
                detailsResponse.CompanyUser = companyUser.ToResponse();
                detailsResponse.IsCompany = true;
            }
            else if (user is IndividualUser individualUser)
            {
                detailsResponse.IndividualUser = individualUser.ToResponse();
                detailsResponse.IsCompany = false;
            }
            else
            {
                throw new Exception("User is not a valid type");
            }
        }
    }
}