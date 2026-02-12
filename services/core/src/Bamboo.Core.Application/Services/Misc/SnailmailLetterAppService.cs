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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Snailmail", Category = "Misc", Depends = new[] { "iap_mail", "mail" })]
    public partial class SnailmailLetterAppService : GenericAppService<SnailmailLetter>, ISnailmailLetterAppService
    {

        public SnailmailLetterAppService(IRepository<SnailmailLetter, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<SnailmailLetter> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SnailmailLetter> SnailmailPrintAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: snailmail_print) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}