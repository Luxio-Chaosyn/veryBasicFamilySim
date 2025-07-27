namespace FamilySimulationApi.Models;

public class Person
{
    public string Name { get; set; } = default!;
    public int Generation { get; set; }
    public List<Person> Children { get; set; } = new();
}
