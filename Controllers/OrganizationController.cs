using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    private readonly VacationPlanningContext _context;

    public OrganizationController(VacationPlanningContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizations()
    {
        return await _context.Organizations.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Organization>> GetOrganization(int id)
    {
        var organization = await _context.Organizations.FindAsync(id);
        if (organization == null) return NotFound();
        return organization;
    }

    [HttpPost]
    public async Task<ActionResult<Organization>> PostOrganization(Organization organization)
    {
        _context.Organizations.Add(organization);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrganization(int id, Organization organization)
    {
        if (id != organization.Id) return BadRequest();
        _context.Entry(organization).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrganizationExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrganization(int id)
    {
        var organization = await _context.Organizations.FindAsync(id);
        if (organization == null) return NotFound();

        _context.Organizations.Remove(organization);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrganizationExists(int id)
    {
        return _context.Organizations.Any(e => e.Id == id);
    }
}
