using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController : ControllerBase
{
    private readonly VacationPlanningContext _context;

    public LeaveTypeController(VacationPlanningContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaveType>>> GetLeaveTypes()
    {
        return await _context.LeaveTypes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveType>> GetLeaveType(int id)
    {
        var leaveType = await _context.LeaveTypes.FindAsync(id);
        if (leaveType == null) return NotFound();
        return leaveType;
    }

    [HttpPost]
    public async Task<ActionResult<LeaveType>> PostLeaveType(LeaveType leaveType)
    {
        _context.LeaveTypes.Add(leaveType);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetLeaveType", new { id = leaveType.Id }, leaveType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLeaveType(int id, LeaveType leaveType)
    {
        if (id != leaveType.Id) return BadRequest();
        _context.Entry(leaveType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LeaveTypeExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeaveType(int id)
    {
        var leaveType = await _context.LeaveTypes.FindAsync(id);
        if (leaveType == null) return NotFound();

        _context.LeaveTypes.Remove(leaveType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
}
