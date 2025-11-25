namespace Carquitecture.Domain;

public class Owner
{
    public Owner(string name, string surname, bool active)
    {
        Name = name;
        Surname = surname;
        Active = active;
    }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public bool Active { get; set; }

    public ICollection<Vehicle> Vehicles { get; } = [];
}