using BytteApp.Models;

namespace BytteApp.Service;

public class UserService // Definere klassen UserService
{
    private List<User> users = new() //Opretter liste af brugere
    {
        new User { // Et objekt kaldet User
            userid = "A",
            Name = "Mohamed",
            UserNameid = "Mohamed33",
            Password = "mohamed123",
            Email = "mohamed@eaaa.dk",
            PhoneNumber = 13131313, },
        
        new User { 
            userid = "B",
            Name = "Simon",
            UserNameid = "Simon33",
            Password = "simon123",
            Email = "simon@eaaa.dk",
            PhoneNumber = 12121212, },
        
        new User { userid = "C",
            Name = "Oskar",
            UserNameid = "Oskar33",
            Password = "oskar123",
            Email = "oskar@eaaa.dk",
            PhoneNumber = 14141414, }
    };

    public User? Login(string usernameid, string password) // Metode kaldet Login. Modtager usernameid og password
    {
        var user = users.FirstOrDefault(u => // søger i listen over users og finder den hvor brugernavn og password matcher
            u.UserNameid.Equals(usernameid, StringComparison.OrdinalIgnoreCase)
            && u.Password == password);

        CurrentUser = user; // Hvis de matcher gemmes brugeren i CurrentUser så der huskes hvem der er logget ind
        return user; // returnere user hvis det matcher, returnere null hvis det ikke matcher
    }

    public User? CurrentUser { get; set; } // sætter egenskaben CurrentUser
}