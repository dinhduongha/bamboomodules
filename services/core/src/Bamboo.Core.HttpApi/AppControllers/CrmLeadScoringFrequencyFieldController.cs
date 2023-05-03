
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
[Route("api/v1/core/CrmLeadScoringFrequencyField")]
//[Authorize]
public partial class CrmLeadScoringFrequencyFieldController : CoreController, ICrmLeadScoringFrequencyFieldAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly ICrmLeadScoringFrequencyFieldAppService _AppService;
    
    public CrmLeadScoringFrequencyFieldController(IDataFilter dataFilter, ICrmLeadScoringFrequencyFieldAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<CrmLeadScoringFrequencyField> CreateAsync(CrmLeadScoringFrequencyField input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<CrmLeadScoringFrequencyField> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<CrmLeadScoringFrequencyField>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<CrmLeadScoringFrequencyField> UpdateAsync(Guid id, CrmLeadScoringFrequencyField input)
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
