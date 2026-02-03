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
    public interface IResCurrencyAppService : IGenericApplicationService<ResCurrency>
    {
        Task<ResCurrency> AmountToTextAsync(ResCurrencyAmountToTextRequestDto input);
        Task<ResCurrency> CompareAmountsAsync(ResCurrencyCompareAmountsRequestDto input);
        Task<ResCurrency> FormatAsync(ResCurrencyFormatRequestDto input);
        Task<ResCurrency> GetAllCurrenciesAsync(Guid[] ids);
        Task<ResCurrency> GetCompanyCurrencyForSpreadsheetAsync(ResCurrencyGetCompanyCurrencyForSpreadsheetRequestDto input);
        Task<ResCurrency> IsZeroAsync(ResCurrencyIsZeroRequestDto input);
        Task<ResCurrency> RoundAsync(ResCurrencyRoundRequestDto input);
    }
}