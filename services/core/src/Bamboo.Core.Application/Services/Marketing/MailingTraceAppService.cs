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
    [Module("MassMailing", Category = "Marketing", Depends = new[] { "contacts", "mail", "html_builder", "utm", "link_tracker", "social_media", "web_tour", "digest" })]
    public partial class MailingTraceAppService : GenericAppService<MailingTrace>, IMailingTraceAppService
    {

        public MailingTraceAppService(IRepository<MailingTrace, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public override async Task<MailingTrace> CreateAsync(CreateRequestDto<MailingTrace> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_trace.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(FieldsGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_trace.py, METHOD: fields_get) ---
            */
            return await base.FieldsGetAsync(input);
        }

        public async Task<MailingTrace> SetBouncedAsync(MailingTraceSetBouncedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: set_bounced) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingTrace> SetCanceledAsync(MailingTraceSetCanceledRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: set_canceled) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingTrace> SetClickedAsync(MailingTraceSetClickedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: set_clicked) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingTrace> SetFailedAsync(MailingTraceSetFailedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: set_failed) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingTrace> SetOpenedAsync(MailingTraceSetOpenedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: set_opened) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingTrace> SetRepliedAsync(MailingTraceSetRepliedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: set_replied) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingTrace> SetSentAsync(MailingTraceSetSentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: set_sent) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingTrace> ViewContactAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py, METHOD: action_view_contact) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}