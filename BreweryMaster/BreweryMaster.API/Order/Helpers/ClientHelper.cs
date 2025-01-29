using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.User.Models.Users.DB;

namespace BreweryMaster.API.OrderModule.Helpers
{
    public static class ClientHelper
    {
        public static string GetName(this Client client)
        {
            var name = "";
            if (client is IndyvidualClient indyvidualClient)
                name = $"{indyvidualClient.Forename} {indyvidualClient.Surname}";
            else if (client is CompanyClient companyClient)
                name = companyClient.CompanyName;
            return name;
        }
    }
}
