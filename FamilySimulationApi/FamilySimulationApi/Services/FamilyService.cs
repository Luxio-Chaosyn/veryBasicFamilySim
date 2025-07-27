using FamilySimulationApi.DTO;
using FamilySimulationApi.Models;

namespace FamilySimulationApi.Services;

public class FamilyService(NameService nameService)
{
    private static readonly string[] LastNames = ["Smith", "Johnson", "Lee", "Brown"];
    private readonly Random _rand = new();
    private readonly NameService _nameService = nameService;

    public Person GenerateFamily(int generations, int childrenPerFamily, int currentGen = 1)
    {
        var name = $"{RandomFirstName()} {LastNames[_rand.Next(LastNames.Length)]}";
        var person = new Person { Name = name, Generation = currentGen };

        if (generations > 1)
        {
            for (int i = 0; i < childrenPerFamily; i++)
            {
                person.Children.Add(GenerateFamily(generations - 1, childrenPerFamily, currentGen + 1));
            }
        }

        return person;
    }

    private string RandomFirstName()
    {
        var names = _nameService.GetAll().ToList();
        return names.Count == 0 ? "Unknown" : names[_rand.Next(names.Count)];
    }

    public FamilyResponseDto MapToDto(Person person)
    {
        return new FamilyResponseDto
        {
            Name = person.Name,
            Generation = person.Generation,
            Children = person.Children.Select(MapToDto).ToList()
        };
    }
}

