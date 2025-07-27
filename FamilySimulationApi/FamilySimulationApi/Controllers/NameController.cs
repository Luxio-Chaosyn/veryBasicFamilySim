using FamilySimulationApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilySimulationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NameController(NameService nameService) : ControllerBase
{
    /// <summary>
    /// Liste tous les prénoms disponibles.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<string>), 200)]
    public IActionResult GetAll() => Ok(nameService.GetAll());

    /// <summary>
    /// Ajoute un nouveau prénom.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(409)]
    public IActionResult Add([FromBody] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Name cannot be empty.");

        if (!nameService.Add(name))
            return Conflict("Name already exists.");

        return CreatedAtAction(nameof(GetAll), new { name }, name);
    }

    /// <summary>
    /// Met à jour un prénom existant.
    /// </summary>
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult Update([FromQuery] string oldName, [FromQuery] string newName)
    {
        if (!nameService.Update(oldName, newName))
            return NotFound("Name not found or new name already exists.");

        return NoContent();
    }

    /// <summary>
    /// Supprime un prénom.
    /// </summary>
    [HttpDelete]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult Delete([FromQuery] string name)
    {
        if (!nameService.Delete(name))
            return NotFound("Name not found.");

        return NoContent();
    }
}
