
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
[Route("api/v1/core/CrmLead2opportunityPartnerMass")]
//[Authorize]
public partial class CrmLead2opportunityPartnerMassController : CoreController, ICrmLead2opportunityPartnerMassAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly ICrmLead2opportunityPartnerMassAppService _AppService;
    
    public CrmLead2opportunityPartnerMassController(IDataFilter dataFilter, ICrmLead2opportunityPartnerMassAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<CrmLead2opportunityPartnerMass> CreateAsync(CrmLead2opportunityPartnerMass input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<CrmLead2opportunityPartnerMass> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<CrmLead2opportunityPartnerMass>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<CrmLead2opportunityPartnerMass> UpdateAsync(Guid id, CrmLead2opportunityPartnerMass input)
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
