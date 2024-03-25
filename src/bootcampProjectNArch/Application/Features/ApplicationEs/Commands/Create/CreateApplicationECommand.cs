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

namespace Application.Features.ApplicationEs.Commands.Create;

public class CreateApplicationECommand
    : IRequest<CreatedApplicationEResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest
{
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }

    public string[] Roles => [Admin, Write, ApplicationEsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationEs"];

    public class CreateApplicationECommandHandler : IRequestHandler<CreateApplicationECommand, CreatedApplicationEResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationERepository _applicationERepository;
        private readonly ApplicationEBusinessRules _applicationEBusinessRules;

        public CreateApplicationECommandHandler(
            IMapper mapper,
            IApplicationERepository applicationERepository,
            ApplicationEBusinessRules applicationEBusinessRules
        )
        {
            _mapper = mapper;
            _applicationERepository = applicationERepository;
            _applicationEBusinessRules = applicationEBusinessRules;
        }

        public async Task<CreatedApplicationEResponse> Handle(
            CreateApplicationECommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationE applicationE = _mapper.Map<ApplicationE>(request);

            await _applicationERepository.AddAsync(applicationE);

            CreatedApplicationEResponse response = _mapper.Map<CreatedApplicationEResponse>(applicationE);
            return response;
        }
    }
}
