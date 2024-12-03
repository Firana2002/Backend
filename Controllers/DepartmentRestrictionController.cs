using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;[Route("api/[controller]")]
[ApiController]
public class DepartmentRestrictionController : ControllerBase
{
    private readonly VacationPlanningContext _context;

    public DepartmentRestrictionController(VacationPlanningContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentRestriction>>> GetDepartmentRestrictions()
    {
        return await _context.DepartmentRestrictions.Include(dr => dr.Department).Include(dr => dr.Restriction).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentRestriction>> GetDepartmentRestriction(int id)
    {
        var departmentRestriction = await _context.DepartmentRestrictions.Include(dr => dr.Department).Include(dr => dr.Restriction).FirstOrDefaultAsync(dr => dr.Id == id);
        if (departmentRestriction == null) return NotFound();
        return departmentRestriction;
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentRestriction>> PostDepartmentRestriction(DepartmentRestriction departmentRestriction)
    {
        _context.DepartmentRestrictions.Add(departmentRestriction);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetDepartmentRestriction", new { id = departmentRestriction.Id }, departmentRestriction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDepartmentRestriction(int id, DepartmentRestriction departmentRestriction)
    {
        if (id != departmentRestriction.Id) return BadRequest();
        _context.Entry(departmentRestriction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DepartmentRestrictionExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartmentRestriction(int id)
    {
        var departmentRestriction = await _context.DepartmentRestrictions.FindAsync(id);
        if (departmentRestriction == null) return NotFound();

        _context.DepartmentRestrictions.Remove(departmentRestriction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DepartmentRestrictionExists(int id)
    {
        return _context.DepartmentRestrictions.Any(e => e.Id == id);
    }
}
