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
    public partial class IrModelFieldsAppService : GenericAppService<IrModelFields>, IIrModelFieldsAppService
    {

        public IrModelFieldsAppService(IRepository<IrModelFields, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<IrModelFields> FormbuilderWhitelistAsync(IrModelFieldsFormbuilderWhitelistRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_form.py, METHOD: formbuilder_whitelist) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModelFields> GetFieldHelpAsync(IrModelFieldsGetFieldHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: get_field_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModelFields> GetFieldSelectionAsync(IrModelFieldsGetFieldSelectionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: get_field_selection) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrModelFields> GetFieldStringAsync(IrModelFieldsGetFieldStringRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: get_field_string) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrModelFields> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_form.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_model_fields.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<IrModelFields> input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_sparse_field, FILE: models.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}