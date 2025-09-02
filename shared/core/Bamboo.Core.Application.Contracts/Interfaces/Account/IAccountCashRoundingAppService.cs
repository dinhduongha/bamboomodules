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
    public interface IAccountCashRoundingAppService : IGenericApplicationService<AccountCashRounding>
    {
        Task<AccountCashRounding> ComputeDifferenceAsync(Guid id, AccountCashRoundingComputeDifferenceRequestDto input);
        Task<AccountCashRounding> RoundAsync(Guid id, AccountCashRoundingRoundRequestDto input);
        Task<AccountCashRounding> ValidateRoundingAsync(Guid id);
    }
}