using System.Linq.Expressions;
using Application.Features.ApplicationEs.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.ApplicationEs;

public class ApplicationEManager : IApplicationEService
{
    private readonly IApplicationERepository _applicationERepository;
    private readonly ApplicationEBusinessRules _applicationEBusinessRules;

    public ApplicationEManager(
        IApplicationERepository applicationERepository,
        ApplicationEBusinessRules applicationEBusinessRules
    )
    {
        _applicationERepository = applicationERepository;
        _applicationEBusinessRules = applicationEBusinessRules;
    }

    public async Task<ApplicationE?> GetAsync(
        Expression<Func<ApplicationE, bool>> predicate,
        Func<IQueryable<ApplicationE>, IIncludableQueryable<ApplicationE, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ApplicationE? applicationE = await _applicationERepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationE;
    }

    public async Task<IPaginate<ApplicationE>?> GetListAsync(
        Expression<Func<ApplicationE, bool>>? predicate = null,
        Func<IQueryable<ApplicationE>, IOrderedQueryable<ApplicationE>>? orderBy = null,
        Func<IQueryable<ApplicationE>, IIncludableQueryable<ApplicationE, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ApplicationE> applicationEList = await _applicationERepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationEList;
    }

    public async Task<ApplicationE> AddAsync(ApplicationE applicationE)
    {
        ApplicationE addedApplicationE = await _applicationERepository.AddAsync(applicationE);

        return addedApplicationE;
    }

    public async Task<ApplicationE> UpdateAsync(ApplicationE applicationE)
    {
        ApplicationE updatedApplicationE = await _applicationERepository.UpdateAsync(applicationE);

        return updatedApplicationE;
    }

    public async Task<ApplicationE> DeleteAsync(ApplicationE applicationE, bool permanent = false)
    {
        ApplicationE deletedApplicationE = await _applicationERepository.DeleteAsync(applicationE);

        return deletedApplicationE;
    }
}
