using Core;
using Microsoft.AspNetCore.Mvc;
using Serverapp1.Repositories;
using Serverapp1.Model;
using Serverapp1.Repositories;

namespace Serverapp1.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UsersRepository _userRepo;

    public UserController(UsersRepository userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet]
    public ActionResult<List<User>> GetAll()
    {
        var users = _userRepo.GetAll();
        return Ok(users);
    }


    [HttpPost("seed")]
    public IActionResult Seed()
    {
        _userRepo.DeleteAll();

        var user1 = new User
        {
            userid = 1,
            Name = "Mohamed",
            UserNameid = "Mohamed33",
            Password = "mohamed123",
            Email = "mohamed@eaaa.dk",
            PhoneNumber = 13131313,

        };

        var user2 = new User
        {
            userid = 2,
            Name = "Simon",
            UserNameid = "Simon33",
            Password = "simon123",
            Email = "simon@eaaa.dk",
            PhoneNumber = 12121212,

        };

        var user3 = new User
        {
            userid = 3,
            Name = "Oskar",
            UserNameid = "Oskar33",
            Password = "oskar123",
            Email = "oskar@eaaa.dk",
            PhoneNumber = 14141414,

        };

        var users = new List<User> { user1, user2, user3 };

        _userRepo.CreateUsers(users);

        return Ok("Seeded 3 users");
    }


    [HttpPost("login")]
    public ActionResult<User> Login([FromBody] LoginRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.UserNameid) || string.IsNullOrWhiteSpace(req.Password))
            return BadRequest("Username og password skal udfyldes");

        var allUsers = _userRepo.GetAll();

        var user = allUsers.FirstOrDefault(u =>
            u.UserNameid == req.UserNameid && u.Password == req.Password);

        if (user == null)
            return Unauthorized("Forkert brugernavn eller adgangskode");

        return Ok(user);
    }


    public class LoginRequest
    {
        public string UserNameid { get; set; } = "";
        public string Password { get; set; } = "";
    }

}
