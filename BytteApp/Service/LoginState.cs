namespace BytteApp.Service;

public class LoginState // definere klassen LoginState som viser logintilstanden på brugeren
{
    public string? LoggedInUser { get; private set; }

    public void Login(string username) => LoggedInUser = username; //
    public void Logout() => LoggedInUser = null; // metode der sætter LoggedInUser til null
    public bool IsLoggedIn() => LoggedInUser != null; // tjekker om nogen er logget ind. Hvis LoggedInUser ikke er null returnere den true
}