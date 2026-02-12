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
    [Module("Utm", Category = "Marketing", Depends = new[] { "base", "web" })]
    public partial class UtmMediumAppService : GenericAppService<UtmMedium>, IUtmMediumAppService
    {

        public UtmMediumAppService(IRepository<UtmMedium, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<UtmMedium> SELFREQUIREDUTMMEDIUMSREFAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py, METHOD: SELF_REQUIRED_UTM_MEDIUMS_REF) ---
            --- METHOD SOURCE (MODULE: utm, FILE: utm_medium.py, METHOD: SELF_REQUIRED_UTM_MEDIUMS_REF) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}