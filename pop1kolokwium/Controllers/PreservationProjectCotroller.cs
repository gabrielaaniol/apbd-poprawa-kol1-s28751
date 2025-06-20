using Microsoft.AspNetCore.Mvc;
using pop1kolokwium.Services;

namespace pop1kolokwium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PreservationProjectCotroller : ControllerBase
{
    private readonly IDbService _service;

    public PreservationProjectCotroller(IDbService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPreservationProject(int id)
    {
        try
        {
            var visit = await _service.GetPreservationProject(id);
            if (visit is null)
                return NotFound($"Nie znaleziono  ID {id}");

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Błąd serwera: {ex.Message}");
        }
    }
}