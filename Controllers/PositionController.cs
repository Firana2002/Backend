using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[Route("api/[controller]")]
[ApiController]
public class PositionController : ControllerBase
{
    private readonly VacationPlanningContext _context;

    public PositionController(VacationPlanningContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
    {
        return await _context.Positions.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Position>> GetPosition(int id)
    {
        var position = await _context.Positions.FindAsync(id);
        if (position == null) return NotFound();
        return position;
    }

    [HttpPost]
    public async Task<ActionResult<Position>> PostPosition(Position position)
    {
        _context.Positions.Add(position);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetPosition", new { id = position.Id }, position);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPosition(int id, Position position)
    {
        if (id != position.Id) return BadRequest();
        _context.Entry(position).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PositionExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePosition(int id)
    {
        var position = await _context.Positions.FindAsync(id);
        if (position == null) return NotFound();

        _context.Positions.Remove(position);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PositionExists(int id)
    {
        return _context.Positions.Any(e => e.Id == id);
    }
}
