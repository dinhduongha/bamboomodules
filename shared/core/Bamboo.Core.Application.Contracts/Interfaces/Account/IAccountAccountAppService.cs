using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IAccountAccountAppService : IGenericApplicationService<AccountAccount>
    {
        Task<AccountAccount> CopyDataAsync(Guid id, AccountAccountCopyDataRequestDto input);
        Task<AccountAccount> CopyTranslationsAsync(Guid id, AccountAccountCopyTranslationsRequestDto input);
        Task<AccountAccount> GetAccountGroupAsync(Guid id, AccountAccountGetAccountGroupRequestDto input);
        Task<AccountAccount> GetImportTemplatesAsync(Guid id);
        Task<AccountAccount> OpenRelatedTaxesAsync(Guid id);
        Task<AccountAccount> SpreadsheetFetchDebitCreditAsync(Guid id, AccountAccountSpreadsheetFetchDebitCreditRequestDto input);
        Task<AccountAccount> SpreadsheetFetchPartnerBalanceAsync(Guid id, AccountAccountSpreadsheetFetchPartnerBalanceRequestDto input);
        Task<AccountAccount> SpreadsheetFetchResidualAmountAsync(Guid id, AccountAccountSpreadsheetFetchResidualAmountRequestDto input);
        Task<AccountAccount> SpreadsheetMoveLineActionAsync(Guid id, AccountAccountSpreadsheetMoveLineActionRequestDto input);
        Task<AccountAccount> UnmergeAsync(Guid id);
    }
}