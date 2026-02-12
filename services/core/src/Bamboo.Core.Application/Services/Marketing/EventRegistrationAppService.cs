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
    [Module("Event", Category = "Marketing", Depends = new[] { "barcodes", "base_setup", "mail", "phone_validation", "portal", "utm" })]
    public partial class EventRegistrationAppService : GenericAppService<EventRegistration>, IEventRegistrationAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public EventRegistrationAppService(IRepository<EventRegistration, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<EventRegistration> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventRegistration> ConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<EventRegistration> CreateAsync(CreateRequestDto<EventRegistration> input)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<EventRegistration> RegisterAttendeeAsync(EventRegistrationRegisterAttendeeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: register_attendee) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventRegistration> SendBadgeEmailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_send_badge_email) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventRegistration> SetDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_set_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventRegistration> SetDraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_set_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventRegistration> ViewPosOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py, METHOD: action_view_pos_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventRegistration> ViewSaleOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: action_view_sale_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<EventRegistration> input)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}