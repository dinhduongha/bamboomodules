
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
[Route("api/v1/core/BaseImportTestsModelsCharReadonly")]
//[Authorize]
public partial class BaseImportTestsModelsCharReadonlyController : CoreController, IBaseImportTestsModelsCharReadonlyAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IBaseImportTestsModelsCharReadonlyAppService _AppService;
    
    public BaseImportTestsModelsCharReadonlyController(IDataFilter dataFilter, IBaseImportTestsModelsCharReadonlyAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<BaseImportTestsModelsCharReadonly> CreateAsync(BaseImportTestsModelsCharReadonly input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<BaseImportTestsModelsCharReadonly> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<BaseImportTestsModelsCharReadonly>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<BaseImportTestsModelsCharReadonly> UpdateAsync(Guid id, BaseImportTestsModelsCharReadonly input)
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
