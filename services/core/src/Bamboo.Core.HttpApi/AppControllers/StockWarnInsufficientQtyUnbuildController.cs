
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
[Route("api/v1/core/StockWarnInsufficientQtyUnbuild")]
//[Authorize]
public partial class StockWarnInsufficientQtyUnbuildController : CoreController, IStockWarnInsufficientQtyUnbuildAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IStockWarnInsufficientQtyUnbuildAppService _AppService;
    
    public StockWarnInsufficientQtyUnbuildController(IDataFilter dataFilter, IStockWarnInsufficientQtyUnbuildAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<StockWarnInsufficientQtyUnbuild> CreateAsync(StockWarnInsufficientQtyUnbuild input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<StockWarnInsufficientQtyUnbuild> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<StockWarnInsufficientQtyUnbuild>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<StockWarnInsufficientQtyUnbuild> UpdateAsync(Guid id, StockWarnInsufficientQtyUnbuild input)
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
