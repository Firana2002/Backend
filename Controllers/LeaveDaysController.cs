using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
public class LeaveDaysController : ControllerBase
{
    private readonly VacationPlanningContext _context;

    public LeaveDaysController(VacationPlanningContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaveDays>>> GetLeaveDays()
    {
        return await _context.LeaveDays.Include(ld => ld.Employee).Include(ld => ld.LeaveType).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveDays>> GetLeaveDays(int id)
    {
        var leaveDays = await _context.LeaveDays.Include(ld => ld.Employee).Include(ld => ld.LeaveType).FirstOrDefaultAsync(ld => ld.Id == id);
        if (leaveDays == null) return NotFound();
        return leaveDays;
    }

    [HttpPost]
    public async Task<ActionResult<LeaveDays>> PostLeaveDays(LeaveDays leaveDays)
    {
        _context.LeaveDays.Add(leaveDays);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetLeaveDays", new { id = leaveDays.Id }, leaveDays);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLeaveDays(int id, LeaveDays leaveDays)
    {
        if (id != leaveDays.Id) return BadRequest();
        _context.Entry(leaveDays).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LeaveDaysExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeaveDays(int id)
    {
        var leaveDays = await _context.LeaveDays.FindAsync(id);
        if (leaveDays == null) return NotFound();

        _context.LeaveDays.Remove(leaveDays);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LeaveDaysExists(int id)
    {
        return _context.LeaveDays.Any(e => e.Id == id);
    }
}
