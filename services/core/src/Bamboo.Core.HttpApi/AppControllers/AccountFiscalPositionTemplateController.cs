
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
[Route("api/v1/core/AccountFiscalPositionTemplate")]
//[Authorize]
public partial class AccountFiscalPositionTemplateController : CoreController, IAccountFiscalPositionTemplateAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IAccountFiscalPositionTemplateAppService _AppService;
    
    public AccountFiscalPositionTemplateController(IDataFilter dataFilter, IAccountFiscalPositionTemplateAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<AccountFiscalPositionTemplate> CreateAsync(AccountFiscalPositionTemplate input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<AccountFiscalPositionTemplate> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<AccountFiscalPositionTemplate>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<AccountFiscalPositionTemplate> UpdateAsync(Guid id, AccountFiscalPositionTemplate input)
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
