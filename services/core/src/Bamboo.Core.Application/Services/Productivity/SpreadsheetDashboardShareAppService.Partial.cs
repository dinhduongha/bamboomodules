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
    public partial class SpreadsheetDashboardShareAppService
    {

        protected async Task<SpreadsheetDashboardShare> CheckDashboardAccessInternalAsync(object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py, METHOD: _check_dashboard_access) ---
            */
            return default;
        }

        protected async Task<SpreadsheetDashboardShare> CheckTokenInternalAsync(object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py, METHOD: _check_token) ---
            */
            return default;
        }

        protected async Task<SpreadsheetDashboardShare> ComputeFullUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard_share.py, METHOD: _compute_full_url) ---
            */
            return default;
        }
    }
}