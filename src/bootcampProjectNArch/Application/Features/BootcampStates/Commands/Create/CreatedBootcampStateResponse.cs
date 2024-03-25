using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampStates.Commands.Create;

public class CreatedBootcampStateResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
