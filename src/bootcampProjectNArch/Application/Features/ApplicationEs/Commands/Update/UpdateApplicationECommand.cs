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

namespace Application.Features.ApplicationEs.Commands.Update;

public class UpdateApplicationECommand
    : IRequest<UpdatedApplicationEResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }

    public string[] Roles => [Admin, Write, ApplicationEsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationEs"];

    public class UpdateApplicationECommandHandler : IRequestHandler<UpdateApplicationECommand, UpdatedApplicationEResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationERepository _applicationERepository;
        private readonly ApplicationEBusinessRules _applicationEBusinessRules;

        public UpdateApplicationECommandHandler(
            IMapper mapper,
            IApplicationERepository applicationERepository,
            ApplicationEBusinessRules applicationEBusinessRules
        )
        {
            _mapper = mapper;
            _applicationERepository = applicationERepository;
            _applicationEBusinessRules = applicationEBusinessRules;
        }

        public async Task<UpdatedApplicationEResponse> Handle(
            UpdateApplicationECommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationE? applicationE = await _applicationERepository.GetAsync(
                predicate: ae => ae.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicationEBusinessRules.ApplicationEShouldExistWhenSelected(applicationE);
            applicationE = _mapper.Map(request, applicationE);

            await _applicationERepository.UpdateAsync(applicationE!);

            UpdatedApplicationEResponse response = _mapper.Map<UpdatedApplicationEResponse>(applicationE);
            return response;
        }
    }
}
