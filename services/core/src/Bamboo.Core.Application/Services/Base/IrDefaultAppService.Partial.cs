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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class IrDefaultAppService
    {

        protected async Task<IrDefault> CheckJsonFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_default.py, METHOD: _check_json_format) ---
            */
            return default;
        }

        protected async Task<IrDefault> EvaluateConditionWithFallbackInternalAsync(object model_name, object field_expr, object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_default.py, METHOD: _evaluate_condition_with_fallback) ---
            */
            return default;
        }

        protected async Task<IrDefault> GetFieldColumnFallbacksInternalAsync(object model_name, object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_default.py, METHOD: _get_field_column_fallbacks) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrDefault> GetInternalAsync(object model_name, object field_name, Guid user_id, Guid company_id, object condition)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_default.py, METHOD: _get) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrDefault> GetModelDefaultsInternalAsync(object model_name, object condition)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_default.py, METHOD: _get_model_defaults) ---
            */
            return default;
        }
    }
}