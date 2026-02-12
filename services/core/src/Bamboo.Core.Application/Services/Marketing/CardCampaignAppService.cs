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
    [Module("MarketingCard", Category = "Marketing", Depends = new[] { "link_tracker", "mass_mailing", "website" })]
    public partial class CardCampaignAppService : GenericAppService<CardCampaign>, ICardCampaignAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailRenderMixinAppService _mailRenderMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public CardCampaignAppService(IRepository<CardCampaign, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailRenderMixinAppService mailRenderMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailRenderMixinAppService = mailRenderMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<CardCampaign> PreviewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_preview) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CardCampaign> ShareAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_share) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CardCampaign> ViewCardsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_cards) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CardCampaign> ViewCardsClickedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_cards_clicked) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CardCampaign> ViewCardsSharedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_cards_shared) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CardCampaign> ViewMailingsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_mailings) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}