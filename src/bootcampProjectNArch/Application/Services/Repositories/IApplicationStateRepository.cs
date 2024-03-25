using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicationStateRepository : IAsyncRepository<ApplicationState, int>, IRepository<ApplicationState, int> { }
