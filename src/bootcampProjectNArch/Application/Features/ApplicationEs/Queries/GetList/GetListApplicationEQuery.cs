using Application.Features.ApplicationEs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.ApplicationEs.Constants.ApplicationEsOperationClaims;

namespace Application.Features.ApplicationEs.Queries.GetList;

public class GetListApplicationEQuery
    : IRequest<GetListResponse<GetListApplicationEListItemDto>>,
        ISecuredRequest,
        ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListApplicationEs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetApplicationEs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListApplicationEQueryHandler
        : IRequestHandler<GetListApplicationEQuery, GetListResponse<GetListApplicationEListItemDto>>
    {
        private readonly IApplicationERepository _applicationERepository;
        private readonly IMapper _mapper;

        public GetListApplicationEQueryHandler(IApplicationERepository applicationERepository, IMapper mapper)
        {
            _applicationERepository = applicationERepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationEListItemDto>> Handle(
            GetListApplicationEQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<ApplicationE> applicationEs = await _applicationERepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListApplicationEListItemDto> response = _mapper.Map<
                GetListResponse<GetListApplicationEListItemDto>
            >(applicationEs);
            return response;
        }
    }
}
