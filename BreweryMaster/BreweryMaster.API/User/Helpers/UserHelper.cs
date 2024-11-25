namespace BreweryMaster.API.User.Helpers
{
    static public class UserHelper
    {
        static public string GetFullName(string forename, string surname) => $"{forename} {surname}";
    }
}