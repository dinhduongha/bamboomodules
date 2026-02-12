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
    [Module("EventBoothModule", Category = "Marketing", Depends = new[] { "event" })]
    public partial class EventBoothAppService : GenericAppService<EventBooth>, IEventBoothAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public EventBoothAppService(IRepository<EventBooth, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<EventBooth> ConfirmAsync(EventBoothConfirmRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: action_confirm) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventBooth> SetPaidAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth.py, METHOD: action_set_paid) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventBooth> ViewSaleOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth.py, METHOD: action_view_sale_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventBooth> ViewSponsorAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth_exhibitor, FILE: event_booth.py, METHOD: action_view_sponsor) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}