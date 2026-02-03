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
    public interface ILoyaltyCardAppService : IGenericAppService<LoyaltyCard>
    {
        Task<LoyaltyCard> ArchiveAsync(Guid[] ids);
        Task<LoyaltyCard> CouponSendAsync(Guid[] ids);
        Task<LoyaltyCard> CouponShareAsync(Guid[] ids);
        Task<LoyaltyCard> GetGiftCardStatusAsync(LoyaltyCardGetGiftCardStatusRequestDto input);
        Task<LoyaltyCard> GetLoyaltyCardPartnerByCodeAsync(LoyaltyCardGetLoyaltyCardPartnerByCodeRequestDto input);
        Task<LoyaltyCard> LoyaltyUpdateBalanceAsync(Guid[] ids);
    }
}