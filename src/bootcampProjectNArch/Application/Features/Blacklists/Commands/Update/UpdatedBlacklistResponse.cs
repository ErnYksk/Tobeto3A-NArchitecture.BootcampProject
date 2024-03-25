using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blacklists.Commands.Update;

public class UpdatedBlacklistResponse : IResponse
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public string? Reason { get; set; }
    public DateTime? Date { get; set; }
}
