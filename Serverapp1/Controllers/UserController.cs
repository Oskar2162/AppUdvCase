using Core;
using Microsoft.AspNetCore.Mvc;
using Serverapp1.Repositories;
using Serverapp1.Model;
using Serverapp1.Repositories;

namespace Serverapp1.Controllers;

// [ApiController] gør klassen til en web-API controller
[ApiController]
// Route: "api/users"
[Route("api/users")]
public class UserController : ControllerBase
{
    // Repository til at arbejde med User-data i databasen
    private readonly UsersRepository _userRepo;

    // Constructoren får UsersRepository ind via dependency injection
    public UserController(UsersRepository userRepo)
    {
        // Gemmer repositoryet, så vi kan bruge det i metoderne
        _userRepo = userRepo;
    }

    // GET: api/users
    // Endpoint til at hente alle brugere
    [HttpGet]
    public ActionResult<List<User>> GetAll()
    {
        // Henter alle brugere fra databasen via repositoryet
        var users = _userRepo.GetAll();

        // Returnerer brugerne i et HTTP 200 OK-svar
        return Ok(users);
    }

    // POST: api/users/seed
    // Endpoint til at "seed'e" (fylde med nogle standardbrugere)
    [HttpPost("seed")]
    public IActionResult Seed()
    {
        // Sletter alle eksisterende brugere fra databasen
        _userRepo.DeleteAll();

        // Opretter tre nye User-objekter med fast data
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

        // Samler de tre brugere i en liste
        var users = new List<User> { user1, user2, user3 };

        // Kalder repositoryet for at gemme dem i databasen
        _userRepo.CreateUsers(users);

        // Svarer tilbage med en tekst-besked om at seeding er sket
        return Ok("Seeded 3 users");
    }

    // POST: api/users/login
    // Endpoint til login – tjekker brugernavn og password
    [HttpPost("login")]
    public ActionResult<User> Login([FromBody] LoginRequest req)
    {
        // Simpel validering: begge felter skal være udfyldt
        if (string.IsNullOrWhiteSpace(req.UserNameid) || string.IsNullOrWhiteSpace(req.Password))
            return BadRequest("Username og password skal udfyldes");

        // Henter alle brugere (i en rigtig app ville man normalt filtrere direkte i databasen)
        var allUsers = _userRepo.GetAll();

        // Finder første bruger, hvor både UserNameid og Password matcher input
        var user = allUsers.FirstOrDefault(u =>
            u.UserNameid == req.UserNameid && u.Password == req.Password);

        // Hvis der ikke findes en matchende bruger → returner HTTP 401 Unauthorized
        if (user == null)
            return Unauthorized("Forkert brugernavn eller adgangskode");

        // Ellers returneres brugeren som OK-svar
        return Ok(user);
    }

    // Intern klasse brugt som model til login-requesten
    public class LoginRequest
    {
        // Brugernavn, som sendes ind i login-request body
        public string UserNameid { get; set; } = "";
        // Password, som sendes ind i login-request body
        public string Password { get; set; } = "";
    }
}
