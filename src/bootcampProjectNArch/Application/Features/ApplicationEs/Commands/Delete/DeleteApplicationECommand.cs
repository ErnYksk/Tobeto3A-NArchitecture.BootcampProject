using Application.Features.ApplicationEs.Constants;
using Application.Features.ApplicationEs.Constants;
using Application.Features.ApplicationEs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.ApplicationEs.Constants.ApplicationEsOperationClaims;

namespace Application.Features.ApplicationEs.Commands.Delete;

public class DeleteApplicationECommand
    : IRequest<DeletedApplicationEResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ApplicationEsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationEs"];

    public class DeleteApplicationECommandHandler : IRequestHandler<DeleteApplicationECommand, DeletedApplicationEResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationERepository _applicationERepository;
        private readonly ApplicationEBusinessRules _applicationEBusinessRules;

        public DeleteApplicationECommandHandler(
            IMapper mapper,
            IApplicationERepository applicationERepository,
            ApplicationEBusinessRules applicationEBusinessRules
        )
        {
            _mapper = mapper;
            _applicationERepository = applicationERepository;
            _applicationEBusinessRules = applicationEBusinessRules;
        }

        public async Task<DeletedApplicationEResponse> Handle(
            DeleteApplicationECommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationE? applicationE = await _applicationERepository.GetAsync(
                predicate: ae => ae.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicationEBusinessRules.ApplicationEShouldExistWhenSelected(applicationE);

            await _applicationERepository.DeleteAsync(applicationE!);

            DeletedApplicationEResponse response = _mapper.Map<DeletedApplicationEResponse>(applicationE);
            return response;
        }
    }
}
