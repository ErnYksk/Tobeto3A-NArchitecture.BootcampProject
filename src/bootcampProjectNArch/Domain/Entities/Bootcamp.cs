﻿using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Bootcamp : Entity<int>
{
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public int BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual Instructor? Instructor { get; set; }
    public virtual BootcampState? BootcampState { get; set; }
    public virtual ICollection<ApplicationE> Applications { get; set; }
    public virtual ICollection<BootcampImage> BootcampImages { get; set; }

    public Bootcamp()
    {
        Applications = new HashSet<ApplicationE>();
        BootcampImages = new HashSet<BootcampImage>();
    }

    public Bootcamp(int id, Guid instructorId, int bootcampStateId, string name, DateTime startDate, DateTime endDate)
        : this()
    {
        Id = id;
        InstructorId = instructorId;
        BootcampStateId = bootcampStateId;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Bootcamp(Guid instructorId, int bootcampStateId, string name, DateTime startDate, DateTime endDate)
        : this()
    {
        InstructorId = instructorId;
        BootcampStateId = bootcampStateId;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }
}
