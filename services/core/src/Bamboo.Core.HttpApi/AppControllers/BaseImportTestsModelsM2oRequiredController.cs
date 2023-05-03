
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
[Route("api/v1/core/BaseImportTestsModelsM2oRequired")]
//[Authorize]
public partial class BaseImportTestsModelsM2oRequiredController : CoreController, IBaseImportTestsModelsM2oRequiredAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IBaseImportTestsModelsM2oRequiredAppService _AppService;
    
    public BaseImportTestsModelsM2oRequiredController(IDataFilter dataFilter, IBaseImportTestsModelsM2oRequiredAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<BaseImportTestsModelsM2oRequired> CreateAsync(BaseImportTestsModelsM2oRequired input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<BaseImportTestsModelsM2oRequired> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<BaseImportTestsModelsM2oRequired>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<BaseImportTestsModelsM2oRequired> UpdateAsync(Guid id, BaseImportTestsModelsM2oRequired input)
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
