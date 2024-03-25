using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampStates.Queries.GetById;

public class GetByIdBootcampStateResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
