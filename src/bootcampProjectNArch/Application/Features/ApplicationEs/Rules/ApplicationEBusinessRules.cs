using Application.Features.ApplicationEs.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.ApplicationEs.Rules;

public class ApplicationEBusinessRules : BaseBusinessRules
{
    private readonly IApplicationERepository _applicationERepository;
    private readonly ILocalizationService _localizationService;

    public ApplicationEBusinessRules(IApplicationERepository applicationERepository, ILocalizationService localizationService)
    {
        _applicationERepository = applicationERepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ApplicationEsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ApplicationEShouldExistWhenSelected(ApplicationE? applicationE)
    {
        if (applicationE == null)
            await throwBusinessException(ApplicationEsBusinessMessages.ApplicationENotExists);
    }

    public async Task ApplicationEIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ApplicationE? applicationE = await _applicationERepository.GetAsync(
            predicate: ae => ae.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicationEShouldExistWhenSelected(applicationE);
    }
}
