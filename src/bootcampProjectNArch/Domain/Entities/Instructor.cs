using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Instructor : User
{
    public string CompanyName { get; set; }
    public virtual ICollection<Bootcamp> Bootcamps { get; set; }

    public Instructor()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }

    public Instructor(Guid id, string companyName)
    {
        Id = id;
        CompanyName = companyName;
    }
}
