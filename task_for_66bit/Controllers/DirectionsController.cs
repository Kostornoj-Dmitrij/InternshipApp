using task_for_66bit.Data.Models;
using task_for_66bit.Services;
using Microsoft.AspNetCore.Mvc;

namespace task_for_66bit.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectionsController : ControllerBase
{
    private readonly DirectionService _directionService;

    public DirectionsController(DirectionService directionService)
    {
        _directionService = directionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Direction>>> GetAll()
    {
        return Ok(await _directionService.GetAllDirectionsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Direction>> GetById(int id)
    {
        var direction = await _directionService.GetDirectionByIdAsync(id);
        if (direction == null)
        {
            return NotFound();
        }
        return Ok(direction);
    }

    [HttpPost]
    public async Task<ActionResult<Direction>> Create(Direction direction)
    {
        await _directionService.AddDirectionAsync(direction);
        return CreatedAtAction(nameof(GetById), new { id = direction.Id }, direction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Direction direction)
    {
        if (id != direction.Id)
        {
            return BadRequest();
        }

        await _directionService.UpdateDirectionAsync(direction);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _directionService.DeleteDirectionAsync(id);
        return NoContent();
    }
}