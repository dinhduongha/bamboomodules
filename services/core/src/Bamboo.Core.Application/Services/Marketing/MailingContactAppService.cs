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
    public partial class MailingContactAppService : GenericAppService<MailingContact>, IMailingContactAppService
    {
        protected readonly IMailThreadBlacklistAppService _mailThreadBlacklistAppService;
        protected readonly IMailThreadPhoneAppService _mailThreadPhoneAppService;
        protected readonly IPropertiesBaseDefinitionMixinAppService _propertiesBaseDefinitionMixinAppService;
        public MailingContactAppService(IRepository<MailingContact, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadBlacklistAppService mailThreadBlacklistAppService, IMailThreadPhoneAppService mailThreadPhoneAppService, IPropertiesBaseDefinitionMixinAppService propertiesBaseDefinitionMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadBlacklistAppService = mailThreadBlacklistAppService;
            _mailThreadPhoneAppService = mailThreadPhoneAppService;
            _propertiesBaseDefinitionMixinAppService = propertiesBaseDefinitionMixinAppService;
        }

        [ApiModel]
        public async Task<MailingContact> AddToListAsync(MailingContactAddToListRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: add_to_list) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingContact> AddToMailingListAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: action_add_to_mailing_list) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<MailingContact> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingContact> ImportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: action_import) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}