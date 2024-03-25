using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicationERepository : EfRepositoryBase<ApplicationE, int, BaseDbContext>, IApplicationERepository
{
    public ApplicationERepository(BaseDbContext context)
        : base(context) { }
}
