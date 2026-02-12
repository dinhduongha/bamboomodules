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
    [Module("BaseModule", Category = "Base")]
    public partial class IrModelAppService : GenericAppService<IrModel>, IIrModelAppService
    {

        public IrModelAppService(IRepository<IrModel, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<IrModel> DisplayNameForAsync(IrModelDisplayNameForRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_model.py, METHOD: display_name_for) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModel> GetAuthorizedFieldsAsync(IrModelGetAuthorizedFieldsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_form.py, METHOD: get_authorized_fields) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModel> GetAvailableModelsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_model.py, METHOD: get_available_models) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModel> GetCompatibleFormModelsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_form.py, METHOD: get_compatible_form_models) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModel> HasSearchableParentRelationAsync(IrModelHasSearchableParentRelationRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: ir_model.py, METHOD: has_searchable_parent_relation) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_model.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<IrModel> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_model.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}