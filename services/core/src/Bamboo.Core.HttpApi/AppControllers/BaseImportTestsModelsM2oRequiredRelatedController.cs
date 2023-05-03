
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
[Route("api/v1/core/BaseImportTestsModelsM2oRequiredRelated")]
//[Authorize]
public partial class BaseImportTestsModelsM2oRequiredRelatedController : CoreController, IBaseImportTestsModelsM2oRequiredRelatedAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IBaseImportTestsModelsM2oRequiredRelatedAppService _AppService;
    
    public BaseImportTestsModelsM2oRequiredRelatedController(IDataFilter dataFilter, IBaseImportTestsModelsM2oRequiredRelatedAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<BaseImportTestsModelsM2oRequiredRelated> CreateAsync(BaseImportTestsModelsM2oRequiredRelated input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<BaseImportTestsModelsM2oRequiredRelated> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<BaseImportTestsModelsM2oRequiredRelated>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<BaseImportTestsModelsM2oRequiredRelated> UpdateAsync(Guid id, BaseImportTestsModelsM2oRequiredRelated input)
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
