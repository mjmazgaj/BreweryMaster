using BreweryMaster.API.OrderModule.Models;

namespace BreweryMaster.API.OrderModule.Helpers
{
    public static class ProspectClientHelper
    {
        public static string GetName(this ProspectClient client)
        {
            var name = string.Empty;
            if (client is ProspectIndyvidualClient indyvidualClient)
                name = $"{indyvidualClient.Forename} {indyvidualClient.Surname}";
            else if (client is ProspectCompanyClient companyClient)
                name = companyClient.CompanyName;
            return name;
        }
    }
}
