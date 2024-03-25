using System.Xml.Linq;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BootcampState : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<Bootcamp> Bootcamps { get; set; }

    public BootcampState()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }

    public BootcampState(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
