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
    public interface ILoyaltyCardAppService : IGenericApplicationService<LoyaltyCard>
    {
        Task<LoyaltyCard> ArchiveAsync(Guid id);
        Task<LoyaltyCard> CouponSendAsync(Guid id);
        Task<LoyaltyCard> CouponShareAsync(Guid id);
        Task<LoyaltyCard> GetGiftCardStatusAsync(Guid id, LoyaltyCardGetGiftCardStatusRequestDto input);
        Task<LoyaltyCard> GetLoyaltyCardPartnerByCodeAsync(Guid id, LoyaltyCardGetLoyaltyCardPartnerByCodeRequestDto input);
        Task<LoyaltyCard> LoyaltyUpdateBalanceAsync(Guid id);
    }
}