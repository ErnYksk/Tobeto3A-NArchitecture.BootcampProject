using Application.Features.ApplicationEs.Constants;
using Application.Features.ApplicationEs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.ApplicationEs.Constants.ApplicationEsOperationClaims;

namespace Application.Features.ApplicationEs.Queries.GetById;

public class GetByIdApplicationEQuery : IRequest<GetByIdApplicationEResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdApplicationEQueryHandler : IRequestHandler<GetByIdApplicationEQuery, GetByIdApplicationEResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationERepository _applicationERepository;
        private readonly ApplicationEBusinessRules _applicationEBusinessRules;

        public GetByIdApplicationEQueryHandler(
            IMapper mapper,
            IApplicationERepository applicationERepository,
            ApplicationEBusinessRules applicationEBusinessRules
        )
        {
            _mapper = mapper;
            _applicationERepository = applicationERepository;
            _applicationEBusinessRules = applicationEBusinessRules;
        }

        public async Task<GetByIdApplicationEResponse> Handle(
            GetByIdApplicationEQuery request,
            CancellationToken cancellationToken
        )
        {
            ApplicationE? applicationE = await _applicationERepository.GetAsync(
                predicate: ae => ae.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicationEBusinessRules.ApplicationEShouldExistWhenSelected(applicationE);

            GetByIdApplicationEResponse response = _mapper.Map<GetByIdApplicationEResponse>(applicationE);
            return response;
        }
    }
}
