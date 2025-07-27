namespace FamilySimulationApi.DTO;

public class FamilyResponseDto
{
    public string Name { get; set; } = default!;
    public int Generation { get; set; }
    public List<FamilyResponseDto> Children { get; set; } = new();
}