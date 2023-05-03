
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
[Route("api/v1/core/BaseImportTestsModelsM2oRelated")]
//[Authorize]
public partial class BaseImportTestsModelsM2oRelatedController : CoreController, IBaseImportTestsModelsM2oRelatedAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IBaseImportTestsModelsM2oRelatedAppService _AppService;
    
    public BaseImportTestsModelsM2oRelatedController(IDataFilter dataFilter, IBaseImportTestsModelsM2oRelatedAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<BaseImportTestsModelsM2oRelated> CreateAsync(BaseImportTestsModelsM2oRelated input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<BaseImportTestsModelsM2oRelated> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<BaseImportTestsModelsM2oRelated>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<BaseImportTestsModelsM2oRelated> UpdateAsync(Guid id, BaseImportTestsModelsM2oRelated input)
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
