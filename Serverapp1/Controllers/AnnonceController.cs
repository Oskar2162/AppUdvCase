using Core;
using Microsoft.AspNetCore.Mvc;
using Serverapp1.Repositories;

namespace Serverapp1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnnonceController : ControllerBase
{
    private readonly AnnonceRepository repository;

    public AnnonceController()
    {
        this.repository = new AnnonceRepository();
    }

    // GET: api/annonce
    [HttpGet]
    public ActionResult<List<Annonce>> GetAll()
    {
        return repository.GetAll();
    }

    // GET: api/annonce/123
    [HttpGet("{id:int}")]
    public ActionResult<Annonce> GetById(int id)
    {
        var a = repository.GetAnnonceById(id);
        if (a == null) return NotFound();
        return a;
    }

    // POST: api/annonce
    [HttpPost]
    public IActionResult Create([FromBody] Annonce annonce)
    {
        repository.CreateAnnonce(annonce);
        return CreatedAtAction(nameof(GetById), new { id = annonce.annonceid }, annonce);
    }

    // DELETE: api/annonce/123
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        repository.DeleteById(id);
        return NoContent();
    }
}