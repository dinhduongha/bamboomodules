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
    [Module("Web", Category = "Website", Depends = new[] { "base" })]
    public partial class BaseDocumentLayoutAppService : GenericAppService<BaseDocumentLayout>, IBaseDocumentLayoutAppService
    {

        public BaseDocumentLayoutAppService(IRepository<BaseDocumentLayout, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<BaseDocumentLayout> DocumentLayoutSaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: document_layout_save) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<BaseDocumentLayout> ExtractImagePrimarySecondaryColorsAsync(BaseDocumentLayoutExtractImagePrimarySecondaryColorsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: base_document_layout.py, METHOD: extract_image_primary_secondary_colors) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}