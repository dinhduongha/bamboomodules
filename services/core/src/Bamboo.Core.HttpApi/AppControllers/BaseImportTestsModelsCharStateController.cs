
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
[Route("api/v1/core/BaseImportTestsModelsCharState")]
//[Authorize]
public partial class BaseImportTestsModelsCharStateController : CoreController, IBaseImportTestsModelsCharStateAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IBaseImportTestsModelsCharStateAppService _AppService;
    
    public BaseImportTestsModelsCharStateController(IDataFilter dataFilter, IBaseImportTestsModelsCharStateAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<BaseImportTestsModelsCharState> CreateAsync(BaseImportTestsModelsCharState input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<BaseImportTestsModelsCharState> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<BaseImportTestsModelsCharState>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<BaseImportTestsModelsCharState> UpdateAsync(Guid id, BaseImportTestsModelsCharState input)
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
