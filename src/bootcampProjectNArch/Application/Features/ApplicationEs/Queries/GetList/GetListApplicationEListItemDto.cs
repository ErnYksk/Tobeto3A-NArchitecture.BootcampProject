using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ApplicationEs.Queries.GetList;

public class GetListApplicationEListItemDto : IDto
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }
}
