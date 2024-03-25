using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationEs.Commands.Update;

public class UpdatedApplicationEResponse : IResponse
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }
}
