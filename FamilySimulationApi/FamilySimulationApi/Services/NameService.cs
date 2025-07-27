namespace FamilySimulationApi.Services;

public class NameService
{
    private readonly List<string> _firstNames = new() { "Alex", "Jordan", "Taylor", "Morgan" };

    public IEnumerable<string> GetAll() => _firstNames;

    public bool Add(string name)
    {
        if (_firstNames.Contains(name, StringComparer.OrdinalIgnoreCase))
            return false;

        _firstNames.Add(name);
        return true;
    }

    public bool Update(string oldName, string newName)
    {
        var index = _firstNames.FindIndex(n => n.Equals(oldName, StringComparison.OrdinalIgnoreCase));
        if (index == -1 || _firstNames.Contains(newName, StringComparer.OrdinalIgnoreCase))
            return false;

        _firstNames[index] = newName;
        return true;
    }

    public bool Delete(string name)
    {
        return _firstNames.RemoveAll(n => n.Equals(name, StringComparison.OrdinalIgnoreCase)) > 0;
    }
}
