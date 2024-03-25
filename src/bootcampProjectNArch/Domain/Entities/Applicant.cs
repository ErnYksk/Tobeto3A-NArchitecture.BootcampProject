using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Applicant : User
{
    public string About { get; set; }
    public virtual Blacklist? BlackList { get; set; }
    public virtual ICollection<ApplicationE> Applications { get; set; }

    public Applicant()
    {
        Applications = new HashSet<ApplicationE>();
    }

    public Applicant(Guid id, string about)
    {
        Id = id;
        About = about;
    }
}
