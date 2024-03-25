using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationEs.Queries.GetById;

public class GetByIdApplicationEResponse : IResponse
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }
}
