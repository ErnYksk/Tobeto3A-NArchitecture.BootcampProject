using Application.Features.ApplicationEs.Commands.Create;
using Application.Features.ApplicationEs.Commands.Delete;
using Application.Features.ApplicationEs.Commands.Update;
using Application.Features.ApplicationEs.Queries.GetById;
using Application.Features.ApplicationEs.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ApplicationEs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationE, CreateApplicationECommand>().ReverseMap();
        CreateMap<ApplicationE, CreatedApplicationEResponse>().ReverseMap();
        CreateMap<ApplicationE, UpdateApplicationECommand>().ReverseMap();
        CreateMap<ApplicationE, UpdatedApplicationEResponse>().ReverseMap();
        CreateMap<ApplicationE, DeleteApplicationECommand>().ReverseMap();
        CreateMap<ApplicationE, DeletedApplicationEResponse>().ReverseMap();
        CreateMap<ApplicationE, GetByIdApplicationEResponse>().ReverseMap();
        CreateMap<ApplicationE, GetListApplicationEListItemDto>().ReverseMap();
        CreateMap<IPaginate<ApplicationE>, GetListResponse<GetListApplicationEListItemDto>>().ReverseMap();
    }
}
