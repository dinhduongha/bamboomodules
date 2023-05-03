
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
[Route("api/v1/core/AccountBankStatementImportJournalCreation")]
//[Authorize]
public partial class AccountBankStatementImportJournalCreationController : CoreController, IAccountBankStatementImportJournalCreationAppService
{
    private readonly IDataFilter _dataFilter;
    private readonly IAccountBankStatementImportJournalCreationAppService _AppService;
    
    public AccountBankStatementImportJournalCreationController(IDataFilter dataFilter, IAccountBankStatementImportJournalCreationAppService AppService)
    {
        _dataFilter = dataFilter;
        _AppService = AppService;
    }

    [HttpPost]
    public async Task<AccountBankStatementImportJournalCreation> CreateAsync(AccountBankStatementImportJournalCreation input)
    {
        return await _AppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<AccountBankStatementImportJournalCreation> GetAsync(Guid id)
    {
        return await _AppService.GetAsync(id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedResultDto<AccountBankStatementImportJournalCreation>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await _AppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<AccountBankStatementImportJournalCreation> UpdateAsync(Guid id, AccountBankStatementImportJournalCreation input)
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
