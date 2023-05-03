
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
[Route("api/v1/core/AccountFiscalPositionTaxTemplate")]
//[Authorize]
public partial class AccountFiscalPositionTaxTemplateController : CoreController, IAccountFiscalPositionTaxTemplateAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IAccountFiscalPositionTaxTemplateAppService _AppService;
    
    public AccountFiscalPositionTaxTemplateController(IDataFilter dataFilter, IAccountFiscalPositionTaxTemplateAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<AccountFiscalPositionTaxTemplate> CreateAsync(AccountFiscalPositionTaxTemplate input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<AccountFiscalPositionTaxTemplate> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<AccountFiscalPositionTaxTemplate>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<AccountFiscalPositionTaxTemplate> UpdateAsync(Guid id, AccountFiscalPositionTaxTemplate input)
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
