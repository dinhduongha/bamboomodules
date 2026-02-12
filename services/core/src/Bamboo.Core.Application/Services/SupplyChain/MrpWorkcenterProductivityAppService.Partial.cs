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
    public partial class MrpWorkcenterProductivityAppService
    {

        protected async Task<MrpWorkcenterProductivity> CheckOpenTimeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _check_open_time_ids) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> CloseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _close) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> ComputeDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> DateEndChangedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _date_end_changed) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> DateStartChangedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _date_start_changed) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> DurationChangedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _duration_changed) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> GetDefaultCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_default_company_id) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> LossTypeChangeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _loss_type_change) ---
            */
            return default;
        }
    }
}