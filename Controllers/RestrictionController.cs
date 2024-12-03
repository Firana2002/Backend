using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[Route("api/[controller]")]
[ApiController]
public class RestrictionController : ControllerBase
{
    private readonly VacationPlanningContext _context;

    public RestrictionController(VacationPlanningContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Restriction>>> GetRestrictions()
    {
        return await _context.Restrictions.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restriction>> GetRestriction(int id)
    {
        var restriction = await _context.Restrictions.FindAsync(id);
        if (restriction == null) return NotFound();
        return restriction;
    }

    [HttpPost]
    public async Task<ActionResult<Restriction>> PostRestriction(Restriction restriction)
    {
        _context.Restrictions.Add(restriction);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetRestriction", new { id = restriction.Id }, restriction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutRestriction(int id, Restriction restriction)
    {
        if (id != restriction.Id) return BadRequest();
        _context.Entry(restriction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RestrictionExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestriction(int id)
    {
        var restriction = await _context.Restrictions.FindAsync(id);
        if (restriction == null) return NotFound();

        _context.Restrictions.Remove(restriction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RestrictionExists(int id)
    {
        return _context.Restrictions.Any(e => e.Id == id);
    }
}
