using Core;
using Microsoft.AspNetCore.Mvc;
using Serverapp1.Repositories;

namespace Serverapp1.Controllers;

// [ApiController] fortæller ASP.NET, at denne klasse er en web-API controller
[ApiController]
// [Route("api/[controller]")] betyder, at route bliver "api/annonce" (navnet på klassen uden "Controller")
[Route("api/[controller]")]
public class AnnonceController : ControllerBase
{
    // Repository-feltet, som vi bruger til at snakke med databasen om annoncer
    private readonly AnnonceRepository repository;

    // Constructoren oprettes, når controlleren bliver skabt
    public AnnonceController()
    {
        // Vi laver et nyt AnnonceRepository-objekt
        // Herfra kan vi kalde metoder som GetAll(), GetAnnonceById(), CreateAnnonce() osv.
        this.repository = new AnnonceRepository();
    }

    // GET: api/annonce
    // [HttpGet] betyder, at denne metode svarer på GET-requests til "api/annonce"
    [HttpGet]
    public ActionResult<List<Annonce>> GetAll()
    {
        // Henter alle annoncer fra repositoryet og returnerer dem som svar
        return repository.GetAll();
    }

    // GET: api/annonce/123
    // [HttpGet("{id:int}")] betyder, at der skal være et heltals-id i URL'en, fx "api/annonce/5"
    [HttpGet("{id:int}")]
    public ActionResult<Annonce> GetById(int id)
    {
        // Slår annoncen op i databasen via repositoryet
        var a = repository.GetAnnonceById(id);

        // Hvis der ikke blev fundet nogen annonce, svarer vi med HTTP 404 (NotFound)
        if (a == null) return NotFound();

        // Ellers returnerer vi annoncen (HTTP 200 OK)
        return a;
    }
    
    // GET: api/annonce/by-user/{userid}
    // Endpoint til at hente alle annoncer for en bestemt bruger
    [HttpGet("by-user/{userid}")]
    public ActionResult<List<Annonce>> GetByUser(string userid)
    {
        // Tjekker om userid er tomt eller kun mellemrum
        if (string.IsNullOrWhiteSpace(userid)) return BadRequest("userid mangler");

        // Henter alle annoncer, der tilhører den givne bruger
        var list = repository.GetByUserId(userid);

        // Returnerer listen i et HTTP 200 OK-svar
        return Ok(list);
    }

    // POST: api/annonce
    // [HttpPost] betyder, at denne metode svarer på POST-requests til "api/annonce"
    [HttpPost]
    public IActionResult Create([FromBody] Annonce annonce)
    {
        // Bruger repositoryet til at oprette (indsætte) en ny annonce i databasen
        repository.CreateAnnonce(annonce);

        // Returnerer HTTP 201 Created
        // CreatedAtAction fortæller klienten, hvor den nye ressource kan hentes (via GetById)
        return CreatedAtAction(nameof(GetById), new { id = annonce.annonceid }, annonce);
    }

    // DELETE: api/annonce/123
    // [HttpDelete("{id:int}")] svarer på DELETE-requests til fx "api/annonce/10"
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        // Beder repositoryet slette annoncen med det givne id
        repository.DeleteById(id);

        // Returnerer HTTP 204 NoContent (betyder: operationen lykkedes, men der er ingen body)
        return NoContent();
    }
}
