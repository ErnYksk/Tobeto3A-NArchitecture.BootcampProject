using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.ApplicationEs;

public interface IApplicationEService
{
    Task<ApplicationE?> GetAsync(
        Expression<Func<ApplicationE, bool>> predicate,
        Func<IQueryable<ApplicationE>, IIncludableQueryable<ApplicationE, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ApplicationE>?> GetListAsync(
        Expression<Func<ApplicationE, bool>>? predicate = null,
        Func<IQueryable<ApplicationE>, IOrderedQueryable<ApplicationE>>? orderBy = null,
        Func<IQueryable<ApplicationE>, IIncludableQueryable<ApplicationE, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ApplicationE> AddAsync(ApplicationE applicationE);
    Task<ApplicationE> UpdateAsync(ApplicationE applicationE);
    Task<ApplicationE> DeleteAsync(ApplicationE applicationE, bool permanent = false);
}
