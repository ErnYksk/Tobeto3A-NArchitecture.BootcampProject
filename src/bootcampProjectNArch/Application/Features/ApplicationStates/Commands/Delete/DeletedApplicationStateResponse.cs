using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStates.Commands.Delete;

public class DeletedApplicationStateResponse : IResponse
{
    public int Id { get; set; }
}
