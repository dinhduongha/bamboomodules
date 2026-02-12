using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Loyalty", Category = "Sales", Depends = new[] { "product", "portal", "account" })]
    public partial class LoyaltyCardAppService : GenericAppService<LoyaltyCard>, ILoyaltyCardAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public LoyaltyCardAppService(IRepository<LoyaltyCard, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<LoyaltyCard> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LoyaltyCard> CouponSendAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: action_coupon_send) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LoyaltyCard> CouponShareAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: loyalty_card.py, METHOD: action_coupon_share) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<LoyaltyCard> GetGiftCardStatusAsync(LoyaltyCardGetGiftCardStatusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py, METHOD: get_gift_card_status) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<LoyaltyCard> GetLoyaltyCardPartnerByCodeAsync(LoyaltyCardGetLoyaltyCardPartnerByCodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py, METHOD: get_loyalty_card_partner_by_code) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LoyaltyCard> LoyaltyUpdateBalanceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: action_loyalty_update_balance) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}