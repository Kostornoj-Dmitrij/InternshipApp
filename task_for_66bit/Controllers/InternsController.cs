using task_for_66bit.Data.Models;
using task_for_66bit.Services;
using Microsoft.AspNetCore.Mvc;

namespace task_for_66bit.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InternsController : ControllerBase
{
    private readonly InternService _internService;

    public InternsController(InternService internService)
    {
        _internService = internService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Intern>>> GetAll()
    {
        return Ok(await _internService.GetAllInternsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Intern>> GetById(int id)
    {
        var intern = await _internService.GetInternByIdAsync(id);
        return Ok(intern);
    }

    [HttpPost]
    public async Task<ActionResult<Intern>> Create(Intern intern)
    {
        await _internService.AddInternAsync(intern);
        return CreatedAtAction(nameof(GetById), new { id = intern.Id }, intern);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Intern intern)
    {
        if (id != intern.Id)
        {
            return BadRequest();
        }

        await _internService.UpdateInternAsync(intern);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _internService.DeleteInternAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}