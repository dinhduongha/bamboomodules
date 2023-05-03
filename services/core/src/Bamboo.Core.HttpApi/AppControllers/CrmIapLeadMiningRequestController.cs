
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
[Route("api/v1/core/CrmIapLeadMiningRequest")]
//[Authorize]
public partial class CrmIapLeadMiningRequestController : CoreController, ICrmIapLeadMiningRequestAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly ICrmIapLeadMiningRequestAppService _AppService;
    
    public CrmIapLeadMiningRequestController(IDataFilter dataFilter, ICrmIapLeadMiningRequestAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<CrmIapLeadMiningRequest> CreateAsync(CrmIapLeadMiningRequest input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<CrmIapLeadMiningRequest> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<CrmIapLeadMiningRequest>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<CrmIapLeadMiningRequest> UpdateAsync(Guid id, CrmIapLeadMiningRequest input)
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
