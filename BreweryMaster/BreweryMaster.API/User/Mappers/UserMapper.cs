using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Responses;

namespace BreweryMaster.API.User.Mappers
{
    public static class UserMapper
    {
        static public CompanyUserResponse ToResponse(this CompanyUser user)
        {
            return new CompanyUserResponse()
            {
                CompanyName = user.CompanyName,
                Nip = user.Nip
            };
        }

        static public IndividualUserResponse ToResponse(this IndividualUser user)
        {
            return new IndividualUserResponse()
            {
                Forename = user.Forename,
                Surname = user.Surname
            };
        }
    }
}
