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
    public interface ILoyaltyCardAppService : IGenericApplicationService<LoyaltyCard>
    {
        Task<LoyaltyCard> CouponSendAsync(Guid id);
        Task<LoyaltyCard> CouponShareAsync(Guid id);
        Task<LoyaltyCard> LoyaltyUpdateBalanceAsync(Guid id);
    }
}