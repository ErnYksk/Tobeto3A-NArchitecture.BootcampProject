using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ApplicationState : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<ApplicationE> Applications { get; set; }

    public ApplicationState()
    {
        Applications = new HashSet<ApplicationE>();
    }

    public ApplicationState(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
