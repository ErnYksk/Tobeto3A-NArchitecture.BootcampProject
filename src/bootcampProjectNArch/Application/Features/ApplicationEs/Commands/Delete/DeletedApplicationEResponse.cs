using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationEs.Commands.Delete;

public class DeletedApplicationEResponse : IResponse
{
    public int Id { get; set; }
}
