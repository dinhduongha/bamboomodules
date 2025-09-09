using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IAccountCashRoundingAppService : IGenericApplicationService<AccountCashRounding>
    {
        Task<AccountCashRounding> ComputeDifferenceAsync(Guid id, AccountCashRoundingComputeDifferenceRequestDto input);
        Task<AccountCashRounding> RoundAsync(Guid id, AccountCashRoundingRoundRequestDto input);
        Task<AccountCashRounding> ValidateRoundingAsync(Guid id);
    }
}