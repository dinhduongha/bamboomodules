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
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailMessageSubtypeAppService : GenericAppService<MailMessageSubtype>, IMailMessageSubtypeAppService
    {

        public MailMessageSubtypeAppService(IRepository<MailMessageSubtype, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public override async Task<MailMessageSubtype> CreateAsync(CreateRequestDto<MailMessageSubtype> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: mail_message_subtype.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<MailMessageSubtype> DefaultSubtypesAsync(MailMessageSubtypeDefaultSubtypesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py, METHOD: default_subtypes) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<MailMessageSubtype> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: mail_message_subtype.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}