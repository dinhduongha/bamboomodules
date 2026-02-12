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
    public partial class SpreadsheetDashboardAppService
    {

        protected async Task<SpreadsheetDashboard> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        protected async Task<SpreadsheetDashboard> DashboardIsEmptyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _dashboard_is_empty) ---
            */
            return default;
        }

        protected async Task<SpreadsheetDashboard> GetDashboardTranslationNamespaceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _get_dashboard_translation_namespace) ---
            */
            return default;
        }

        protected async Task<SpreadsheetDashboard> GetSampleDashboardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _get_sample_dashboard) ---
            */
            return default;
        }

        protected async Task<SpreadsheetDashboard> GetSerializedReadonlyDashboardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_dashboard, FILE: spreadsheet_dashboard.py, METHOD: _get_serialized_readonly_dashboard) ---
            */
            return default;
        }
    }
}