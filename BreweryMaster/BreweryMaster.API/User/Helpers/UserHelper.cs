namespace BreweryMaster.API.UserModule.Helpers
{
    static public class UserHelper
    {
        static public string GetFullName(string forename, string surname) => $"{forename} {surname}";
    }
}