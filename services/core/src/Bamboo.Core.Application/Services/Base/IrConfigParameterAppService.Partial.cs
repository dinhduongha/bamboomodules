using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class IrConfigParameterAppService
    {

        protected async Task<IrConfigParameter> GetParamCronMappingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py, METHOD: _get_param_cron_mapping) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrConfigParameter> GetParamInternalAsync(object key)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py, METHOD: _get_param) ---
            */
            return default;
        }

        protected async Task<IrConfigParameter> SaleSyncLinkedCronsInternalAsync(object unlink)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py, METHOD: _sale_sync_linked_crons) ---
            */
            return default;
        }
    }
}