using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
public class HolidayController : ControllerBase
{
    private readonly VacationPlanningContext _context;

    public HolidayController(VacationPlanningContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Holiday>>> GetHolidays()
    {
        return await _context.Holidays.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Holiday>> GetHoliday(int id)
    {
        var holiday = await _context.Holidays.FindAsync(id);
        if (holiday == null) return NotFound();
        return holiday;
    }

    [HttpPost]
    public async Task<ActionResult<Holiday>> PostHoliday(Holiday holiday)
    {
        _context.Holidays.Add(holiday);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetHoliday", new { id = holiday.Id }, holiday);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutHoliday(int id, Holiday holiday)
    {
        if (id != holiday.Id) return BadRequest();
        _context.Entry(holiday).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HolidayExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHoliday(int id)
    {
        var holiday = await _context.Holidays.FindAsync(id);
        if (holiday == null) return NotFound();

        _context.Holidays.Remove(holiday);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HolidayExists(int id)
    {
        return _context.Holidays.Any(e => e.Id == id);
    }
}
