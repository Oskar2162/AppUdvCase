namespace BytteApp.Service;

public class LoginState
{
    public string? LoggedInUser { get; private set; }

    public void Login(string username) => LoggedInUser = username;
    public void Logout() => LoggedInUser = null;
    public bool IsLoggedIn() => LoggedInUser != null;
}