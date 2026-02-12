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
    public partial class IrActionsActWindowAppService
    {

        protected async Task<IrActWindow> CheckModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_model) ---
            */
            return default;
        }

        protected async Task<IrActWindow> CheckViewModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_view_mode) ---
            */
            return default;
        }

        protected async Task<IrActWindow> ComputeEmbeddedActionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_embedded_actions) ---
            */
            return default;
        }

        protected async Task<IrActWindow> ComputeViewsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_views) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrActWindow> ExistingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _existing) ---
            */
            return default;
        }

        protected async Task<IrActWindow> GetActionDictInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_action_dict) ---
            */
            return default;
        }

        protected async Task<IrActWindow> GetReadableFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_readable_fields) ---
            */
            return default;
        }
    }
}