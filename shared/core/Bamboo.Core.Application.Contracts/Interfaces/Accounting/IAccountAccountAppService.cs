using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IAccountAccountAppService : IGenericApplicationService<AccountAccount>
    {
        Task<AccountAccount> CopyDataAsync(AccountAccountCopyDataRequestDto input);
        Task<AccountAccount> CopyTranslationsAsync(AccountAccountCopyTranslationsRequestDto input);
        Task<AccountAccount> GetAccountGroupAsync(AccountAccountGetAccountGroupRequestDto input);
        Task<AccountAccount> GetImportTemplatesAsync(Guid[] ids);
        Task<AccountAccount> OpenRelatedTaxesAsync(Guid[] ids);
        Task<AccountAccount> SpreadsheetFetchBalanceTagAsync(AccountAccountSpreadsheetFetchBalanceTagRequestDto input);
        Task<AccountAccount> SpreadsheetFetchDebitCreditAsync(AccountAccountSpreadsheetFetchDebitCreditRequestDto input);
        Task<AccountAccount> SpreadsheetFetchPartnerBalanceAsync(AccountAccountSpreadsheetFetchPartnerBalanceRequestDto input);
        Task<AccountAccount> SpreadsheetFetchResidualAmountAsync(AccountAccountSpreadsheetFetchResidualAmountRequestDto input);
        Task<AccountAccount> SpreadsheetMoveLineActionAsync(AccountAccountSpreadsheetMoveLineActionRequestDto input);
        Task<AccountAccount> UnmergeAsync(Guid[] ids);
    }
}