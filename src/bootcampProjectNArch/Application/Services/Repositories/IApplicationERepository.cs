using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicationERepository : IAsyncRepository<ApplicationE, int>, IRepository<ApplicationE, int> { }
