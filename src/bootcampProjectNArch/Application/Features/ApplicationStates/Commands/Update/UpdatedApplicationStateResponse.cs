using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStates.Commands.Update;

public class UpdatedApplicationStateResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
