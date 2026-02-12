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
    [Module("LinkTrackerModule", Category = "Marketing", Depends = new[] { "utm", "mail" })]
    public partial class LinkTrackerClickAppService : GenericAppService<LinkTrackerClick>, ILinkTrackerClickAppService
    {

        public LinkTrackerClickAppService(IRepository<LinkTrackerClick, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<LinkTrackerClick> AddClickAsync(LinkTrackerClickAddClickRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: add_click) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: link_tracker.py, METHOD: add_click) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}