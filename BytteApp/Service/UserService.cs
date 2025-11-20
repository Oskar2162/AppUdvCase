using BytteApp.Models;

namespace BytteApp.Service;

public class UserService
{
    private List<User> users = new()
    {
        new User { Username = "mohammed", Password = "test123" },
        new User { Username = "simon", Password = "test123" },
        new User { Username = "oscar", Password = "test123" }
    };

    public User? Login(string username, string password)
    {
        return users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
            && u.Password == password);
    }
}