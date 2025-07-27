namespace FamilySimulationApi.Auth;

public class UserService
{
    public static bool ValidateUser(string username, string password)
        => username == "testuser" && password == "Test@123";
}
