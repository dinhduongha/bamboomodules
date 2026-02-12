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
    [Module("Sms", Category = "Sales", Depends = new[] { "base", "iap_mail", "mail", "phone_validation" })]
    public partial class SmsSmsAppService : GenericAppService<SmsSms>, ISmsSmsAppService
    {

        public SmsSmsAppService(IRepository<SmsSms, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public override async Task<SmsSms> CreateAsync(CreateRequestDto<SmsSms> input)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(FieldsGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py, METHOD: fields_get) ---
            */
            return await base.FieldsGetAsync(input);
        }

        public async Task<SmsSms> ResendFailedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: resend_failed) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SmsSms> SendAsync(SmsSmsSendRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: send) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SmsSms> SetCanceledAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: action_set_canceled) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SmsSms> SetErrorAsync(SmsSmsSetErrorRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: action_set_error) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SmsSms> SetOutgoingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_sms.py, METHOD: action_set_outgoing) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}