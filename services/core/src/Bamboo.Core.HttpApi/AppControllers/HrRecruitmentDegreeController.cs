
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
[Route("api/v1/core/HrRecruitmentDegree")]
//[Authorize]
public partial class HrRecruitmentDegreeController : CoreController, IHrRecruitmentDegreeAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IHrRecruitmentDegreeAppService _AppService;
    
    public HrRecruitmentDegreeController(IDataFilter dataFilter, IHrRecruitmentDegreeAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<HrRecruitmentDegree> CreateAsync(HrRecruitmentDegree input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<HrRecruitmentDegree> GetAsync(long id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<HrRecruitmentDegree>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<HrRecruitmentDegree> UpdateAsync(long id, HrRecruitmentDegree input)
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
