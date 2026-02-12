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
    public partial class IrConfigParameterAppService : GenericAppService<IrConfigParameter>, IIrConfigParameterAppService
    {

        public IrConfigParameterAppService(IRepository<IrConfigParameter, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public override async Task<IrConfigParameter> CreateAsync(CreateRequestDto<IrConfigParameter> input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: ir_config_parameter.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<IrConfigParameter> GetParamAsync(IrConfigParameterGetParamRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py, METHOD: get_param) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrConfigParameter> InitAsync(IrConfigParameterInitRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: ir_config_parameter.py, METHOD: init) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrConfigParameter> SetParamAsync(IrConfigParameterSetParamRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_config_parameter.py, METHOD: set_param) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py, METHOD: set_param) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: ir_config_parameter.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public async Task<IrConfigParameter> UnlinkDefaultParametersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py, METHOD: unlink_default_parameters) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<IrConfigParameter> input)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: ir_config_parameter.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: crm, FILE: ir_config_parameter.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}