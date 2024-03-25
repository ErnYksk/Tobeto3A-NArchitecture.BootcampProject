using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampStates.Commands.Update;

public class UpdatedBootcampStateResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
