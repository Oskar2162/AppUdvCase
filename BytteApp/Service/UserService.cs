using BytteApp.Models;

namespace BytteApp.Service;

public class UserService
{
    private List<User> users = new()
    {
        new User { 
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

    public User? Login(string usernameid, string password)
    {
        var user = users.FirstOrDefault(u =>
            u.UserNameid.Equals(usernameid, StringComparison.OrdinalIgnoreCase)
            && u.Password == password);

        CurrentUser = user;
        return user;
    }

    public User? CurrentUser { get; set; }
}