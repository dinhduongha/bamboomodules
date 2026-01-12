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
        Task<ResCurrency> AmountToTextAsync(Guid id, ResCurrencyAmountToTextRequestDto input);
        Task<ResCurrency> CompareAmountsAsync(Guid id, ResCurrencyCompareAmountsRequestDto input);
        Task<ResCurrency> FormatAsync(Guid id, ResCurrencyFormatRequestDto input);
        Task<ResCurrency> GetCompanyCurrencyForSpreadsheetAsync(Guid id, ResCurrencyGetCompanyCurrencyForSpreadsheetRequestDto input);
        Task<ResCurrency> IsZeroAsync(Guid id, ResCurrencyIsZeroRequestDto input);
        Task<ResCurrency> RoundAsync(Guid id, ResCurrencyRoundRequestDto input);
    }
}