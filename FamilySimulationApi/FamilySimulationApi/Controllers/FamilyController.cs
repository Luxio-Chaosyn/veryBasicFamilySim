using FamilySimulationApi.DTO;
using FamilySimulationApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilySimulationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FamilyController(FamilyService familyService) : ControllerBase
{
    /// <summary>
    /// Simule un arbre familial sur plusieurs générations.
    /// </summary>
    /// <remarks>Génère une famille avec un nombre défini de générations et d’enfants par couple.</remarks>
    [HttpPost("simulate")]
    [Authorize]
    [ProducesResponseType(typeof(FamilyResponseDto), 200)]
    [ProducesResponseType(400)]
    public IActionResult SimulateFamily([FromBody] FamilyRequestDto request)
    {
        var root = familyService.GenerateFamily(request.Generations, request.ChildrenPerFamily);
        return Ok(familyService.MapToDto(root));
    }
}
