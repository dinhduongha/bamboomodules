
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
[Route("api/v1/core/ThemeWebsitePage")]
//[Authorize]
public partial class ThemeWebsitePageController : CoreController, IThemeWebsitePageAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IThemeWebsitePageAppService _AppService;
    
    public ThemeWebsitePageController(IDataFilter dataFilter, IThemeWebsitePageAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<ThemeWebsitePage> CreateAsync(ThemeWebsitePage input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<ThemeWebsitePage> GetAsync(long id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<ThemeWebsitePage>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ThemeWebsitePage> UpdateAsync(long id, ThemeWebsitePage input)
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
