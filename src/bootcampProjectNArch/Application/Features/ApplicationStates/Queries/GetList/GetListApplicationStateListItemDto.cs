using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ApplicationStates.Queries.GetList;

public class GetListApplicationStateListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
