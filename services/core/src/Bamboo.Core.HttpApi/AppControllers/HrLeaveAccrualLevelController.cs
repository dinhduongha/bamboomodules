
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
[Route("api/v1/core/HrLeaveAccrualLevel")]
//[Authorize]
public partial class HrLeaveAccrualLevelController : CoreController, IHrLeaveAccrualLevelAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IHrLeaveAccrualLevelAppService _AppService;
    
    public HrLeaveAccrualLevelController(IDataFilter dataFilter, IHrLeaveAccrualLevelAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<HrLeaveAccrualLevel> CreateAsync(HrLeaveAccrualLevel input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<HrLeaveAccrualLevel> GetAsync(long id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<HrLeaveAccrualLevel>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<HrLeaveAccrualLevel> UpdateAsync(long id, HrLeaveAccrualLevel input)
    {
        return await _AppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task DeleteAsync(long id)
    {
        await _AppService.DeleteAsync(id);
    }
}
