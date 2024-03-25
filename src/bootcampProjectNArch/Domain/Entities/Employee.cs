using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Employee : User
{
    public string Position { get; set; }

    public Employee() { }

    public Employee(Guid id, string position)
    {
        Id = id;
        Position = position;
    }
}
