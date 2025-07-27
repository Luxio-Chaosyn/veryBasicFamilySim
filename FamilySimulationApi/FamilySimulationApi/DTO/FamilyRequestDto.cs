using System.ComponentModel.DataAnnotations;

namespace FamilySimulationApi.DTO;

public class FamilyRequestDto
{
    [Required]
    [Range(1, 10)]
    public int Generations { get; set; }

    [Required]
    [Range(1, 10)]
    public int ChildrenPerFamily { get; set; }
}
