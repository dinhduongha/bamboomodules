
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Models;
using Bamboo.Core.Services;

namespace Bamboo.Core.Controllers;

[Area(CoreRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CoreRemoteServiceConsts.RemoteServiceName)]
[Route("api/v1/core/PaymentProviderOnboardingWizard")]
//[Authorize]
public partial class PaymentProviderOnboardingWizardController : CoreController, IPaymentProviderOnboardingWizardAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IPaymentProviderOnboardingWizardAppService _AppService;
    
    public PaymentProviderOnboardingWizardController(IDataFilter dataFilter, IPaymentProviderOnboardingWizardAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<PaymentProviderOnboardingWizard> CreateAsync(PaymentProviderOnboardingWizard input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<PaymentProviderOnboardingWizard> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<PaymentProviderOnboardingWizard>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<PaymentProviderOnboardingWizard> UpdateAsync(Guid id, PaymentProviderOnboardingWizard input)
    {
        return await _AppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await _AppService.DeleteAsync(id);
    }
}
